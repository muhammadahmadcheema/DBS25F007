using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBProjectBackend.DL;
namespace DBProjectBackend.BL
{
    public class TechnicalStaff : User
    {
        private int TechnicalStaffID;
        private string HireDate;
        private string Specialization;
        private int User_ID;

        public TechnicalStaff() { }

        public TechnicalStaff(string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Role, string Name, string HireDate, string Specialization) : base(Password, CNIC, Username, Email, DOB, Phone, Role, Name)
        {
            this.HireDate = HireDate;
            this.Specialization = Specialization;
        }

        public TechnicalStaff(int userID, string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Name, string HireDate, string Specialization) : base(userID, Password, CNIC, Username, Email, DOB, Phone, Name)
        {
            this.User_ID = userID;
            this.HireDate = HireDate;
            this.Specialization = Specialization;
        }
      
        public int GetTechnicalStaffID() { return TechnicalStaffID; }
        public string GetHireDate() { return HireDate; }
        public string GetSpecialization() { return Specialization; }
        public int GetUserID() { return User_ID; }

        public override List<object> GetUserNames()
        {
            DL.TechnicalStaff dl = new DL.TechnicalStaff();
            List<object> userNames = dl.GetTechnicalStaffUserNamesFromDB();
            return userNames;
        }

        public void SetTechnicalStaffID(int id) { this.TechnicalStaffID = id; }
        public void SetHireDate(string date) { this.HireDate = date; }
        public void SetSpecialization(string specialization) { this.Specialization = specialization; }
        public void SetUserID(int userId) { this.User_ID = userId; }



        public bool AddTechnicalStaff(BL.TechnicalStaff f)
        {
            BL.User bl = new BL.User();
            bool flag1 = bl.AddUser(f.GetPasswordHash(), f.GetCNIC(), f.GetUsername(), f.GetEmail(), f.GetDOB(), f.GetPhone(), f.GetRole(), f.GetName());
            DL.User dl1 = new DL.User();
            int userID = (int)dl1.GetUserIDFromDB(f.GetUsername(), f.GetPasswordHash());
            f.SetUserID(userID);
            if (flag1)
            {
                DL.TechnicalStaff dl = new DL.TechnicalStaff();
                bool flag2 = dl.AddToDB(f);
                return flag2;
            }
            return false;
        }

        public bool UpdateTechnicalStaff(TechnicalStaff ts)
        {
            BL.User bl = new BL.User();
            bool flag1 = bl.UpdateUser(ts.GetUserID(), ts.GetPasswordHash(), ts.GetCNIC(), ts.GetUsername(), ts.GetEmail(), ts.GetDOB(), ts.GetPhone(), ts.GetName());
            if (flag1)
            {
                DL.TechnicalStaff dl = new DL.TechnicalStaff();
                bool flag2 = dl.UpdateTechnicalStaffInDB(ts);
                return flag2;
            }
            return false;
        }

        public bool DeleteTechnicalStaff(int id)
        {
            DL.TechnicalStaff dl = new DL.TechnicalStaff();
            return dl.DeleteFromDB(id);
        }

        public DataTable GetAllTechnicalStaff()
        {
            DL.TechnicalStaff dl = new DL.TechnicalStaff();
            return dl.GetAllFromDB();
        }

        public DataTable GetTechnicalStaff()
        {
            DL.TechnicalStaff dl = new DL.TechnicalStaff();
            DataTable dt = dl.GetAllTechnicalStaff();
            return dt;
        }
    }
}
