using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.DL
{
    class Examination
    {
        public bool AddExamToDB(BL.Examination e)
        {
            string insertQuery = "INSERT INTO examination(Type, CourseID, Status, ExamDate, FacultyID, TotalMarks, PassingMarks, Duration) " +
                                 "VALUES ('{0}', {1}, '{2}', '{3}', {4}, {5}, {6}, '{7}')";
            insertQuery = String.Format(insertQuery, e.GetType(), e.GetCourseID(), e.GetStatus(), e.GetExamDate(), e.GetFacultyID(), e.GetTotalMarks(), e.GetPassingMarks(), e.GetDuration());
            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public List<object> GetExamNamesFromDB()
        {
            string query = "Select ExamID from examination";
            string columnName = "ExamID";
            List<object> courseNames = SqlHelper.GetColumnValues(query, columnName);
            return courseNames;
        }

        public DataTable GetAllExams()
        {
            string query = "SELECT * FROM examination";
            return SqlHelper.getDataTable(query);
        }

        public bool UpdateExamInDB(BL.Examination e)
        {
            string updateQuery = "UPDATE examination SET Type = '{0}', CourseID = {1}, Status = '{2}', ExamDate = '{3}'," +
                                 "TotalMarks = {4}, PassingMarks = {5}, Duration = '{6}' WHERE ExamID = {7}";
            updateQuery = String.Format(updateQuery, e.GetType(), e.GetCourseID(), e.GetStatus(), e.GetExamDate(), e.GetTotalMarks(), e.GetPassingMarks(), e.GetDuration(), e.GetExamID());
            int rowsAffected = SqlHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public bool DeleteExamFromDB(int id)
        {
            string query = $"DELETE FROM examination WHERE ExamID = {id}";
            int rowsAffected = SqlHelper.executeDML(query);
            return rowsAffected > 0;
        }
    }
}
