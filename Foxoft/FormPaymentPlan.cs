using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Properties;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Foxoft
{
    public partial class FormPaymentPlan : XtraForm
    {
        subContext dbContext;
        EfMethods efMethods = new();
        public DcPaymentPlan dcPaymentPlan = new();

        public FormPaymentPlan()
        {
            InitializeComponent();

            PaymentMethodIdLookUpEdit.Properties.DataSource = efMethods.SelectEntities<DcPaymentMethod>();

            AcceptButton = btn_Ok;
            CancelButton = btn_Cancel;
        }

        public FormPaymentPlan(string paymentPlanCode)
            : this()
        {
            dcPaymentPlan.PaymentPlanCode = paymentPlanCode;

            PaymentPlanCodeTextEdit.Properties.ReadOnly = true;
            PaymentPlanCodeTextEdit.Properties.Appearance.BackColor = Color.LightGray;
        }

        private void FormPaymentPlan_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadLayout();
            dataLayoutControl1.IsValid(out List<string> errorList);
        }

        private void LoadData()
        {
            dbContext = new subContext();

            if (string.IsNullOrEmpty(dcPaymentPlan.PaymentPlanCode))
                ClearControlsAddNew();
            else
            {
                dbContext.DcPaymentPlans.Where(x => x.PaymentPlanCode == dcPaymentPlan.PaymentPlanCode).Load();
                dcPaymentPlansBindingSource.DataSource = dbContext.DcPaymentPlans.Local.ToBindingList();
            }
        }

        private void LoadLayout()
        {
            string fileName = "FormPaymentPlan.xml";
            string layoutFilePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "Foxoft",
                Settings.Default.CompanyCode,
                "Layout Xml Files",
                fileName);

            if (File.Exists(layoutFilePath))
                dataLayoutControl1.RestoreLayoutFromXml(layoutFilePath);
        }

        private void ClearControlsAddNew()
        {
            dcPaymentPlan = dcPaymentPlansBindingSource.AddNew() as DcPaymentPlan;

            string newDocNum = efMethods.GetNextDocNum(true, "PP", nameof(DcPaymentPlan.PaymentPlanCode), nameof(subContext.DcPaymentPlans), 4);
            dcPaymentPlan.PaymentPlanCode = newDocNum;

            dcPaymentPlansBindingSource.DataSource = dcPaymentPlan;
            PaymentPlanDescTextEdit.Select();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (dataLayoutControl1.IsValid(out List<string> errorList))
            {
                dcPaymentPlan = dcPaymentPlansBindingSource.Current as DcPaymentPlan;

                if (!efMethods.EntityExists<DcPaymentPlan>(dcPaymentPlan.PaymentPlanCode))
                    efMethods.InsertEntity(dcPaymentPlan);
                else
                    dbContext.SaveChanges();

                DialogResult = DialogResult.OK;
            }
            else
            {
                string combined = errorList.Aggregate((x, y) => x + "" + y);
                XtraMessageBox.Show(combined);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
