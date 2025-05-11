using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProjectBackend.BL
{
    public class LogHandler : TechnicalStaff
    {

        public LogHandler() : base() { }
        public LogHandler(string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Role, string Name, string HireDate, string Specialization) : base(Password, CNIC, Username, Email, DOB, Phone, Role, Name,HireDate,Specialization)
        {            
        }

        public LogHandler(int userID, string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Name, string HireDate, string Specialization) : base(userID, Password, CNIC, Username, Email, DOB, Phone, Name, HireDate, Specialization)
        {
            
        }

        public override List<object> GetUserNames()
        {
            // Implement the specific behavior for this type of technical staff
            DL.LogHandler dl = new DL.LogHandler();
            List<object> userNames = dl.GetLogHandlersUserNamesFromDB();
            return userNames;
        }


    }
}
