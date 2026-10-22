using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;

namespace Foxoft
{
    public partial class FormAddInvoiceWizard : XtraForm
    {
        private readonly TrInvoiceHeader _invoiceHeader;
        private readonly DcProcess _process;
        private readonly byte[]? _productTypeArr;

        private readonly BindingList<InvoiceOcrLineVM> _linesList = new();
        private readonly List<byte[]> _currentImages = new();
        private readonly InvoiceOcrService _ocrService = new();
        private CancellationTokenSource? _ocrCts;
        private bool _isProcessing;

        public InvoiceOcrResult? Result { get; private set; }
        public bool ApplyHeaderToInvoice => chkApplyHeader.Checked;

        public FormAddInvoiceWizard(TrInvoiceHeader invoiceHeader, DcProcess process, byte[]? productTypeArr)
        {
            InitializeComponent();
            ApplyLocalization();

            _invoiceHeader = invoiceHeader ?? throw new ArgumentNullException(nameof(invoiceHeader));
            _process = process ?? throw new ArgumentNullException(nameof(process));
            _productTypeArr = productTypeArr;
        }

        private void FormAddInvoiceWizard_Load(object sender, EventArgs e)
        {
            ApplyLocalization();
            LoadUnitsOfMeasure();
            InitGrid();
            InitHeaderFields();
            UpdateSummary();
        }

        private void ApplyLocalization()
        {
            Text = Resources.Form_InvoiceWizard_Title;

            // Left toolbar buttons & info
            btnSelectImage.Caption = Resources.Form_InvoiceWizard_SelectImage;
            btnSelectImage.Hint = Resources.Form_InvoiceWizard_SelectImage;

            btnPasteImage.Caption = Resources.Form_InvoiceWizard_PasteClipboard;
            btnPasteImage.Hint = Resources.Form_InvoiceWizard_PasteClipboard;

            btnClearImage.Caption = Resources.Form_InvoiceWizard_ClearImage;
            btnClearImage.Hint = Resources.Form_InvoiceWizard_ClearImage;

            btnProcessOcr.Caption = Resources.Form_InvoiceWizard_ProcessOcr;
            btnProcessOcr.Hint = Resources.Form_InvoiceWizard_ProcessOcr;

            if (pictureEditInvoice.Image == null)
                lblImageInfo.Text = Resources.Form_Image_NoImageSelected;

            // Header panel controls
            groupControlHeader.Text = Resources.Form_InvoiceWizard_HeaderGroup;
            chkApplyHeader.Properties.Caption = Resources.Form_InvoiceWizard_ApplyHeader;
            layoutItemDocNum.Text = Resources.Form_InvoiceWizard_DocNum;
            layoutItemDocDate.Text = Resources.Form_InvoiceWizard_DocDate;
            layoutItemVendor.Text = Resources.Form_InvoiceWizard_Vendor;

            // Lines panel actions
            groupControlLines.Text = Resources.Form_InvoiceWizard_Lines;
            btnAutoMatch.Caption = Resources.Form_InvoiceWizard_AutoMatch;
            btnAutoMatch.Hint = Resources.Form_InvoiceWizard_AutoMatch;
            btnMatchSettings.Caption = Resources.Form_InvoiceWizard_MatchSettings;
            btnMatchSettings.Hint = Resources.Form_ProductMatchSetting_Title;

            // Grid column captions
            colSelected.Caption = Resources.Form_InvoiceWizard_ColSelected;
            colMatchStatus.Caption = Resources.Form_InvoiceWizard_ColStatus;
            colOcrBarcode.Caption = Resources.Form_InvoiceWizard_ColBarcode;
            colOcrProductName.Caption = Resources.Form_InvoiceWizard_ColOcrProductName;
            colMatchedProductCode.Caption = Resources.Form_InvoiceWizard_ColProductCode;
            colMatchedProductName.Caption = Resources.Form_InvoiceWizard_ColProductName;
            colQty.Caption = Resources.Form_InvoiceWizard_ColQty;
            colUnitOfMeasure.Caption = Resources.Form_InvoiceWizard_ColUnit;
            colPrice.Caption = Resources.Form_InvoiceWizard_ColPrice;
            colAmount.Caption = Resources.Form_InvoiceWizard_ColAmount;
            colLineDescription.Caption = Resources.Form_InvoiceWizard_ColNotes;
            colNewProduct.Caption = Resources.Form_InvoiceWizard_ColNewProduct;
            if (repoBtn_NewProduct.Buttons.Count > 0)
                repoBtn_NewProduct.Buttons[0].Caption = Resources.Form_InvoiceWizard_ColNewProduct;

            // Bottom panel controls
            btnCancelOcr.Text = Resources.Form_InvoiceWizard_Cancel;
            btnAddToInvoice.Text = Resources.Form_InvoiceWizard_AddToInvoice;
            btnCancel.Text = Resources.Form_InvoiceWizard_Close;
            lblStatus.Text = _isProcessing ? Resources.Form_InvoiceWizard_Processing : Resources.Common_Ready;
        }

