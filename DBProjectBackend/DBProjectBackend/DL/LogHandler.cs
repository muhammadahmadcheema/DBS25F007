using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProjectBackend.DL
{
    class LogHandler
    {
        public List<object> GetLogHandlersUserNamesFromDB()
        {
            string query = "Select Username From RetrieveLogHandlers";
            query = String.Format(query, "TechnicalStaff");
            string columnName = "UserName";
            List<object> userNames = SqlHelper.GetColumnValues(query, columnName);
            return userNames;
        }
    }
}
