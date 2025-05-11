using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
namespace DBProjectBackend.BL
{
    class StudentEnrolledExam
    {
        private int StudentEnrolledExamID;
        private int ExamID;
        private int StudentID;
        private int ObtainedMarks;
        private int GradeID;


        public StudentEnrolledExam(int examID, int studentID, int obtainedMarks, int gradeID)
        {
            this.ExamID = examID;
            this.StudentID = studentID;
            this.ObtainedMarks = obtainedMarks;
            this.GradeID = gradeID;
        }


        public StudentEnrolledExam(int studentEnrolledExamID, int examID, int studentID, int obtainedMarks, int gradeID)
        {
            this.StudentEnrolledExamID = studentEnrolledExamID;
            this.ExamID = examID;
            this.StudentID = studentID;
            this.ObtainedMarks = obtainedMarks;
            this.GradeID = gradeID;
        }

        public int GetStudentEnrolledExamID() { return StudentEnrolledExamID; }
        public int GetExamID() { return ExamID; }
        public int GetStudentID() { return StudentID; }
        public int GetObtainedMarks() { return ObtainedMarks; }
        public int GetGradeID() { return GradeID; }


        public void SetStudentEnrolledExamID(int id) { this.StudentEnrolledExamID = id; }
        public void SetExamID(int examID) { this.ExamID = examID; }
        public void SetStudentID(int studentID) { this.StudentID = studentID; }
        public void SetObtainedMarks(int marks) { this.ObtainedMarks = marks; }
        public void SetGradeID(int gradeID) { this.GradeID = gradeID; }


        public bool AddStudentEnrolledExam(StudentEnrolledExam obj)
        {
            DL.StudentEnrolledExam dl = new DL.StudentEnrolledExam();
            return dl.AddToDB(obj);
        }

        public bool UpdateStudentEnrolledExam(StudentEnrolledExam obj)
        {
            DL.StudentEnrolledExam dl = new DL.StudentEnrolledExam();
            return dl.UpdateToDB(obj);
        }

        public bool DeleteStudentEnrolledExam(int id)
        {
            DL.StudentEnrolledExam dl = new DL.StudentEnrolledExam();
            return dl.DeleteFromDB(id);
        }

        public DataTable GetAllStudentEnrolledExams()
        {
            DL.StudentEnrolledExam dl = new DL.StudentEnrolledExam();
            return dl.GetAllFromDB();
        }
    }
}
