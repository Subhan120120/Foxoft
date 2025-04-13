using DevExpress.Utils;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Foxoft
{
    public static class CustomExtensions
    {
        public static bool IsValid(this DataLayoutControl dataLayoutControl, out List<string> errorList)
        {
            DXErrorProvider provider = new();
            errorList = new();

            foreach (Control ctrl in dataLayoutControl.Controls)
            {
                BaseEdit baseEdit = ctrl as BaseEdit;
                if (baseEdit != null)
                {
                    baseEdit.IsModified = true;

                    //baseEdit.DoValidate(); 

                    string error = baseEdit.ErrorText;

                    if (error != string.Empty)
                    {
                        errorList.Add(error);
                        provider.SetError(baseEdit, error); // just notify
                    }
                    else
                        provider.SetError(baseEdit, string.Empty); // clear previous error
                }
            }

            if (errorList.Count == 0)
                return true;
            else
                return false;
        }

        public static string GetPreviewText(decimal PosDiscount, decimal Amount, decimal NetAmount, float VatRate, string Barcode, string SalesPersonCode)
        {
            decimal PosDiscountRate = 0;
            if (Amount != 0 && NetAmount != 0)
                PosDiscountRate = Math.Round(PosDiscount / Amount * 100, 2);

            string previewText = "ƏDV: " + VatRate + "%\n";

            if (!string.IsNullOrEmpty(Barcode))
                previewText += "Barkod: " + Barcode + "\n";

            if (PosDiscountRate > 0)
                previewText += "Pos Endirimi: [" + PosDiscountRate + "%] = " + PosDiscount + "\n";

            if (!string.IsNullOrEmpty(SalesPersonCode))
                previewText += "Satıcı: " + SalesPersonCode + "\n";

            return previewText;
        }

        public static void DefaultLayout(GridView gridView)
        {
            gridView.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            gridView.Appearance.FooterPanel.Options.UseFont = true;
            gridView.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            gridView.Appearance.Row.Options.UseFont = true;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsView.ShowIndicator = false;
            gridView.OptionsBehavior.Editable = false;
        }

        public static bool? DirectionIsIn(string processCode)
        {
            return processCode switch
            {
                "RP" => true,
                "WP" => true,
                "EX" => true,
                "EI" => true,
                "SB" => true,
                "CI" => true,
                "WI" => true,
                "RPO" => true,
                "IT" => false,
                "RS" => false,
                "WS" => false,
                "IS" => false,
                "CO" => false,
                "WO" => false,
                "RSO" => false,
                _ => null
            };
        }

        public static bool? DirectionIsIn(string processCode, bool isReturn)
        {
            bool? result = DirectionIsIn(processCode);
            if (isReturn)
                return !result;
            else
                return result;
        }

        public static string GetClaim(string processCode)
        {
            return processCode switch
            {
                "IT" => "InventoryTransfer",
                "CI" => "CountIn",
                "CO" => "CountOut",
                "WI" => "WaybillIn",
                "WO" => "WaybillOut",
                "RP" => "RetailPurchaseInvoice",
                "RS" => "RetailSaleInvoice",
                "WS" => "WholesaleInvoice",
                "IS" => "InstallmentSaleInvoice",
                "EX" => "Expense",
                "EI" => "ExpenseOfInvoice",
                "PA" => "PaymentDetail",
                "CT" => "CashTransfer",
                _ => ""
            };
        }

        public static byte[] GetProductTypeArray(string processCode)
        {
            return processCode switch
            {
                "IT" => new byte[] { 1 },
                "CI" => new byte[] { 1 },
                "CO" => new byte[] { 1 },
                "WI" => new byte[] { 1 },
                "WO" => new byte[] { 1 },
                "RP" => new byte[] { 1, 3 },
                "RS" => new byte[] { 1, 3 },
                "WS" => new byte[] { 1, 3 },
                "IS" => new byte[] { 1, 3 },
                "EX" => new byte[] { 2, 3 },
                "EI" => new byte[] { 2, 3 },
                _ => new byte[] { }
            };
        }

        public static bool DirectoryExist(string path)
        {
            string IPAddress = ExtractIPAddressFromUrl(path);

            Ping pingSender = new();
            if (!string.IsNullOrEmpty(IPAddress))
            {
                PingReply reply = pingSender.Send(IPAddress, 500);
                if (reply.Status != IPStatus.Success)
                {
                    MessageBox.Show(IPAddress + " ile elaqe qurula bilmir.");
                    return false;
                }
            }

            if (Directory.Exists(path))
                return true;
            else
                return false;
        }

        private static string ExtractIPAddressFromUrl(string remoteAddress)
        {
            string ipHost = string.Empty;

            if (string.IsNullOrEmpty(remoteAddress))
                return ipHost;

            var match = Regex.Match(remoteAddress, @"\b(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\b");
            if (match.Success)
            {
                ipHost = match.Captures[0].Value;
            }
            return ipHost;
        }

        public static string GetPhiscalAdress()
        {
            string fiscal = String.Empty;
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                PhysicalAddress pInterfaceProperties = nic.GetPhysicalAddress();

                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nic.Name.StartsWith("Ethernet"))
                    fiscal = nic.Id + pInterfaceProperties;

                else if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && nic.Name.StartsWith("Wi-Fi"))
                    fiscal = nic.Id + pInterfaceProperties;
            }

            return fiscal;
        }

        public static string ExportToExcel(Form form, string fileNameText, GridControl gridControl)
        {
            try
            {
                using (SaveFileDialog sFD = new())
                {
                    sFD.Filter = "Excel Faylı|*.xlsx";
                    sFD.Title = "Excel Faylı Yadda Saxla";
                    sFD.FileName = fileNameText;
                    sFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    sFD.DefaultExt = "*.xlsx";

                    if (sFD.ShowDialog() == DialogResult.OK)
                    {
                        XlsxExportOptionsEx expOpt = new()
                        {
                            ExportMode = XlsxExportMode.SingleFile,
                            TextExportMode = TextExportMode.Value,
                            AllowLookupValues = DefaultBoolean.True,
                        };

                        gridControl.ExportToXlsx(sFD.FileName);

                        if (XtraMessageBox.Show(form, "Açmaq istəyirsiz?", "Diqqət", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            Process p = new();
                            p.StartInfo = new ProcessStartInfo(sFD.FileName) { UseShellExecute = true };
                            p.Start();
                        }

                        return "Ok";
                    }
                    else
                    {
                        return "Fail";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}