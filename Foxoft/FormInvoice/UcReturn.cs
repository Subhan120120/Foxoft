using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Foxoft.AppCode;
using Foxoft.AppCode.Service;
using Foxoft.Models;
using Foxoft.Models.ViewModel;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class UcReturn : UserControl
    {
        public string processCode = "RS";
        public TrInvoiceHeader? trInvoiceHeader;

        public BindingList<ReturnLineVM> OriginalLines { get; } = new();
        public BindingList<ReturnCartItemVM> ReturnCart { get; } = new();

        private readonly subContext _db = new();
        private readonly LoyaltyService _loyalty;
        private readonly DocumentLockService _lockService;
        private readonly EfMethods efMethods = new();

        public UcReturn()
        {
            InitializeComponent();

            _loyalty = new LoyaltyService(_db);
            _lockService = new DocumentLockService(_db);
        }

        public UcReturn(string processCode)
            : this()
        {
            if (!string.IsNullOrWhiteSpace(processCode))
                this.processCode = processCode;
        }

        private readonly Dictionary<Keys, Action> _shortcutActions = new();

        private void UcReturn_Load(object sender, EventArgs e)
        {
            if (ParentForm != null)
                ParentForm.FormClosing += ParentForm_FormClosing;

            gC_InvoiceLine.DataSource = OriginalLines;
            gC_ReturnInvoiceLine.DataSource = ReturnCart;

            ApplyBarcodeColumnVisibility();
            LoadInvoiceLineLayout();
            LoadShortcuts();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible && !DesignMode)
            {
                LoadShortcuts();
            }
        }

        public void LoadShortcuts()
        {
            _shortcutActions.Clear();

            var buttonMap = new Dictionary<string, (Action action, SimpleButton button, string baseText)>(StringComparer.OrdinalIgnoreCase)
            {
                ["btn_Ok"] = (() => btn_Ok.PerformClick(), btn_Ok, Resources.Form_Return_Button_Confirm),
                ["btn_Cancel"] = (() => btn_Cancel.PerformClick(), btn_Cancel, Resources.Form_Return_Button_Cancel),
                ["btn_ReturnAll"] = (() => btn_ReturnAll.PerformClick(), btn_ReturnAll, Resources.Form_Return_Button_ReturnAll),
                ["btn_Clear"] = (() => btn_Clear.PerformClick(), btn_Clear, Resources.Form_Return_Button_Clear),
            };

            foreach (var item in buttonMap.Values)
                item.button.Text = item.baseText;

            var shortcuts = ShortcutHelper.LoadShortcuts(nameof(UcReturn));

            foreach (var kvp in shortcuts)
            {
                if (buttonMap.TryGetValue(kvp.Key, out var mapping))
                {
                    _shortcutActions[kvp.Value] = mapping.action;
                    mapping.button.Text = ShortcutHelper.AppendShortcutToText(mapping.baseText, kvp.Value);
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_shortcutActions.TryGetValue(keyData, out Action? action))
            {
                if ((keyData & Keys.KeyCode) == Keys.Escape)
                {
                    if (gV_ReturnInvoiceLine.IsEditing)
                    {
                        gV_ReturnInvoiceLine.HideEditor();
                        return true;
                    }
                    if (gV_InvoiceLine.IsEditing)
                    {
                        gV_InvoiceLine.HideEditor();
                        return true;
                    }
                }

                action.Invoke();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ParentForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (ReturnCart.Count > 0)
            {
                DialogResult answer = XtraMessageBox.Show(
                    Resources.Form_Return_Message_CancelReturnQuestion,
                    Resources.Form_Return_Caption_Confirmation,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (answer != DialogResult.Yes)
                    e.Cancel = true;
            }
        }

        private void ApplyBarcodeColumnVisibility()
        {
            bool useBarcode = Settings.Default.AppSetting?.UseBarcode == true;
            col_Barcode.OptionsColumn.ShowInCustomizationForm = useBarcode;
            if (!useBarcode)
                col_Barcode.Visible = false;
        }

        #region Layout Management

        private static string GetLayoutFileDir()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files");
        }

        private string GetInvoiceLineLayoutFileName()
        {
            return "ReturnInvoiceLine" + processCode + "Layout.xml";
        }

        private string GetInvoiceLineLayoutFilePath()
        {
            return Path.Combine(GetLayoutFileDir(), GetInvoiceLineLayoutFileName());
        }

        private void LoadInvoiceLineLayout()
        {
            string layoutFilePath = GetInvoiceLineLayoutFilePath();
            if (File.Exists(layoutFilePath))
            {
                OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
                gV_InvoiceLine.RestoreLayoutFromXml(layoutFilePath, option);
            }
        }

        #endregion

        #region Invoice Search & Loading

        private void btnEdit_InvoiceHeader_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0) // Search
            {
                SelectDocNum();
            }
            else if (e.Button.Index == 1) // Clear
            {
                btn_Clear_Click(sender, EventArgs.Empty);
            }
        }

        private void btnEdit_InvoiceHeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string docNum = btnEdit_InvoiceHeader.Text?.Trim() ?? string.Empty;
                LoadInvoiceByDocNum(docNum);
            }
            else if (e.KeyCode == Keys.F4)
            {
                SelectDocNum();
            }
        }

        private void SelectDocNum()
        {
            if (ReturnCart.Count > 0)
            {
                DialogResult answer = XtraMessageBox.Show(
                    Resources.Form_Return_Message_CancelReturnQuestion,
                    Resources.Form_Return_Caption_Confirmation,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (answer != DialogResult.Yes)
                    return;
            }

            using FormInvoiceLineList form = new(new string[] { processCode });
            if (form.ShowDialog(this) == DialogResult.OK && form.trInvoiceLine != null)
            {
                LoadInvoice(form.trInvoiceLine.InvoiceHeaderId, form.trInvoiceLine.InvoiceLineId);
            }
        }

        private void LoadInvoiceByDocNum(string docNum)
        {
            if (string.IsNullOrWhiteSpace(docNum))
                return;

            if (ReturnCart.Count > 0)
            {
                DialogResult answer = XtraMessageBox.Show(
                    Resources.Form_Return_Message_CancelReturnQuestion,
                    Resources.Form_Return_Caption_Confirmation,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (answer != DialogResult.Yes)
                    return;
            }

            TrInvoiceHeader header = efMethods.SelectInvoiceHeaderByDocNum(docNum);
            if (header != null && (string.IsNullOrEmpty(processCode) || header.ProcessCode == processCode) && !header.IsReturn)
            {
                LoadInvoice(header.InvoiceHeaderId);
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_Return_Message_InvoiceNotFound,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void LoadInvoice(Guid invoiceHeaderId, Guid? focusedLineId = null)
        {
            ClearControlsInternal();

            trInvoiceHeader = efMethods.SelectInvoiceHeader(invoiceHeaderId);
            if (trInvoiceHeader == null)
            {
                XtraMessageBox.Show(
                    Resources.Form_Return_Message_InvoiceNotFound,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            btnEdit_InvoiceHeader.EditValue = trInvoiceHeader.DocumentNumber;
            txt_CurrAccDesc.EditValue = trInvoiceHeader.DcCurrAcc?.CurrAccDesc ?? trInvoiceHeader.CurrAccCode;
            txt_DocDate.EditValue = trInvoiceHeader.DocumentDate.ToString("dd.MM.yyyy");

            var lines = efMethods.SelectReturnLineVMs(invoiceHeaderId);
            OriginalLines.Clear();
            foreach (var line in lines)
            {
                OriginalLines.Add(line);
            }

            decimal totalAmount = OriginalLines.Sum(x => x.NetAmount);
            txt_TotalAmount.EditValue = $"{totalAmount:N2} AZN";

            gC_PaymentLine.DataSource = efMethods.SelectPaymentLinesByInvoice(invoiceHeaderId);

            if (focusedLineId.HasValue)
            {
                int rowHandle = gV_InvoiceLine.LocateByValue(0, col_ProductCode, focusedLineId.Value);
                if (rowHandle != GridControl.InvalidRowHandle)
                {
                    gV_InvoiceLine.FocusedRowHandle = rowHandle;
                    gV_InvoiceLine.MakeRowVisible(rowHandle);
                }
            }

            txt_BarcodeSearch.Focus();
        }

        #endregion

        #region Barcode Scanner & Quick Search

        private void txt_BarcodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleBarcodeOrQuickSearch();
            }
        }

        private void txt_BarcodeSearch_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            HandleBarcodeOrQuickSearch();
        }

        private void HandleBarcodeOrQuickSearch()
        {
            string search = txt_BarcodeSearch.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(search))
                return;

            if (trInvoiceHeader == null)
            {
                LoadInvoiceByDocNum(search);
                txt_BarcodeSearch.Text = string.Empty;
                return;
            }

            var matchingLine = OriginalLines.FirstOrDefault(x =>
                string.Equals(x.Barcode, search, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(x.ProductCode, search, StringComparison.OrdinalIgnoreCase));

            if (matchingLine != null)
            {
                AddLineToReturn(matchingLine);
                txt_BarcodeSearch.Text = string.Empty;
            }
            else
            {
                XtraMessageBox.Show(
                    Resources.Form_Return_Message_NoQtyToReturn,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Return Cart Operations

        private void repoBtn_AddReturn_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (gV_InvoiceLine.GetFocusedRow() is ReturnLineVM line)
                AddLineToReturn(line);
        }

        private void gV_InvoiceLine_DoubleClick(object sender, EventArgs e)
        {
            if (gV_InvoiceLine.GetFocusedRow() is ReturnLineVM line)
                AddLineToReturn(line);
        }

        private void gV_InvoiceLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (gV_InvoiceLine.GetFocusedRow() is ReturnLineVM line)
                {
                    AddLineToReturn(line);
                    e.Handled = true;
                }
            }
        }

        private void AddLineToReturn(ReturnLineVM line, decimal? customQty = null)
        {
            if (line.RemainingQty <= 0)
            {
                XtraMessageBox.Show(
                    Resources.Form_Return_Message_NoQtyToReturn,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            decimal qtyToAdd;
            if (customQty.HasValue)
            {
                qtyToAdd = customQty.Value;
            }
            else if (line.RemainingQty == 1)
            {
                qtyToAdd = 1;
            }
            else
            {
                using FormInput formQty = new(line.RemainingQty, line.RemainingQty);
                if (formQty.ShowDialog(this) != DialogResult.OK)
                    return;

                qtyToAdd = formQty.input;
            }

            if (qtyToAdd <= 0)
            {
                XtraMessageBox.Show(
                    Resources.Form_Return_Message_InvalidQty,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (qtyToAdd > line.RemainingQty)
            {
                XtraMessageBox.Show(
                    string.Format(Resources.Form_Return_Message_QtyExceedsRemaining, qtyToAdd, line.RemainingQty),
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var existingCartItem = ReturnCart.FirstOrDefault(x => x.InvoiceLineId == line.InvoiceLineId);
            if (existingCartItem != null)
            {
                existingCartItem.ReturnQty += qtyToAdd;
            }
            else
            {
                decimal origQty = Math.Abs(line.QtyIn - line.QtyOut);
                ReturnCartItemVM cartItem = new()
                {
                    InvoiceLineId = line.InvoiceLineId,
                    InvoiceHeaderId = line.InvoiceHeaderId,
                    ProductCode = line.ProductCode,
                    Barcode = line.Barcode,
                    ProductDesc = line.ProductDesc,
                    OriginalQty = origQty,
                    AlreadyReturnedQty = line.ReturnQty,
                    MaxReturnableQty = origQty - line.ReturnQty,
                    ReturnQty = qtyToAdd,
                    Price = line.Price,
                    PriceLoc = line.PriceLoc,
                    PosDiscount = line.PosDiscount,
                    ExchangeRate = line.ExchangeRate,
                    CurrencyCode = line.CurrencyCode ?? "AZN",
                    UnitOfMeasureId = line.UnitOfMeasureId,
                    ProductCost = line.ProductCost,
                    VatRate = line.VatRate,
                    SerialNumberCode = line.SerialNumberCode,
                    LineDescription = line.LineDescription,
                    SalesPersonCode = line.SalesPersonCode,
                    WorkerCode = line.WorkerCode
                };
                ReturnCart.Add(cartItem);
            }

            line.RemainingQty -= qtyToAdd;

            gV_InvoiceLine.RefreshData();
            gV_ReturnInvoiceLine.RefreshData();

            int cartHandle = gV_ReturnInvoiceLine.LocateByValue(0, col_RProductCode, line.ProductCode);
            if (cartHandle != GridControl.InvalidRowHandle)
            {
                gV_ReturnInvoiceLine.FocusedRowHandle = cartHandle;
                gV_ReturnInvoiceLine.MakeRowVisible(cartHandle);
            }
        }

        private void repoBtn_RemoveReturn_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (gV_ReturnInvoiceLine.GetFocusedRow() is ReturnCartItemVM cartItem)
                RemoveCartItem(cartItem);
        }

        private void gV_ReturnInvoiceLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gV_ReturnInvoiceLine.GetFocusedRow() is ReturnCartItemVM cartItem)
                {
                    RemoveCartItem(cartItem);
                    e.Handled = true;
                }
            }
        }

        private void RemoveCartItem(ReturnCartItemVM cartItem)
        {
            ReturnCart.Remove(cartItem);

            var originalLine = OriginalLines.FirstOrDefault(x => x.InvoiceLineId == cartItem.InvoiceLineId);
            if (originalLine != null)
            {
                originalLine.RemainingQty += cartItem.ReturnQty;
            }

            gV_InvoiceLine.RefreshData();
            gV_ReturnInvoiceLine.RefreshData();
        }

        private void repoSpin_ReturnQty_EditValueChanged(object sender, EventArgs e)
        {
            if (sender is SpinEdit spin && gV_ReturnInvoiceLine.GetFocusedRow() is ReturnCartItemVM cartItem)
            {
                decimal newQty = spin.Value;
                if (newQty <= 0)
                {
                    spin.Value = 1;
                    return;
                }

                if (newQty > cartItem.MaxReturnableQty)
                {
                    XtraMessageBox.Show(
                        string.Format(Resources.Form_Return_Message_QtyExceedsRemaining, newQty, cartItem.MaxReturnableQty),
                        Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    spin.Value = cartItem.MaxReturnableQty;
                    return;
                }

                cartItem.ReturnQty = newQty;

                var originalLine = OriginalLines.FirstOrDefault(x => x.InvoiceLineId == cartItem.InvoiceLineId);
                if (originalLine != null)
                {
                    originalLine.RemainingQty = cartItem.MaxReturnableQty - cartItem.ReturnQty;
                }

                gV_InvoiceLine.RefreshData();
                gV_ReturnInvoiceLine.UpdateTotalSummary();
            }
        }

        private void btn_ReturnAll_Click(object sender, EventArgs e)
        {
            if (trInvoiceHeader == null || OriginalLines.Count == 0)
                return;

            foreach (var line in OriginalLines)
            {
                if (line.RemainingQty > 0)
                {
                    AddLineToReturn(line, line.RemainingQty);
                }
            }
        }

        private void gV_InvoiceLine_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            if (gV_InvoiceLine.GetRow(e.RowHandle) is ReturnLineVM line)
            {
                if (line.RemainingQty <= 0)
                {
                    e.Appearance.ForeColor = Color.DarkGray;
                }
            }
        }

        private void gV_PaymentLine_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == col_CashRegisterDesc && string.IsNullOrWhiteSpace(e.DisplayText))
            {
                int rowHandle = gV_PaymentLine.GetRowHandle(e.ListSourceRowIndex);
                if (gV_PaymentLine.GetRow(rowHandle) is TrPaymentLine line && !string.IsNullOrEmpty(line.CashRegisterCode))
                {
                    e.DisplayText = line.CashRegisterCode;
                }
            }
            else if (e.Column == col_PaymentMethodDesc && string.IsNullOrWhiteSpace(e.DisplayText))
            {
                int rowHandle = gV_PaymentLine.GetRowHandle(e.ListSourceRowIndex);
                if (gV_PaymentLine.GetRow(rowHandle) is TrPaymentLine line && line.PaymentMethodId > 0)
                {
                    e.DisplayText = line.PaymentMethodId.ToString();
                }
            }
        }

        #endregion

        #region Commit & Save (Atomic & Safe)

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            ConfirmReturn();
        }

        private void ConfirmReturn()
        {
            if (trInvoiceHeader == null)
            {
                XtraMessageBox.Show(
                    Resources.Form_Return_Message_InvoiceNotFound,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (ReturnCart.Count == 0)
            {
                XtraMessageBox.Show(
                    Resources.Form_Return_Message_CartEmpty,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Fresh database verification to prevent over-returns from concurrency
            var freshLines = efMethods.SelectReturnLineVMs(trInvoiceHeader.InvoiceHeaderId);
            foreach (var cartItem in ReturnCart)
            {
                var freshMatch = freshLines.FirstOrDefault(x => x.InvoiceLineId == cartItem.InvoiceLineId);
                if (freshMatch == null || cartItem.ReturnQty > freshMatch.RemainingQty)
                {
                    decimal available = freshMatch?.RemainingQty ?? 0;
                    XtraMessageBox.Show(
                        string.Format(Resources.Form_Return_Message_QtyExceedsRemaining, cartItem.ReturnQty, available),
                        Resources.Common_Attention,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            using subContext db = new();
            var strategy = db.Database.CreateExecutionStrategy();

            string newDocNum = string.Empty;
            bool isSuccess = false;

            try
            {
                strategy.Execute(() =>
                {
                    using var tx = db.Database.BeginTransaction();
                    try
                    {
                        newDocNum = efMethods.GetNextDocNum(
                            true,
                            processCode,
                            nameof(TrInvoiceHeader.DocumentNumber),
                            nameof(subContext.TrInvoiceHeaders),
                            6);

                        Guid returnHeaderId = Guid.NewGuid();

                        TrInvoiceHeader returnHeader = new()
                        {
                            InvoiceHeaderId = returnHeaderId,
                            RelatedInvoiceId = trInvoiceHeader.InvoiceHeaderId,
                            DocumentNumber = newDocNum,
                            ProcessCode = trInvoiceHeader.ProcessCode,
                            IsReturn = true,
                            CurrAccCode = trInvoiceHeader.CurrAccCode,
                            OfficeCode = Authorization.OfficeCode,
                            StoreCode = Authorization.StoreCode,
                            WarehouseCode = efMethods.SelectWarehouseByStore(Authorization.StoreCode),
                            CreatedUserName = Authorization.CurrAccCode,
                            IsMainTF = true,
                            IsCompleted = true,
                            LoyaltyCardId = trInvoiceHeader.LoyaltyCardId,
                            TerminalId = Settings.Default.TerminalId,
                            DocumentDate = DateTime.Today,
                            DocumentTime = DateTime.Now.TimeOfDay,
                            OperationDate = DateTime.Today,
                            OperationTime = DateTime.Now.TimeOfDay
                        };

                        db.TrInvoiceHeaders.Add(returnHeader);

                        bool isIn = CustomExtensions.DirectionIsIn(processCode) == true;

                        foreach (var item in ReturnCart)
                        {
                            TrInvoiceLine line = new()
                            {
                                InvoiceLineId = Guid.NewGuid(),
                                InvoiceHeaderId = returnHeaderId,
                                RelatedLineId = item.InvoiceLineId,
                                ProductCode = item.ProductCode,
                                ProductCost = item.ProductCost,
                                UnitOfMeasureId = item.UnitOfMeasureId,
                                Price = item.Price,
                                PriceLoc = item.PriceLoc,
                                CurrencyCode = item.CurrencyCode,
                                ExchangeRate = item.ExchangeRate,
                                PosDiscount = item.PosDiscount,
                                VatRate = item.VatRate,
                                SerialNumberCode = item.SerialNumberCode,
                                LineDescription = item.LineDescription,
                                SalesPersonCode = item.SalesPersonCode,
                                WorkerCode = item.WorkerCode,
                                CreatedUserName = Authorization.CurrAccCode
                            };

                            if (isIn)
                            {
                                line.QtyIn = -item.ReturnQty;
                                line.QtyOut = 0;
                            }
                            else
                            {
                                line.QtyOut = -item.ReturnQty;
                                line.QtyIn = 0;
                            }

                            line.Amount = (line.QtyIn + line.QtyOut) * line.Price;
                            line.AmountLoc = (line.QtyIn + line.QtyOut) * line.PriceLoc;
                            line.NetAmount = (line.QtyIn + line.QtyOut) * line.Price * (100m - line.PosDiscount) / 100m;
                            line.NetAmountLoc = (line.QtyIn + line.QtyOut) * line.PriceLoc * (100m - line.PosDiscount) / 100m;

                            db.TrInvoiceLines.Add(line);
                        }

                        db.SaveChanges(Authorization.CurrAccCode);

                        // Sync loyalty points
                        _loyalty.SyncInvoiceEarn(returnHeader);

                        // Lock document if configured
                        if (Settings.Default.AppSetting?.LockReturnDocument == true)
                        {
                            returnHeader.IsLocked = true;
                            db.SaveChanges(Authorization.CurrAccCode);
                        }

                        tx.Commit();
                        isSuccess = true;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(
                    ex.Message,
                    Resources.Common_Attention,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (isSuccess)
            {
                XtraMessageBox.Show(
                    string.Format(Resources.Form_Return_Message_Success, newDocNum),
                    Resources.Form_Return_Caption_Confirmation,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                FormERP? formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
                if (formERP != null)
                {
                    if (XtraMessageBox.Show(
                            Resources.Form_Return_Message_OpenInvoiceQuestion,
                            Resources.Form_Return_Caption_OpenInvoice,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        OpenFormInvoice(newDocNum);
                    }
                }

                ClearControlsInternal();
            }
        }

        #endregion

        #region Form Clear & Cancellation

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (ReturnCart.Count > 0)
            {
                DialogResult answer = XtraMessageBox.Show(
                    Resources.Form_Return_Message_CancelReturnQuestion,
                    Resources.Form_Return_Caption_Confirmation,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (answer != DialogResult.Yes)
                    return;
            }

            ClearControlsInternal();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            btn_Cancel_Click(sender, e);
        }

        private void ClearControlsInternal()
        {
            trInvoiceHeader = null;
            ReturnCart.Clear();
            OriginalLines.Clear();

            btnEdit_InvoiceHeader.EditValue = null;
            txt_CurrAccDesc.EditValue = null;
            txt_DocDate.EditValue = null;
            txt_TotalAmount.EditValue = null;
            txt_BarcodeSearch.EditValue = null;

            gC_PaymentLine.DataSource = null;
            Tag = null;
        }

        #endregion

        #region Open Form Invoice

        private void OpenFormInvoice(string strDocNum)
        {
            TrInvoiceHeader invoice = efMethods.SelectInvoiceHeaderByDocNum(strDocNum);
            if (invoice is null) return;

            string claim = CustomExtensions.GetClaim(invoice.ProcessCode);
            bool currAccHasClaims = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, claim);
            if (!currAccHasClaims)
            {
                XtraMessageBox.Show(Resources.Common_NoPermission);
                return;
            }

            FormERP? formERP = Application.OpenForms[nameof(FormERP)] as FormERP;
            if (formERP == null) return;

            Guid formInstanceId = Guid.NewGuid();
            byte[] bytes = CustomExtensions.GetProductTypeArray(invoice.ProcessCode);

            if (TryAcquireInvoiceLockForEdit(invoice.InvoiceHeaderId, formERP, formInstanceId))
            {
                FormInvoice frm = new(invoice.ProcessCode, null, bytes, null, invoice.InvoiceHeaderId);
                frm._formInstanceId = formInstanceId;
                frm.MdiParent = formERP;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();

                if (formERP.parentRibbonControl?.MergedPages?.Count > 0)
                    formERP.parentRibbonControl.SelectedPage = formERP.parentRibbonControl.MergedPages[0];
            }
        }

        private bool TryActivateOpenInvoiceWindow(Guid invoiceHeaderId, FormERP formERP)
        {
            if (formERP == null) return false;

            foreach (Form child in formERP.MdiChildren)
            {
                if (child is FormInvoice frm &&
                    frm.trInvoiceHeader is not null &&
                    frm.trInvoiceHeader.InvoiceHeaderId == invoiceHeaderId)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                        frm.WindowState = FormWindowState.Normal;

                    frm.BringToFront();
                    frm.Activate();
                    return true;
                }
            }
            return false;
        }

        private bool TryAcquireInvoiceLockForEdit(Guid invoiceHeaderId, FormERP formERP, Guid formInstanceId)
        {
            if (formERP == null) return false;

            var res = _lockService.TryAcquireLock(
                documentType: "Invoice",
                documentId: invoiceHeaderId,
                userId: Authorization.CurrAccCode,
                machineName: Environment.MachineName,
                appInstanceId: formERP._appInstanceId,
                formInstanceId: formInstanceId,
                clientProcessId: Process.GetCurrentProcess().Id,
                timeout: TimeSpan.FromMinutes(10),
                reason: "Edit invoice");

            if (!res.Acquired)
            {
                if (res.LockedBy == Authorization.CurrAccCode &&
                    res.AppInstanceId == formERP._appInstanceId)
                {
                    if (TryActivateOpenInvoiceWindow(invoiceHeaderId, formERP))
                        return false;
                }

                bool canTakeover = efMethods.CurrAccHasClaims(Authorization.CurrAccCode, "DocumentLockTakeover");
                if (canTakeover)
                {
                    var answer = XtraMessageBox.Show(
                        string.Format(Resources.Form_Invoice_LockTakeoverQuestion, res.LockedByName),
                        Resources.Form_Invoice_LockTakeoverCaption,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (answer == DialogResult.Yes)
                    {
                        var takeoverRes = _lockService.ForceTakeoverLock(
                            documentType: "Invoice",
                            documentId: invoiceHeaderId,
                            newUserId: Authorization.CurrAccCode,
                            machineName: Environment.MachineName,
                            appInstanceId: formERP._appInstanceId,
                            formInstanceId: formInstanceId,
                            clientProcessId: Process.GetCurrentProcess().Id,
                            reason: "Force takeover by authorized user");

                        if (takeoverRes.Acquired)
                            return true;
                    }
                    return false;
                }

                DialogResult closeAnswer = XtraMessageBox.Show(
                    $"Faktura hazırda {res.LockedByName} tərəfindən redaktə olunur.\n" +
                    $"Machine: {res.MachineName}\n" +
                    $"LockedAt: {res.LockedAtUtc:yyyy-MM-dd HH:mm:ss} (UTC)\n" +
                    $"Heartbeat: {res.LastHeartbeatAtUtc:yyyy-MM-dd HH:mm:ss} (UTC)\n\n" +
                    $"Sənəd sahibinə bağlama sorğusu göndərilsin?",
                    "Sənəd lock olunub",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (closeAnswer == DialogResult.Yes)
                {
                    _lockService.RequestOwnerToClose(
                        documentType: "Invoice",
                        documentId: invoiceHeaderId,
                        requestedByUserId: Authorization.CurrAccCode,
                        note: "Another user wants to edit this invoice.");
                }
                return false;
            }
            return true;
        }

        #endregion
    }
}
