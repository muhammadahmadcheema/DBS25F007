using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Security;

namespace DBProjectBackend.BL
{
    public class Faculty : User
    {
        private int FacultyID;
        private string Designation;
        private string ResearchArea;
        private int MaxWorkingHours;
        private string Qualification;
        private int FacultyDeptID;
        private int FacultyUserID;

        public Faculty(){}

        public Faculty(string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Role, string Name, string Designation, string ResearchArea, int MaxWorkingHours, string Qualification, int FacultyDeptID) : base(Password, CNIC, Username, Email, DOB, Phone, Role, Name)
        {
            this.Designation = Designation;
            this.ResearchArea = ResearchArea;
            SetMaxWorkingHours(MaxWorkingHours);
            SetQualification(Qualification);
            this.FacultyDeptID = FacultyDeptID;
        }

        public Faculty(int userID, string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Name, string Designation, string ResearchArea, int MaxWorkingHours, string Qualification, int FacultyDeptID) : base(userID, Password, CNIC, Username, Email, DOB, Phone, Name)
        {
            this.FacultyUserID = userID;
            this.Designation = Designation;
            this.ResearchArea = ResearchArea;
            SetMaxWorkingHours(MaxWorkingHours);
            SetQualification(Qualification);
            this.FacultyDeptID = FacultyDeptID;
        }



        public bool AddFaculty(BL.Faculty f)
        {
            BL.User bl = new BL.User();
            bool flag1 = bl.AddUser(f.GetPasswordHash(), f.GetCNIC(), f.GetUsername(), f.GetEmail(), f.GetDOB(), f.GetPhone(), f.GetRole(), f.GetName());
            DL.User dl1 = new DL.User();
            int userID = (int)dl1.GetUserIDFromDB(f.GetUsername(), f.GetPasswordHash());
            f.SetUserID(userID);
            if (flag1)
            {
                DL.Faculty dl = new DL.Faculty();
                bool flag2 = dl.AddFacultytoDB(f);
                return flag2;
            }
            return false;
        }

        public bool UpdateFaculty(BL.Faculty f)
        {
            BL.User bl = new BL.User();
            bool flag1 = bl.UpdateUser(f.GetUserID(), f.GetPasswordHash(), f.GetCNIC(), f.GetUsername(), f.GetEmail(), f.GetDOB(), f.GetPhone(), f.GetName());
            if (flag1)
            {
                DL.Faculty dl = new DL.Faculty();
                bool flag2 = dl.UpdateFacultytoDB(f);
                return flag2;
            }
            return false;
        }

        
        public bool DeleteFaculty(int facultyId, int userId)
        {
            DL.Faculty dl = new DL.Faculty();
            bool flag1 = dl.DeleteFacultyFromDB(facultyId, userId);
            return true;
        }

        public DataTable GetFaculty()
        {
            DL.Faculty dl = new DL.Faculty();
            DataTable dt = dl.GetAllFaculty();
            return dt;
        }

        public int GetFacultyID(string facultyUserName)
        {
            DL.Faculty dl = new DL.Faculty();
            return dl.GetFacultyIDFromDB(facultyUserName);
            
        }


        public void SetQualification(string Qualification)
        {
            if (string.IsNullOrWhiteSpace(Qualification))
            {
                throw new ArgumentException("Qualification cannot be empty.");
            }

            this.Qualification = Qualification;
        }

        public void SetMaxWorkingHours(int MaxWorkingHours)
        {
            if (MaxWorkingHours < 0 && MaxWorkingHours > 70)
            {
                throw new ArgumentException("Max Working Hours cannot be negative or greater than 70");
            }

            this.MaxWorkingHours = MaxWorkingHours;
        }


        public virtual int GetFacultyID()
        {
            return FacultyID;
        }

        public string GetDesignation()
        {
            return Designation;
        }

        public string GetResearchArea()
        {
            return ResearchArea;
        }

        public int GetMaxWorkingHours()
        {
            return MaxWorkingHours;
        }

        public string GetQualification()
        {
            return Qualification;
        }

        public int GetFacultyDeptID()
        {
            return FacultyDeptID;
        }

        public int GetFacultyUserID()
        {
            return FacultyUserID;
        }

        public void SetUserID(int userId)
        {
            this.FacultyUserID = userId;
        }

        public override List<object> GetUserNames()
        {
            DL.Faculty dl = new DL.Faculty();
            List<object> userNames = dl.GetFacultyUserNamesFromDB();
            return userNames;
        }        

    }
}
