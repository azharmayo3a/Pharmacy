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
    public class DALCategory
    {
        public void Category_Add(Categories c)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Category_Add");
            db.AddInParameter(command, "CategoryName", DbType.String, c.CategoryName);
            db.ExecuteNonQuery(command);
        }

        public void Category_Update(Categories c)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Category_Update");
            db.AddInParameter(command, "CategoryCode", DbType.Int32, c.CategoryCode);
            db.AddInParameter(command, "CategoryName", DbType.String, c.CategoryName);
            db.ExecuteNonQuery(command);
        }

        public DataSet Category_GetDetail(int categoryCode)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Category_GetDetail");
            db.AddInParameter(command, "CategoryCode", DbType.Int32, categoryCode);
            return db.ExecuteDataSet(command);
        }
        public void Category_Delete(int categoryCode)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Category_Delete");
            db.AddInParameter(command, "CategoryCode", DbType.Int32, categoryCode);
            db.ExecuteNonQuery(command);
        }

        public DataSet Category_GetList()
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Category_GetList");
            return db.ExecuteDataSet(command);
        }
    }
}
