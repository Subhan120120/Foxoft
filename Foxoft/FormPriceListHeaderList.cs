using DevExpress.Data.Linq.Helpers;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Foxoft.Models;
using Foxoft.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxoft
{
    public partial class FormPriceListHeaderList : XtraForm
    {
        EfMethods efMethods = new();
        public TrPriceListHeader trPriceListHeader { get; set; }
        subContext dbContext;

        public FormPriceListHeaderList()
        {
            InitializeComponent();

            byte[] byteArray = Encoding.ASCII.GetBytes(Settings.Default.AppSetting.GridViewLayout);
            MemoryStream stream = new(byteArray);
            OptionsLayoutGrid option = new() { StoreAllOptions = true, StoreAppearance = true };
            gridView1.RestoreLayoutFromStream(stream, option);

            //gridView1.OptionsFind.FindMode = FindMode.Always;

            LoadPriceListHeaders();

            gridView1.BestFitColumns();
        }

        private void LoadPriceListHeaders()
        {
            dbContext = new subContext();

            IList<TrPriceListHeader> trPriceListHeaders = dbContext.TrPriceListHeaders
                        .OrderByDescending(x => x.DocumentDate).ThenByDescending(x => x.DocumentTime)
                        .ToList();

            trPriceListBindingSource.DataSource = trPriceListHeaders;
        }

    }
}
