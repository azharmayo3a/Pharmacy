using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Pharmacy.Entities;

namespace Pharmacy.DAL
{
    public class DALSaleInvoice
    {
        public DataSet SaleInvoice_Add_Load()
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("SaleInvoice_Add_Load");
            return db.ExecuteDataSet(command);
        }

        public int SaleInvoice_Add(SaleInvoice s)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("SaleInvoice_Add");
            db.AddOutParameter(command, "SaleInvoiceCode", DbType.Int32, -1);
            db.AddInParameter(command, "CustomerName", DbType.String, s.CustomerName);
            db.AddInParameter(command, "InvoiceDate", DbType.DateTime, s.InvoiceDate);
            db.AddInParameter(command, "GrandTotal", DbType.Decimal, s.GrandTotal);
            db.ExecuteNonQuery(command);
            return Convert.ToInt32(db.GetParameterValue(command, "SaleInvoiceCode"));
        }

        public void SaleInvoice_AddDetail(SaleInvoiceDetail s)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("SaleInvoice_AddDetail");
            db.AddInParameter(command, "SaleInvoiceCode", DbType.Int32, s.SaleInvoiceCode);
            db.AddInParameter(command, "ProductCode", DbType.Int32, s.ProductCode);
            db.AddInParameter(command, "Qty", DbType.Int32, s.Qty);
            db.AddInParameter(command, "Rate", DbType.Decimal, s.Rate);
            db.AddInParameter(command, "Total", DbType.Decimal, s.Total);
            db.ExecuteNonQuery(command);
        }
    }
}
