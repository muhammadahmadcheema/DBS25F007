using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DBProjectBackend.DL
{
    class StudentEnrolledExam
    {
        public bool AddToDB(BL.StudentEnrolledExam obj)
        {
            string query = "INSERT INTO StudentEnrolledExam (ExamID, StudentID, ObtainedMarks, GradeID) " +
                           "VALUES ({0}, {1}, {2}, {3})";
            query = string.Format(query, obj.GetExamID(), obj.GetStudentID(), obj.GetObtainedMarks(), obj.GetGradeID());
            int rows = SqlHelper.executeDML(query);
            return rows > 0;
        }

        public bool UpdateToDB(BL.StudentEnrolledExam obj)
        {
            string query = "UPDATE StudentEnrolledExam SET ExamID = {0}, StudentID = {1}, ObtainedMarks = {2}, GradeID = {3} " +
                           "WHERE StudentEnrolledExamID = {4}";
            query = string.Format(query, obj.GetExamID(), obj.GetStudentID(), obj.GetObtainedMarks(), obj.GetGradeID(), obj.GetStudentEnrolledExamID());
            int rows = SqlHelper.executeDML(query);
            return rows > 0;
        }

        public bool DeleteFromDB(int id)
        {
            string query = "DELETE FROM StudentEnrolledExam WHERE StudentEnrolledExamID = {0}";
            query = string.Format(query, id);
            int rows = SqlHelper.executeDML(query);
            return rows > 0;
        }

        public DataTable GetAllFromDB()
        {
            string query = "SELECT * FROM StudentEnrolledExam";
            return SqlHelper.getDataTable(query);
        }
    }
}
