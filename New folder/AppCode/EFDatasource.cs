using DevExpress.DataAccess.EntityFramework;
using Foxoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxoft
{
    static class EFDatasource
    {
        public static object Exevute()
        {
            var efDataSource = new EFDataSource();

            var efConnectionParameters = new EFConnectionParameters()
            {
                Source = typeof(subContext),
                ConnectionStringName = "efConString"                
            };

            efDataSource.ConnectionParameters = efConnectionParameters;

            //var FilteredCollectionName = "Products";
            //var productsFilter = new DBSetFilter()
            //{
            //    DBSetName = FilteredCollectionName,
            //    FilterString = "[UnitPrice] < ?EfParamPrice"
            //};

            //efDataSource.Filters.Add(productsFilter);

            // Pass the report's parameter to the database filter.
            //var efParamPrice = new EFParameter()
            //{
            //    Name = "EfParamPrice",
            //    Type = typeof(DevExpress.DataAccess.Expression),
            //    Value = new DevExpress.DataAccess.Expression("?reportParamPrice", typeof(int))
            //};

            //productsFilter.Parameters.Add(efParamPrice);

            // Create a report instance and configure its
            // DataSource and DataMember properties.
            //var report = new XtraReport1();
            //report.DataSource = efDataSource;
            return efDataSource;
            //report.DataMember = FilteredCollectionName;

            // Optionally, set up the report's parameters and disable
            // the RequestParameters property to apply the default
            // parameter values to the report when you show its preview.
            //report.Parameters["reportParamPrice"].Value = 10;
            //report.RequestParameters = false;
        }
    }
}
