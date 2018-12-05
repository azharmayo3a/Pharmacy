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
    public class DALReport
    {
        public DataSet Sale_Get()
        {
            Database db = DatabaseFactory.CreateDatabase("ABC");
            DbCommand command = db.GetStoredProcCommand("Rpt_Sale_Get");
            return db.ExecuteDataSet(command);
        }
    }
}
