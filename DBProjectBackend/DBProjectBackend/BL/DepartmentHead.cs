using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBProjectBackend.DL;

namespace DBProjectBackend.BL
{
    public class DepartmentHead : Faculty
    {
        private int DepartmentHeadID;        
        private string AppointmentEndDate;
        private int DepartmentID;
        private int FacultyID;

        public DepartmentHead() { }

        public DepartmentHead(string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Role, string Name, string Designation, string ResearchArea, int MaxWorkingHours, string Qualification, int FacultyDeptID,string AppointmentEndDate) : base(Password, CNIC, Username, Email, DOB, Phone, Role, Name, Designation, ResearchArea, MaxWorkingHours, Qualification, FacultyDeptID)
        {
            this.AppointmentEndDate = AppointmentEndDate;
            this.DepartmentID = FacultyDeptID;
        }
        
        public DepartmentHead(int userID, string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Name, string Designation, string ResearchArea, int MaxWorkingHours, string Qualification, int FacultyDeptID,string AppointmentEndDate) : base(userID, Password, CNIC, Username, Email, DOB, Phone, Name,Designation, ResearchArea, MaxWorkingHours, Qualification, FacultyDeptID)
        {             
            this.AppointmentEndDate = AppointmentEndDate;
            this.DepartmentID = FacultyDeptID;
        }


        public bool AddDepartmentHead(DepartmentHead f)
        {           
            DL.DepartmentHead dl = new DL.DepartmentHead();
            return dl.AddDepartmentHeadToDB(f.GetPasswordHash(), f.GetCNIC(), f.GetUsername(), f.GetEmail(), f.GetDOB(), f.GetPhone(), f.GetRole(), f.GetName(), f.GetDesignation(), f.GetResearchArea(), f.GetMaxWorkingHours(), f.GetQualification(), f.GetFacultyDeptID(), f.GetAppointmentEndDate(), f.GetDepartmentID());

        }

        public DataTable GetDepartmentHeads()
        {
            DL.DepartmentHead dl = new DL.DepartmentHead();
            return dl.GetAllDepartmentHeads();
        }

        public bool UpdateDepartmentHead(DepartmentHead f)
        {
            BL.User bl = new BL.User();
            bool flag1 = bl.UpdateUser(f.GetUserID(), f.GetPasswordHash(), f.GetCNIC(), f.GetUsername(), f.GetEmail(), f.GetDOB(), f.GetPhone(), f.GetName());
            if (flag1)
            {
                DL.Faculty dl = new DL.Faculty();
                bool flag2 = dl.UpdateFacultytoDB(f);
                if (flag2)
                {
                    BL.Faculty faculty = new BL.Faculty();
                    int facultyID = faculty.GetFacultyID(f.GetUsername());
                    f.SetFacultyID(facultyID);
                    DL.DepartmentHead dh = new DL.DepartmentHead();
                    return dh.UpdateDepartmentHeadInDB(f);
                }
            }
            return false;            
        }

        public DataTable GetDepartmentHead()
        {
            DL.DepartmentHead dl = new DL.DepartmentHead();
            DataTable dt = dl.GetAllDepartmentHead();
            return dt;
        }

        public bool DeleteDepartmentHead(int id)
        {
            DL.DepartmentHead dl = new DL.DepartmentHead();
            return dl.DeleteDepartmentHeadFromDB(id);
        }


        public int GetDepartmentHeadID()
        {
            return DepartmentHeadID;
        }

       

        public string GetAppointmentEndDate()
        {
            return AppointmentEndDate;
        }

        public int GetDepartmentID()
        {
            return DepartmentID;
        }


        public void SetDepartmentHeadID(int id)
        {
            this.DepartmentHeadID = id;
        }
        

        public void SetAppointmentEndDate(string date)
        {
            this.AppointmentEndDate = date;
        }

        public void SetDepartmentID(int id)
        {
            this.DepartmentID = id;
        }

        public void SetFacultyID(int facultyID)
        {
            this.FacultyID = facultyID;
        }

        public override int GetFacultyID()
        {
            return FacultyID;
        }

        public override List<object> GetUserNames()
        {
            DL.DepartmentHead dl = new DL.DepartmentHead();
            List<object> userNames = dl.GetDepartmentHeadNamesFromDB();
            return userNames;
        }

    }
}

