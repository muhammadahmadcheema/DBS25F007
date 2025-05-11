using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using DBProjectBackend.DL;

namespace DBProjectBackend.BL
{
    public class Student : User
    {
        private int StudentID;
        private string RegistrationNo;
        private bool Hostellite;
        private float CGPA;
        private int SessionYear;
        private string Nationality;
        private string EnrollmentDate;
        private int StdUserID;
        private string SessionTerm;
        private int StudentDeptID;

        public Student() { }

        public Student(string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Role, string Name, string RegistrationNo, bool Hostellite, float CGPA, int SessionYear, string Nationality, string EnrollmentDate, string SessionTerm, int studentDeptID) : base(Password, CNIC, Username, Email, DOB, Phone, Role, Name)
        {
            this.RegistrationNo = RegistrationNo;
            this.Hostellite = Hostellite;
            SetCGPA(CGPA);
            this.SessionYear = SessionYear;
            this.Nationality = Nationality;
            this.EnrollmentDate = EnrollmentDate;
            this.SessionTerm = SessionTerm;
            this.StudentDeptID = studentDeptID;
        }

        public Student(int userID, string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Name, string RegistrationNo, bool Hostellite, float CGPA, int SessionYear, string Nationality, string EnrollmentDate, string SessionTerm, int studentDeptID) : base(userID, Password, CNIC, Username, Email, DOB, Phone,Name)
        {
            this.StdUserID = userID;
            this.RegistrationNo = RegistrationNo;
            this.Hostellite = Hostellite;
            SetCGPA(CGPA);
            this.SessionYear = SessionYear;
            this.Nationality = Nationality;
            this.EnrollmentDate = EnrollmentDate;
            this.SessionTerm = SessionTerm;
            this.StudentDeptID = studentDeptID;
        }

        public bool AddStudent(Student s)
        {
            BL.User bl = new BL.User();
            bool flag1 = bl.AddUser(s.GetPasswordHash(), s.GetCNIC(), s.GetUsername(), s.GetEmail(), s.GetDOB(), s.GetPhone(), s.GetRole(), s.GetName());
            DL.User dl1 = new DL.User();
            int userID = (int)dl1.GetUserIDFromDB(s.GetUsername(), s.GetPasswordHash());
            s.SetUserID(userID);

            if (flag1)
            {
                DL.Student dl = new DL.Student();
                bool flag2 = dl.AddStudentToDB(s);
                return flag2;
            }
            return false;
        }

        public DataTable GetStudents()
        {
            DL.Student dl = new DL.Student();
            return dl.GetAllStudents();
        }
      
        public bool UpdateStudent(Student s)
        {
            BL.User bl = new BL.User();
            bool flag1 = bl.UpdateUser(s.GetUserID(), s.GetPasswordHash(), s.GetCNIC(), s.GetUsername(), s.GetEmail(), s.GetDOB(), s.GetPhone(), s.GetName());
            if (flag1)
            {
                DL.Student dl = new DL.Student();
                bool flag2 = dl.UpdateStudentInDB(s);
                return flag2;
            }
            return false;
        }


        public bool DeleteStudent(int facultyid, int userid)
        {
            DL.Student dl = new DL.Student();
            return dl.DeleteStudentFromDB(facultyid, userid);

        }
        public int GetStudentIDByUserID(int userID)
        {
            DL.Student dl = new DL.Student();
            return dl.GetStudentIDFromDB(userID);
        }

        public int GetStudentID()
        {
            return this.StudentID;
        }

        public string GetRegistrationNo()
        {
            return this.RegistrationNo;
        }

        public bool GetHostellite()
        {
            return this.Hostellite;
        }

        public float GetCGPA()
        {
            return this.CGPA;
        }

        public int GetSessionYear()
        {
            return SessionYear;
        }

        public string GetSessionTerm()
        {
            return SessionTerm;
        }

        public void SetSessionYear(int SessionYear)
        {
            this.SessionYear = SessionYear;
        }

        public string GetNationality()
        {
            return this.Nationality;
        }

        public string GetEnrollmentDate()
        {
            return this.EnrollmentDate;
        }

        public void SetStudentID(int id)
        {
            this.StudentID = id;
        }

        public void SetRegistrationNo(string reg)
        {
            this.RegistrationNo = reg;
        }

        public void SetHostellite(bool hostel)
        {
            this.Hostellite = hostel;
        }

        public override List<object> GetUserNames()
        {
            DL.Student dl = new DL.Student();
            List<object> userNames = dl.GetStudentUserNamesFromDB();
            return userNames;
        }

        public void SetCGPA(float cgpa)
        {
            if (cgpa < 0 && cgpa > 4)
            {
                throw new ArgumentException("CGPA must be in range of [0,4]");
            }
            this.CGPA = cgpa;
        }

        public void SetSessionTerm(string sessionTerm)
        {
            this.SessionTerm = sessionTerm;
        }

        public void SetNationality(string nationality)
        {
            this.Nationality = nationality;
        }

        public void SetUserID(int userID)
        {
            this.StdUserID = userID;
        }

        public int GetStdUserID()
        {
            return this.StdUserID;
        }

        public int GetStudentDeptID()
        {
            return StudentDeptID;
        }

        public void SetStudentDeptID(int stdDeptID)
        {
            this.StudentDeptID = stdDeptID;
        }

        public int GetDepartmentID(int userID)
        {
            DL.Student dl = new DL.Student();
            return dl.GetStudentDepartmentIDFromDB(userID);
        }

        public int GetStudentID(int userID)
        {
            DL.Student dl = new DL.Student();
            return dl.GetStudentIDFromDB(userID);
        }

    }

}

