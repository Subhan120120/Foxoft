using DevExpress.XtraEditors;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Windows.Forms;

namespace Foxoft
{
    /// <summary>Bonus əməliyyatının hesablama detallarını (CalcDetails JSON) oxunaqlı şəkildə göstərir.</summary>
    public partial class FormSalesBonusTxnDetails : XtraForm
    {
        private static readonly JsonSerializerOptions PrettyOptions = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public FormSalesBonusTxnDetails(string? note, string? calcDetails)
        {
            InitializeComponent();

            txtNote.Text = note;
            memoDetails.Text = Pretty(calcDetails);

            btnClose.Click += (_, __) => Close();
            CancelButton = btnClose;
        }

        private static string Pretty(string? json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return string.Empty;

            try
            {
                using JsonDocument doc = JsonDocument.Parse(json);
                return JsonSerializer.Serialize(doc.RootElement, PrettyOptions);
            }
            catch (Exception)
            {
                return json;
            }
        }
    }
}
