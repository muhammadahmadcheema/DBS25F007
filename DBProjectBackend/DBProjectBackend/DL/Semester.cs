using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.DL
{
    class Semester
    {
        public bool AddSemesterToDB(BL.Semester s)
        {
            string insertQuery = "INSERT INTO semester(Year, Term) VALUES ({0}, '{1}')";
            insertQuery = String.Format(insertQuery, s.GetYear(), s.GetTerm());
            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public DataTable GetAllSemesters()
        {
            string query = "SELECT * FROM semester";
            DataTable dt = SqlHelper.getDataTable(query);
            return dt;
        }

        public bool UpdateSemesterInDB(BL.Semester s)
        {
            string updateQuery = "UPDATE semester SET Year = {0}, Term = '{1}' WHERE SemesterID = {2}";
            updateQuery = String.Format(updateQuery, s.GetYear(), s.GetTerm(), s.GetSemesterID());
            int rowsAffected = SqlHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public bool DeleteSemesterFromDB(int id)
        {
            string query = $"DELETE FROM semester WHERE SemesterID = {id}";
            int rowsAffected = SqlHelper.executeDML(query);
            return rowsAffected > 0;
        }

        public List<object> GetSemesterNamesFromDB()
        {
            string query = "Select Concat(Term,' ',Year) AS SemesterName from semester";
            string columnName = "SemesterName";
            List<object> semesternames = SqlHelper.GetColumnValues(query, columnName);
            return semesternames;
        }

        public int? GetSemesterIDFromDB(string SemesterName)
        {
            string query = "Select SemesterID From retrievesemesters Where SemesterName = '{0}'";
            query = String.Format(query, SemesterName);
            object id = SqlHelper.ExecuteScalar(query);
            return (int?)id;
        }
    }
}

