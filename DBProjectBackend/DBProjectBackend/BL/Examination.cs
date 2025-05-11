using System;
using System.Collections.Generic;
using System.Data;
using DBProjectBackend.DL;

namespace DBProjectBackend.BL
{
    public class Examination
    {
        private int ExamID;
        private string Type;
        private int CourseID;
        private string Status;
        private string ExamDate;
        private int FacultyID;
        private int TotalMarks;
        private int PassingMarks;
        private string Duration;


        public Examination() { }

        public Examination(string Type, int CourseID, string Status, string ExamDate, int FacultyID, int TotalMarks, int PassingMarks, string Duration)
        {
            this.Type = Type;
            this.CourseID = CourseID;
            this.Status = Status;
            this.ExamDate = ExamDate;
            this.FacultyID = FacultyID;
            this.TotalMarks = TotalMarks;
            this.PassingMarks = PassingMarks;
            this.Duration = Duration;
        }

        public List<object> GetExamNames()
        {
            DL.Examination dl = new DL.Examination();
            List<object> ExamNames = dl.GetExamNamesFromDB();
            return ExamNames;
        }

        public Examination(int ExamID, string Type, int CourseID, string Status, string ExamDate, int TotalMarks, int PassingMarks, string Duration)
        {
            this.ExamID = ExamID;
            this.Type = Type;
            this.CourseID = CourseID;
            this.Status = Status;
            this.ExamDate = ExamDate;            
            this.TotalMarks = TotalMarks;
            this.PassingMarks = PassingMarks;
            this.Duration = Duration;
        }

        public bool AddExam(Examination e)
        {
            DL.Examination dl = new DL.Examination();
            return dl.AddExamToDB(e);
        }

        public DataTable GetExams()
        {
            DL.Examination dl = new DL.Examination();
            return dl.GetAllExams();
        }

        public bool UpdateExam(Examination e)
        {
            DL.Examination dl = new DL.Examination();
            return dl.UpdateExamInDB(e);
        }

        public bool DeleteExam(int id)
        {
            DL.Examination dl = new DL.Examination();
            return dl.DeleteExamFromDB(id);
        }

        public int GetExamID()
        {
            return ExamID;
        }

        public string GetType()
        {
            return Type;
        }

        public int GetCourseID()
        {
            return CourseID;
        }

        public string GetStatus()
        {
            return Status;
        }

        public string GetExamDate()
        {
            return ExamDate;
        }

        public int GetFacultyID()
        {
            return FacultyID;
        }

        public int GetTotalMarks()
        {
            return TotalMarks;
        }

        public int GetPassingMarks()
        {
            return PassingMarks;
        }

        public string GetDuration()
        {
            return Duration;
        }


        public void SetExamID(int id)
        {
            ExamID = id;
        }

        public void SetType(string type)
        {
            Type = type;
        }

        public void SetCourseID(int courseID)
        {
            CourseID = courseID;
        }

        public void SetStatus(string status)
        {
            Status = status;
        }

        public void SetExamDate(string date)
        {
            ExamDate = date;
        }

        public void SetFacultyID(int facultyID)
        {
            FacultyID = facultyID;
        }

        public void SetTotalMarks(int marks)
        {
            TotalMarks = marks;
        }

        public void SetPassingMarks(int passing)
        {
            PassingMarks = passing;
        }

        public void SetDuration(string duration)
        {
            Duration = duration;
        }

        public DataTable GetAllExamsWithEnrollmentStatus(int studentID, int departmentID)
        {
            DL.Examination dl = new DL.Examination();
            return dl.GetAllExamsWithEnrollmentStatusFromDB(studentID, departmentID);
        }
    }
}
