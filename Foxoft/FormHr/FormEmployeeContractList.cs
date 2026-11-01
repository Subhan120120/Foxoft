using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormEmployeeContractList : RibbonForm
    {
        private readonly subContext db = new();

        public FormEmployeeContractList()
        {
            InitializeComponent();
            Load += (_, __) => LoadData();

            btnNew.ItemClick += (_, __) => NewItem();
            btnEdit.ItemClick += (_, __) => EditItem();
            btnAddAddendum.ItemClick += (_, __) => AddAddendum();
            btnDelete.ItemClick += (_, __) => DeleteItem();
            btnRefresh.ItemClick += (_, __) => LoadData();
            btnClose.ItemClick += (_, __) => Close();

            gridView1.DoubleClick += (_, __) => EditItem();
            gridView1.CustomDrawRowIndicator += (s, e) =>
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            };
        }

        private void LoadData()
        {
            var list = db.TrEmployeeContracts.AsNoTracking()
                .Include(x => x.DcCurrAcc)
                .Include(x => x.EmploymentType)
                .Include(x => x.Addenda)
                .OrderBy(x => x.CurrAccCode)
                .Select(x => new
                {
                    x.Id,
                    x.ContractNumber,
                    x.CurrAccCode,
                    EmployeeName = (!string.IsNullOrEmpty(x.DcCurrAcc.CurrAccDesc)
                        ? x.DcCurrAcc.CurrAccDesc
                        : ((x.DcCurrAcc.FirstName ?? "") + " " + (x.DcCurrAcc.LastName ?? "")).Trim()),
                    EmploymentTypeName = x.EmploymentType != null ? x.EmploymentType.TypeName : "",
                    x.StartDate,
                    x.EndDate,
                    CurrentSalary = x.Addenda.OrderByDescending(a => a.StartDate).Select(a => (decimal?)a.BaseSalary).FirstOrDefault() ?? 0,
                    CurrencyCode = x.Addenda.OrderByDescending(a => a.StartDate).Select(a => a.CurrencyCode).FirstOrDefault() ?? "AZN",
                    AddendumCount = x.Addenda.Count
                })
                .ToList();

            gridControl1.DataSource = list;

            if (gridView1.Columns["Id"] != null) gridView1.Columns["Id"].Visible = false;
            if (gridView1.Columns["ContractNumber"] != null) gridView1.Columns["ContractNumber"].Caption = Properties.Resources.Entity_TrEmployeeContract_ContractNumber;
            if (gridView1.Columns["CurrAccCode"] != null) gridView1.Columns["CurrAccCode"].Caption = Properties.Resources.Entity_TrEmployeeContract_CurrAccCode;
            if (gridView1.Columns["EmployeeName"] != null) gridView1.Columns["EmployeeName"].Caption = Properties.Resources.Common_EmployeeName;
            if (gridView1.Columns["EmploymentTypeName"] != null) gridView1.Columns["EmploymentTypeName"].Caption = Properties.Resources.Entity_TrEmployeeContract_EmploymentTypeId;
            if (gridView1.Columns["StartDate"] != null) gridView1.Columns["StartDate"].Caption = Properties.Resources.Entity_TrEmployeeContract_StartDate;
            if (gridView1.Columns["EndDate"] != null) gridView1.Columns["EndDate"].Caption = Properties.Resources.Entity_TrEmployeeContract_EndDate;
            if (gridView1.Columns["CurrentSalary"] != null) gridView1.Columns["CurrentSalary"].Caption = Properties.Resources.Form_EmployeeContractList_CurrentSalary;
            if (gridView1.Columns["CurrencyCode"] != null) gridView1.Columns["CurrencyCode"].Caption = Properties.Resources.Entity_TrEmployeeContract_CurrencyCode;
            if (gridView1.Columns["AddendumCount"] != null) gridView1.Columns["AddendumCount"].Caption = Properties.Resources.Form_EmployeeContractList_AddendumCount;

            gridView1.BestFitColumns();
        }

        public Guid? FocusedId()
        {
            var row = gridView1.GetFocusedRow();
            if (row == null) return null;
            var prop = row.GetType().GetProperty("Id");
            return prop == null ? null : (Guid?)prop.GetValue(row);
        }

        private void NewItem()
        {
            using var f = new FormEmployeeContractEdit(null);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void EditItem()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormEmployeeContractEdit(id.Value);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void AddAddendum()
        {
            var id = FocusedId();
            if (id == null) return;

            using var f = new FormEmployeeContractAddendumEdit(id.Value, null);
            if (f.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void DeleteItem()
        {
            var id = FocusedId();
            if (id == null) return;

            if (XtraMessageBox.Show(this, Properties.Resources.Form_EmployeeContractList_DeleteConfirm, Properties.Resources.Common_Confirm,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var entity = db.TrEmployeeContracts.Find(id.Value);
            if (entity != null)
            {
                db.TrEmployeeContracts.Remove(entity);
                db.SaveChanges();
                LoadData();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            db.Dispose();
        }
    }
}
