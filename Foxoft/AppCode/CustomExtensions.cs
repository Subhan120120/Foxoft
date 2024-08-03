using DevExpress.Xpo;
using DevExpress.XtraDataLayout;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Foxoft
{
    public static class CustomExtensions
    {
        public static bool IsValid(this DataLayoutControl dataLayoutControl, out List<string> errorList)
        {
            DXErrorProvider dXErrorProvider = new DXErrorProvider();

            List<string> list = new List<string>();

            foreach (Control ctrl in dataLayoutControl.Controls)
            {
                BaseEdit edit = ctrl as BaseEdit;
                if (edit != null)
                {
                    edit.IsModified = true;
                    edit.DoValidate();
                    if (edit.ErrorText != string.Empty)
                        list.Add(edit.ErrorText);
                }
            }
            errorList = list;
            if (list.Count == 0)
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

        public static string ProcessDir(string processCode)
        {
            switch (processCode)
            {
                case "RP": return "In";
                case "EX": return "In";
                case "EI": return "In";
                case "SB": return "In";
                case "CI": return "In";
                case "IT": return "Out";
                case "RS": return "Out";
                case "WS": return "Out";
                case "CO": return "Out";
                default: return "";
            }
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


    }

}