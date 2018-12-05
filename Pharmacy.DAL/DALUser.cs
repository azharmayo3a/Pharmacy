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
    public class DALUser
    {
        public DataSet User_Login(string userID, string password)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("User_Login");
            db.AddInParameter(command, "UserID", DbType.String, userID);
            db.AddInParameter(command, "Password", DbType.String, password);
            return db.ExecuteDataSet(command);
        }

        public DataSet User_GetLoginDetails(string email)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("User_GetLoginDetails");
            db.AddInParameter(command, "Email", DbType.String, email);
            return db.ExecuteDataSet(command);
        }

        public void ErrorLog_Add(string errorDetail)
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("ErrorLog_Add");
            db.AddInParameter(command, "ErrorDetail", DbType.String, errorDetail);
            db.ExecuteNonQuery(command);
        }
    }
}
