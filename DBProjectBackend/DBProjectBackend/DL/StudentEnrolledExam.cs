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
        public bool AddEnrollmentToDB(BL.StudentEnrolledExam obj)
        {
            string examIDValue = obj.GetGradeID().HasValue ? obj.GetGradeID().Value.ToString() : "NULL";
            string query = "INSERT INTO StudentEnrolledExam (ExamID, StudentID, ObtainedMarks, GradeID) " +
                           "VALUES ({0}, {1}, {2}, {3})";
            query = string.Format(query, obj.GetExamID(), obj.GetStudentID(), obj.GetObtainedMarks(), examIDValue);
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

        public int GetStudentExamEnrollmentsFromDB(int fcid)
        {
            string query = "Select StudentEnrolledExamID From StudentEnrolledExam Where ExamID = {0}";
            query = String.Format(query, fcid);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }

        public bool DeleteEnrollmentFromDB(int enrollmentID)
        {
            string query = "DELETE FROM StudentEnrolledExam WHERE StudentEnrolledExamID = {0}";
            query = string.Format(query, enrollmentID);
            int rows = SqlHelper.executeDML(query);
            return rows > 0;
        }
    }
}