        private void LoadUnitsOfMeasure()
        {
            try
            {
                using var db = new subContext();
                var units = db.DcUnitOfMeasures.AsNoTracking().ToList();
                repoLUE_UnitOfMeasure.DataSource = units;
            }
            catch
            {
                // Ignore load error
            }
        }

        private void InitGrid()
        {
            gridControlLines.DataSource = _linesList;
        }

        private void InitHeaderFields()
        {
            if (_invoiceHeader.DocumentDate != default)
                dtDocDate.DateTime = _invoiceHeader.DocumentDate;
            else
                dtDocDate.DateTime = DateTime.Today;

            txtDocNum.Text = _invoiceHeader.CustomsDocumentNumber ?? string.Empty;
        }

        private void FormAddInvoiceWizard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteImageFromClipboard();
                e.Handled = true;
            }
        }



        private void btnPasteImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PasteImageFromClipboard();
        }

        private void btnSelectImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using OpenFileDialog dialog = new()
            {
                Title = Resources.Form_InvoiceWizard_OpenFileDialog_Title,
                Filter = Resources.Form_InvoiceWizard_OpenFileDialog_Filter,
                Multiselect = false,
                RestoreDirectory = true
            };

            string defaultDir = GetDefaultInvoiceImageDirectory();
            if (!string.IsNullOrWhiteSpace(defaultDir) && Directory.Exists(defaultDir))
            {
                dialog.InitialDirectory = defaultDir;
            }

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                LoadImageFromFile(dialog.FileName);
            }
        }

        private string GetDefaultInvoiceImageDirectory()
        {
            try
            {
                EfMethods efMethods = new();
                SettingStore? settingStore = efMethods.SelectSettingStore(Authorization.StoreCode);
                if (string.IsNullOrWhiteSpace(settingStore?.ImageFolder))
                    return string.Empty;

                string invoicesRoot = CustomExtensions.CombinePath(settingStore.ImageFolder, "Invoices");
                string docNum = _invoiceHeader?.DocumentNumber?.Trim() ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(docNum))
                {
                    string invoiceFolder = CustomExtensions.CombinePath(invoicesRoot, docNum);
                    try
                    {
                        if (!Directory.Exists(invoiceFolder))
                            Directory.CreateDirectory(invoiceFolder);
                    }
                    catch
                    {
                        // ignore permission or path errors
                    }

                    if (Directory.Exists(invoiceFolder))
                        return invoiceFolder;
                }

                if (Directory.Exists(invoicesRoot))
                    return invoicesRoot;

                if (Directory.Exists(settingStore.ImageFolder))
                    return settingStore.ImageFolder;
            }
            catch
            {
                // ignore
            }

            return string.Empty;
        }

        private void pictureEditInvoice_ImageChanged(object sender, EventArgs e)
        {
            if (pictureEditInvoice.Image != null)
            {
                if (_currentImages.Count == 0)
                {
                    try
                    {
                        byte[] bytes = ImageToPngBytes(pictureEditInvoice.Image);
                        _currentImages.Clear();
                        _currentImages.Add(bytes);
                        double kb = bytes.Length / 1024.0;
                        lblImageInfo.Text = string.Format(Resources.Form_InvoiceWizard_ImageInfo, pictureEditInvoice.Image.Width, pictureEditInvoice.Image.Height, kb);
                    }
                    catch
                    {
                        // ignore
                    }
                }
            }
            else
            {
                _currentImages.Clear();
                lblImageInfo.Text = Resources.Form_Image_NoImageSelected;
            }
        }

        private void PasteImageFromClipboard()
        {
            Image? clipboardImg = TryGetImageFromClipboard();
            if (clipboardImg == null)
            {
                XtraMessageBox.Show(
                    Resources.Form_InvoiceWizard_NoClipboardImage,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                byte[] bytes = ImageToPngBytes(clipboardImg);
                SetImage(bytes, Resources.Form_InvoiceWizard_PastedFromClipboard);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    string.Format(Resources.Form_InvoiceWizard_ClipboardError, ex.Message),
                    Resources.Common_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                clipboardImg.Dispose();
            }
        }

        private static Image? TryGetImageFromClipboard()
        {
            try
            {
                if (Clipboard.ContainsImage())
                {
                    var img = Clipboard.GetImage();
                    if (img != null) return img;
                }

                IDataObject? data = Clipboard.GetDataObject();
                if (data != null)
                {
                    if (data.GetDataPresent(DataFormats.FileDrop))
                    {
                        if (data.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
                        {
                            string ext = Path.GetExtension(files[0]).ToLowerInvariant();
                            if (ext is ".png" or ".jpg" or ".jpeg" or ".bmp" or ".webp")
                            {
                                using var fs = new FileStream(files[0], FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                                return Image.FromStream(fs);
                            }
                        }
                    }

                    if (data.GetDataPresent("PNG"))
                    {
                        if (data.GetData("PNG") is Stream stream)
                            return Image.FromStream(stream);
                    }

                    if (data.GetDataPresent(DataFormats.Bitmap))
                    {
                        if (data.GetData(DataFormats.Bitmap) is Image img)
                            return img;
                    }
                }
            }
            catch
            {
                // ignore
            }

            return null;
        }

        private static byte[] ImageToPngBytes(Image sourceImage)
        {
            using Bitmap copy = new(sourceImage.Width, sourceImage.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(copy))
            {
                g.Clear(Color.Transparent);
                g.DrawImage(sourceImage, 0, 0, sourceImage.Width, sourceImage.Height);
            }

            using MemoryStream ms = new();
            copy.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }

        private void LoadImageFromFile(string filePath)
        {
            try
            {
                byte[] bytes = File.ReadAllBytes(filePath);
                string fileName = Path.GetFileName(filePath);
                SetImage(bytes, fileName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"{Resources.Common_ErrorOccurred}\n{ex.Message}",
                    Resources.Common_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SetImage(byte[] imageBytes, string sourceName)
        {
            _currentImages.Clear();
            _currentImages.Add(imageBytes);

            using var ms = new MemoryStream(imageBytes);
            using var bmp = new Bitmap(ms);
            pictureEditInvoice.Image = new Bitmap(bmp);

            double kb = imageBytes.Length / 1024.0;
            lblImageInfo.Text = $"{sourceName} | " + string.Format(Resources.Form_InvoiceWizard_ImageInfo, bmp.Width, bmp.Height, kb);
        }

        private void btnClearImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _currentImages.Clear();
            pictureEditInvoice.Image = null;
            lblImageInfo.Text = Resources.Form_Image_NoImageSelected;
        }

        private void pictureEditInvoice_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void pictureEditInvoice_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data?.GetData(DataFormats.FileDrop) is string[] files && files.Length > 0)
            {
                string ext = Path.GetExtension(files[0]).ToLowerInvariant();
                if (ext is ".png" or ".jpg" or ".jpeg" or ".bmp" or ".webp")
                {
                    LoadImageFromFile(files[0]);
                }
            }
        }

        private async void btnProcessOcr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_isProcessing)
                return;

            // Ensure image bytes are populated from pictureEdit if needed
            if (_currentImages.Count == 0 && pictureEditInvoice.Image != null)
            {
                try
                {
                    byte[] bytes = ImageToPngBytes(pictureEditInvoice.Image);
                    _currentImages.Add(bytes);
                }
                catch
                {
                    // ignore
                }
            }

            if (_currentImages.Count == 0)
            {
                XtraMessageBox.Show(
                    Resources.Form_InvoiceWizard_NoImageSelected,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string apiKey = Settings.Default.OpenAIApiKey?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(apiKey))
                apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                XtraMessageBox.Show(
                    Resources.Form_InvoiceWizard_ApiKeyRequired,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string model = Settings.Default.OpenAIModel?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(model))
                model = "gpt-4o";

            SetProcessingState(true);
            _ocrCts = new CancellationTokenSource();

            try
            {
                InvoiceOcrResult result = await _ocrService.ExtractInvoiceDataAsync(
                    _currentImages,
                    apiKey,
                    model,
                    _ocrCts.Token);

                // Auto-match products against database
                InvoiceOcrProductMatcher.MatchLines(result.Lines, _productTypeArr, vendorCode: _invoiceHeader?.CurrAccCode);

                // Populate UI
                _linesList.Clear();
                foreach (var line in result.Lines)
                    _linesList.Add(line);

                gridControlLines.RefreshDataSource();
                gridViewLines.RefreshData();
                gridViewLines.BestFitColumns();

                if (!string.IsNullOrWhiteSpace(result.DocumentNumber))
                    txtDocNum.Text = result.DocumentNumber;

                if (result.DocumentDate.HasValue)
                    dtDocDate.DateTime = result.DocumentDate.Value;

                if (!string.IsNullOrWhiteSpace(result.VendorName))
                    txtVendor.Text = result.VendorName;

                Result = result;
                UpdateSummary();

                XtraMessageBox.Show(
                    string.Format(Resources.Form_InvoiceWizard_Success, result.Lines.Count),
                    Resources.Common_Info,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = Resources.Form_InvoiceWizard_OperationCancelled;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    $"{Resources.Common_ErrorOccurred}\n{ex.Message}",
                    Resources.Common_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                SetProcessingState(false);
                _ocrCts?.Dispose();
                _ocrCts = null;
            }
        }

        private void btnCancelOcr_Click(object sender, EventArgs e)
        {
            _ocrCts?.Cancel();
        }

        private void SetProcessingState(bool isProcessing)
        {
            _isProcessing = isProcessing;
            progressBarOcr.Visible = isProcessing;
            btnCancelOcr.Visible = isProcessing;
            btnProcessOcr.Enabled = !isProcessing;
            btnSelectImage.Enabled = !isProcessing;
            btnPasteImage.Enabled = !isProcessing;
            btnClearImage.Enabled = !isProcessing;
            btnAutoMatch.Enabled = !isProcessing;
            btnMatchSettings.Enabled = !isProcessing;
            btnAddToInvoice.Enabled = !isProcessing;

            lblStatus.Text = isProcessing
                ? Resources.Form_InvoiceWizard_Processing
                : Resources.Common_Ready;
        }

        private void btnAutoMatch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InvoiceOcrProductMatcher.MatchLines(_linesList, _productTypeArr, vendorCode: _invoiceHeader?.CurrAccCode);
            gridViewLines.RefreshData();
            UpdateSummary();
        }

        private void btnMatchSettings_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using FormProductMatchSetting form = new();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                InvoiceOcrProductMatcher.MatchLines(_linesList, _productTypeArr, form.Options, _invoiceHeader?.CurrAccCode);
                gridViewLines.RefreshData();
                UpdateSummary();
            }
        }



        private void repoBtnEdit_ProductCode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ChooseProductForFocusedRow();
        }

        private void repoBtn_NewProduct_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CreateNewProductForFocusedRow();
        }

        private void CreateNewProductForFocusedRow()
        {
            if (gridViewLines.GetFocusedRow() is not InvoiceOcrLineVM focusedLine)
                return;

            byte productTypeCode = (_productTypeArr != null && _productTypeArr.Length > 0 && _productTypeArr[0] > 0)
                ? _productTypeArr[0]
                : (byte)1;

            DcProduct templateProduct = new()
            {
                ProductTypeCode = productTypeCode,
                ProductDesc = !string.IsNullOrWhiteSpace(focusedLine.OcrProductName) ? focusedLine.OcrProductName.Trim() : string.Empty,
                PurchasePrice = focusedLine.Price > 0 ? focusedLine.Price : 0,
                DefaultUnitOfMeasureId = focusedLine.UnitOfMeasureId ?? 0
            };

            using FormProduct formProduct = new(templateProduct.ProductTypeCode, isNew: true, templateProduct);
            if (formProduct.ShowDialog(this) == DialogResult.OK && formProduct.dcProduct != null)
            {
                string newCode = formProduct.dcProduct.ProductCode;
                string newDesc = formProduct.dcProduct.ProductDesc;

                if (!string.IsNullOrWhiteSpace(focusedLine.OcrBarcode))
                {
                    try
                    {
                        using subContext db = new();
                        string cleanBc = focusedLine.OcrBarcode.Trim();
                        if (!db.TrProductBarcodes.Any(x => x.Barcode == cleanBc))
                        {
                            DcBarcodeType defaultBarcodeType = new EfMethods().SelectBarcodTypeDefault();
                            db.TrProductBarcodes.Add(new TrProductBarcode
                            {
                                ProductCode = newCode,
                                Barcode = cleanBc,
                                BarcodeTypeCode = defaultBarcodeType?.BarcodeTypeCode ?? "1",
                                Qty = 1,
                                CreatedUserName = Authorization.CurrAccCode,
                                CreatedDate = DateTime.Now
                            });
                            db.SaveChanges();
                            focusedLine.MatchedBarcode = cleanBc;
                        }
                    }
                    catch
                    {
                        // ignore barcode link error if any
                    }
                }

                InvoiceOcrProductMatcher.UpdateMatchedProduct(focusedLine, newCode);
                focusedLine.MatchedProductName = newDesc;
                gridViewLines.RefreshRow(gridViewLines.FocusedRowHandle);
                UpdateSummary();
            }
        }

        private void ChooseProductForFocusedRow()
        {
            if (gridViewLines.GetFocusedRow() is not InvoiceOcrLineVM focusedLine)
                return;

            using FormProductList form = new(_productTypeArr, false, focusedLine.MatchedProductCode ?? string.Empty);
            if (form.ShowDialog(this) == DialogResult.OK && form.dcProduct != null)
            {
                InvoiceOcrProductMatcher.UpdateMatchedProduct(focusedLine, form.dcProduct.ProductCode);
                gridViewLines.RefreshRow(gridViewLines.FocusedRowHandle);
                UpdateSummary();
            }
        }

        private void gridViewLines_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (gridViewLines.GetRow(e.RowHandle) is not InvoiceOcrLineVM line)
                return;

            if (e.Column == colMatchedProductCode)
            {
                string code = (e.Value ?? string.Empty).ToString() ?? string.Empty;
                InvoiceOcrProductMatcher.UpdateMatchedProduct(line, code);
                gridViewLines.RefreshRow(e.RowHandle);
            }
            else if (e.Column == colQty || e.Column == colPrice)
            {
                line.UpdateAmount();
            }

            UpdateSummary();
        }

        private void repoCheckSelected_CheckedChanged(object sender, EventArgs e)
        {
            gridViewLines.PostEditor();
            UpdateSummary();
        }

        private void gridViewLines_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (gridViewLines.GetRow(e.RowHandle) is InvoiceOcrLineVM line)
            {
                if (!line.IsMatched && line.Selected)
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 245, 235); // subtle orange warning
                }
            }
        }

        private void UpdateSummary()
        {
            int total = _linesList.Count;
            int selected = _linesList.Count(x => x.Selected);
            int matched = _linesList.Count(x => x.Selected && x.IsMatched);
            decimal totalAmount = _linesList.Where(x => x.Selected).Sum(x => x.Amount);

            string currency = Settings.Default.AppSetting?.LocalCurrencyCode ?? "AZN";
            lblSummary.Text = string.Format(
                Resources.Form_InvoiceWizard_Summary,
                total,
                selected,
                matched,
                totalAmount,
                currency);
        }

        private void btnAddToInvoice_Click(object sender, EventArgs e)
        {
            gridViewLines.CloseEditor();
            gridViewLines.UpdateCurrentRow();

            var selectedLines = _linesList.Where(x => x.Selected).ToList();
            if (selectedLines.Count == 0)
            {
                XtraMessageBox.Show(
                    Resources.Form_InvoiceWizard_NoLinesSelected,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var unmatchedSelected = selectedLines.Where(x => string.IsNullOrWhiteSpace(x.MatchedProductCode)).ToList();
            if (unmatchedSelected.Count > 0)
            {
                if (XtraMessageBox.Show(this, Resources.Form_InvoiceWizard_UnmatchedRowsWarning, Resources.Common_Attention, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
            }

            // Sync edited header values
            Result ??= new InvoiceOcrResult();
            Result.DocumentNumber = txtDocNum.Text.Trim();
            Result.DocumentDate = dtDocDate.DateTime != default ? dtDocDate.DateTime : null;
            Result.VendorName = txtVendor.Text.Trim();
            Result.Lines = _linesList.ToList();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
