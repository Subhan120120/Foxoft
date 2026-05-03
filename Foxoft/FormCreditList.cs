using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Foxoft
{
    public partial class FormCreditList : RibbonForm
    {
        private subContext dbContext;
        private const string CreditExcelFileId = "1fctiNBQq3dervclbIV0cLIRpTBd8TmPkLtFVz5ivaV4";

        public FormCreditList()
        {
            InitializeComponent();
        }

        private void FormCreditList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dbContext?.Dispose();
            dbContext = new subContext();

            var list = dbContext.TrCredits
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedDate)
                .ToList();

            creditBindingSource.DataSource = list;

            UpdateBalance(list);
        }

        private void UpdateBalance(List<TrCredit> list)
        {
            decimal balance = list.Sum(x => x.Amount);
            bSI_Balance.Caption = $"Balans: {balance:n2}";
            bSI_Balance.ItemAppearance.Normal.ForeColor = balance >= 0 ? Color.Green : Color.Red;
        }

        private void AddCredit()
        {
            string apiKey = XtraInputBox.Show(
                "Kredit əlavə etmək üçün API Key daxil edin:",
                "Kredit Əlavə Et",
                "");

            if (string.IsNullOrWhiteSpace(apiKey))
                return;

            apiKey = apiKey.Trim();

            // API key hash hesabla
            string apiKeyHash = ComputeSha256Hash(apiKey);

            // Eyni key əvvəl istifadə olunub?
            using (var checkDb = new subContext())
            {
                bool alreadyUsed = checkDb.TrCredits.Any(x => x.ApiKeyHash == apiKeyHash);
                if (alreadyUsed)
                {
                    XtraMessageBox.Show(
                        "Bu API Key artıq istifadə olunub!",
                        "Xəta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            // Internet yoxla
            if (!CheckInternet())
            {
                XtraMessageBox.Show(
                    "İnternet bağlantısı yoxdur!",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                // Google Drive-dan Excel yüklə
                using GoogleDriveAPI googleDriveAPI = new();
                using MemoryStream excelStream = googleDriveAPI.DownloadAsStream(CreditExcelFileId);

                if (excelStream == null || excelStream.Length == 0)
                {
                    XtraMessageBox.Show(
                        "Excel faylı yüklənə bilmədi!",
                        "Xəta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // DevExpress Spreadsheet ilə Excel-i parse et
                decimal? creditValue = ParseExcelForApiKey(excelStream, apiKey);

                if (creditValue == null)
                {
                    XtraMessageBox.Show(
                        "Daxil edilən API Key Excel faylında tapılmadı!",
                        "Xəta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (creditValue <= 0)
                {
                    XtraMessageBox.Show(
                        "API Key-ə aid kredit dəyəri düzgün deyil!",
                        "Xəta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // TrCredit yaradıb DB-yə yaz
                using (var saveDb = new subContext())
                {
                    TrCredit credit = new()
                    {
                        CreditId = Guid.NewGuid(),
                        TransactionType = CreditTransactionType.Purchase,
                        Amount = creditValue.Value,
                        ServiceType = null,
                        Description = $"API Key ilə kredit alışı",
                        ApiKeyHash = apiKeyHash
                    };

                    saveDb.TrCredits.Add(credit);
                    saveDb.SaveChanges();
                }

                XtraMessageBox.Show(
                    $"{creditValue.Value:n2} kredit uğurla əlavə edildi!",
                    "Uğurlu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"Kredit əlavə edilərkən xəta baş verdi:\n{ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// System.IO.Packaging ilə xlsx faylını parse edir.
        /// "ApiKey" sütununda daxil edilən key-i axtarır, tapılarsa "Value" sütununun dəyərini qaytarır.
        /// </summary>
        private static decimal? ParseExcelForApiKey(MemoryStream excelStream, string apiKey)
        {
            using var package = System.IO.Packaging.Package.Open(excelStream, FileMode.Open, FileAccess.Read);

            // Shared strings oxu
            var sharedStringsPart = package.GetPart(new Uri("/xl/sharedStrings.xml", UriKind.Relative));
            List<string> sharedStrings = new();
            using (var reader = System.Xml.XmlReader.Create(sharedStringsPart.GetStream()))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.LocalName == "si")
                    {
                        string text = "";
                        while (reader.Read())
                        {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.LocalName == "t")
                            {
                                text += reader.ReadElementContentAsString();
                            }
                            if (reader.NodeType == System.Xml.XmlNodeType.EndElement && reader.LocalName == "si")
                                break;
                        }
                        sharedStrings.Add(text);
                    }
                }
            }

            // Sheet1 data oxu
            var sheetPart = package.GetPart(new Uri("/xl/worksheets/sheet1.xml", UriKind.Relative));
            List<List<string>> rows = new();

            using (var reader = System.Xml.XmlReader.Create(sheetPart.GetStream()))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.LocalName == "row")
                    {
                        List<string> row = new();

                        // Sütun indekslərini doğru yerləşdirmək üçün
                        Dictionary<int, string> cellValues = new();

                        while (reader.Read())
                        {
                            if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.LocalName == "c")
                            {
                                string cellRef = reader.GetAttribute("r"); // A1, B1, ...
                                string cellType = reader.GetAttribute("t"); // s = shared string
                                int colIndex = GetColumnIndex(cellRef);

                                string value = "";
                                while (reader.Read())
                                {
                                    if (reader.NodeType == System.Xml.XmlNodeType.Element && reader.LocalName == "v")
                                    {
                                        value = reader.ReadElementContentAsString();
                                        break;
                                    }
                                    if (reader.NodeType == System.Xml.XmlNodeType.EndElement && reader.LocalName == "c")
                                        break;
                                }

                                if (cellType == "s" && int.TryParse(value, out int ssIndex) && ssIndex < sharedStrings.Count)
                                    value = sharedStrings[ssIndex];

                                cellValues[colIndex] = value;
                            }

                            if (reader.NodeType == System.Xml.XmlNodeType.EndElement && reader.LocalName == "row")
                                break;
                        }

                        // Sütunları sıraya düz
                        int maxCol = cellValues.Count > 0 ? cellValues.Keys.Max() : -1;
                        for (int i = 0; i <= maxCol; i++)
                            row.Add(cellValues.ContainsKey(i) ? cellValues[i] : "");

                        rows.Add(row);
                    }
                }
            }

            if (rows.Count < 2) return null;

            // Header sütun indekslərini tap
            var header = rows[0];
            int apiKeyColIndex = -1;
            int valueColIndex = -1;

            for (int i = 0; i < header.Count; i++)
            {
                if (string.Equals(header[i]?.Trim(), "ApiKey", StringComparison.OrdinalIgnoreCase))
                    apiKeyColIndex = i;
                else if (string.Equals(header[i]?.Trim(), "Value", StringComparison.OrdinalIgnoreCase))
                    valueColIndex = i;
            }

            if (apiKeyColIndex == -1 || valueColIndex == -1)
                return null;

            // Data sətırlərində API key axtarışı
            for (int r = 1; r < rows.Count; r++)
            {
                var row = rows[r];
                if (apiKeyColIndex >= row.Count || valueColIndex >= row.Count)
                    continue;

                string cellApiKey = row[apiKeyColIndex]?.Trim();

                if (string.Equals(cellApiKey, apiKey, StringComparison.OrdinalIgnoreCase))
                {
                    if (decimal.TryParse(row[valueColIndex], System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture, out decimal parsed))
                        return parsed;

                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Excel hüceyrə referansından (A1, B2, AA3, ...) sütun indeksini hesablayır.
        /// </summary>
        private static int GetColumnIndex(string cellRef)
        {
            int col = 0;
            foreach (char c in cellRef)
            {
                if (char.IsLetter(c))
                    col = col * 26 + (char.ToUpper(c) - 'A' + 1);
                else
                    break;
            }
            return col - 1; // 0-indexed
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
                builder.Append(bytes[i].ToString("x2"));
            return builder.ToString();
        }

        private static bool CheckInternet()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("http://www.google.com");
                request.KeepAlive = false;
                request.Timeout = 3000;
                using var response = (HttpWebResponse)request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string GetEnumDescription<TEnum>(TEnum value) where TEnum : struct, Enum
        {
            var member = typeof(TEnum).GetMember(value.ToString()).FirstOrDefault();

            if (member is null)
                return value.ToString();

            var attr = member.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();

            return attr?.Description ?? value.ToString();
        }

        // Event handlers

        private void bBI_AddCredit_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddCredit();
        }

        private void bBI_Refresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void bBI_ExportXlsx_ItemClick(object sender, ItemClickEventArgs e)
        {
            CustomExtensions.ExportToExcel(this, "Kredit Əməliyyatları", gC_CreditList);
        }

        private void gC_CreditList_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                LoadData();
                e.Handled = true;
            }
        }

        private void gV_CreditList_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == colTransactionType && e.Value is CreditTransactionType transactionType)
            {
                e.DisplayText = transactionType switch
                {
                    CreditTransactionType.Purchase => "Satın alma",
                    CreditTransactionType.Usage => "Xərc",
                    _ => transactionType.ToString()
                };
            }
        }

        private void gV_CreditList_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column == colAmount)
            {
                if (gV_CreditList.GetRowCellValue(e.RowHandle, colAmount) is decimal amount)
                {
                    if (amount > 0)
                        e.Appearance.ForeColor = Color.Green;
                    else if (amount < 0)
                        e.Appearance.ForeColor = Color.Red;
                }
            }

            if (e.Column == colTransactionType)
            {
                if (gV_CreditList.GetRowCellValue(e.RowHandle, colTransactionType) is CreditTransactionType type)
                {
                    if (type == CreditTransactionType.Purchase)
                        e.Appearance.ForeColor = Color.Green;
                    else if (type == CreditTransactionType.Usage)
                        e.Appearance.ForeColor = Color.Red;
                }
            }
        }

        private void FormCreditList_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbContext?.Dispose();
        }
    }
}
