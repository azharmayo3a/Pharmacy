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
    public class DALProduct
    {
        public void Product_Add(Products c)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Product_Add");
            db.AddInParameter(command, "CategoryCode", DbType.Int32, c.CategoryCode);
            db.AddInParameter(command, "ProductName", DbType.String, c.ProductName);
            db.AddInParameter(command, "PurchaseRate", DbType.Decimal, c.PurchaseRate);
            db.AddInParameter(command, "SaleRate", DbType.Decimal, c.SaleRate);
            db.AddInParameter(command, "ExpiryDate", DbType.DateTime, c.ExpiryDate);
            db.AddInParameter(command, "ImageURL", DbType.String, c.ImageURL);
            db.ExecuteNonQuery(command);
        }

        public void Product_Update(Products c)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Product_Update");
            db.AddInParameter(command, "ProductCode", DbType.Int32, c.ProductCode);
            db.AddInParameter(command, "CategoryCode", DbType.Int32, c.CategoryCode);
            db.AddInParameter(command, "ProductName", DbType.String, c.ProductName);
            db.AddInParameter(command, "PurchaseRate", DbType.Decimal, c.PurchaseRate);
            db.AddInParameter(command, "SaleRate", DbType.Decimal, c.SaleRate);
            db.AddInParameter(command, "ExpiryDate", DbType.DateTime, c.ExpiryDate);
            db.ExecuteNonQuery(command);
        }

        public DataSet Product_Add_Load()
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Product_Add_Load");
            return db.ExecuteDataSet(command);
        }

        public DataSet ProductList_Load()
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("ProductList_Load");
            return db.ExecuteDataSet(command);
        }

        public DataSet Product_GetList(int categoryCode)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Product_GetList");
            db.AddInParameter(command, "CategoryCode", DbType.Int32, categoryCode);
            return db.ExecuteDataSet(command);
        }

        public void Product_Delete(int productCode)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Product_Delete");
            db.AddInParameter(command, "ProductCode", DbType.Int32, productCode);
            db.ExecuteNonQuery(command);
        }

        public DataSet Product_GetDetail(int productCode)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Product_GetDetail");
            db.AddInParameter(command, "ProductCode", DbType.Int32, productCode);
            return db.ExecuteDataSet(command);
        }
    }
}
