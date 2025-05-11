using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;

namespace DBProjectBackend.BL
{
    public class Semester
    {
        private int SemesterID;
        private int Year;
        private string Term;

        public Semester() { }
        public Semester(int Year, string Term)
        {
            SetYear(Year);
            this.Term = Term;
        }

        public Semester(int SemesterID, int Year, string Term)
        {
            this.SemesterID = SemesterID;
            SetYear(Year);
            this.Term = Term;
        }


        public bool AddSemester(Semester s)
        {
            DL.Semester dl = new DL.Semester();
            //Check if duplicate exists
            int? semesterID = null;
            semesterID = GetSemesterID(s.GetTerm() + " " + s.GetYear());
            if (semesterID  == null)
            {
                return dl.AddSemesterToDB(s);
            }
            return false;
        }

        public DataTable GetSemesters()
        {
            DL.Semester dl = new DL.Semester();
            return dl.GetAllSemesters();
        }

        public bool UpdateSemester(Semester s)
        {
            DL.Semester dl = new DL.Semester();
            int? semesterID = null;
            semesterID = GetSemesterID(s.GetTerm() + " " + s.GetYear());
            if (semesterID == null)
            {
                return dl.UpdateSemesterInDB(s);
            }
            return false;            
        }

        public bool DeleteSemester(int id)
        {
            DL.Semester dl = new DL.Semester();
            return dl.DeleteSemesterFromDB(id);
        }

        public int GetSemesterID()
        {
            return SemesterID;
        }

        public int GetYear()
        {            
            return Year;
        }

        public string GetTerm()
        {
            return Term;
        }


        public void SetSemesterID(int id)
        {
            this.SemesterID = id;
        }

        public void SetYear(int year)
        {
            if (year < 0)
            {                
                 throw new ArgumentException("Year cannot be negative.");               
            }
            this.Year = year;
        }

        public void SetTerm(string term)
        {
            this.Term = term;
        }

        public List<object> GetSemesterNames()
        {
            DL.Semester semester = new DL.Semester();
            List<object> semesternames = semester.GetSemesterNamesFromDB();
            return semesternames;
        }

        public int? GetSemesterID(string SemesterName)
        {
            DL.Semester s1 = new DL.Semester();
            return s1.GetSemesterIDFromDB(SemesterName);
        }
    }
}

