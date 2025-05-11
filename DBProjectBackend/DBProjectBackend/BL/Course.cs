using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace DBProjectBackend.BL
{
    public class Course
    {
        private int CourseID;
        private string Name;
        private int CreditHours;
        private string Type;
        private int Fee;
        private int DepartmentID;
        private int? PrerequisiteCourseID;

        public Course() { }

        public Course(string Name, int CreditHours, string Type, int Fee, int DepartmentID, int? PreRequisiteCourseID) //Will be Used For Adding
        {            
            this.Name = Name;
            this.CreditHours = CreditHours;
            this.Type = Type;
            this.Fee = Fee;
            this.DepartmentID = DepartmentID;
            this.PrerequisiteCourseID = PreRequisiteCourseID;
        }

        public Course(int CourseID,string Name, int CreditHours, string Type, int Fee, int? PreRequisiteCourseID)  //Will be used for Updating
        {
            this.CourseID = CourseID;
            this.Name = Name;
            this.CreditHours = CreditHours;
            this.Type = Type;
            this.Fee = Fee; 
            this.PrerequisiteCourseID = PreRequisiteCourseID;
        }

        public int? GetPrerequisiteCourseID(string CourseName)
        {
            DL.Course dl = new DL.Course();
            return dl.GetPrerequisiteCourseIDFromDB(CourseName);
        }

        

        public bool AddCourse(BL.Course c)
        {
            DL.Course dl = new DL.Course();
            bool flag = dl.AddCoursetoDB(c);
            return flag;
        }

        public DataTable GetCourses()
        {
            DL.Course dl = new DL.Course();
            DataTable dt = dl.GetAllCoursesFromDB();
            return dt;
        }

        public bool UpdateCourse(BL.Course c)
        {
            DL.Course dl = new DL.Course();
            bool flag = dl.UpdateCoursetoDB(c);
            return flag;
        }

        public bool DeleteCourse(int CourseId)
        {
            DL.Course dl = new DL.Course();
            bool flag = dl.DeleteCourseFromDB(CourseId);
            return flag;
        }

        public int GetCourseID()
        {
            return CourseID;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetCreditHours()
        {
            return CreditHours;
        }

        public string GetType()
        {
            return Type;
        }

        public int GetFee()
        {
            return Fee;
        }

        public int GetDepartmentID()
        {
            return DepartmentID;
        }

        public int? GetPrerequisiteCourseID()
        {
            return PrerequisiteCourseID;
        }
        public void SetCourseID(int CourseID)
        {            
            this.CourseID = CourseID;
        }

        public void SetName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Course Name cannot be empty.");
            }
            this.Name = Name;
        }

        public void SetCreditHours(int CreditHours)
        {            
            this.CreditHours = CreditHours;
        }

        public void SetType(string Type)
        {
            this.Type = Type;
        }

        public void SetFee(int Fee)
        {
            this.Fee = Fee;
        }

        public void SetDepartmentID(int DepartmentID)
        {
            this.DepartmentID = DepartmentID;
        }

        public void SetPrerequisiteCourseID(int PrerequisiteCourseID)
        {
            this.PrerequisiteCourseID = PrerequisiteCourseID;
        }

        public List<object> GetCourseNames()
        {
            DL.Course dl = new DL.Course();
            List<object> courseNames = dl.GetCourseNamesFromDB();
            return courseNames;
        }

        public int GetCourseID(string courseName)
        {
            DL.Course dl = new DL.Course();
            int courseID = dl.GetCourseIDFromDB(courseName);
            return courseID;
        }

        public bool UpdateCourseStatus(int id, string newStatus)
        {
            DL.Course dl = new DL.Course();
            return dl.UpdateCourseStatusInDB(id, newStatus);
        }


    }
}
