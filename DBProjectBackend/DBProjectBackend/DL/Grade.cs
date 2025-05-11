using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.DL
{
    class Grade
    {
        public bool AddGradeToDB(BL.Grade g)
        {
            string insertQuery = "INSERT INTO grade(GradeName, GradePoints) VALUES ('{0}', {1})";
            insertQuery = String.Format(insertQuery, g.GetGradeName(), g.GetGradePoints());
            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public DataTable GetAllGrades()
        {
            string query = "SELECT * FROM grade";
            DataTable dt = SqlHelper.getDataTable(query);
            return dt;
        }

        public bool UpdateGradeInDB(BL.Grade g)
        {
            string updateQuery = "UPDATE grade SET GradeName = '{0}', GradePoints = {1} WHERE GradeID = {2}";
            updateQuery = String.Format(updateQuery, g.GetGradeName(), g.GetGradePoints(), g.GetGradeID());
            int rowsAffected = SqlHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public bool DeleteGradeFromDB(int id)
        {
            string query = $"DELETE FROM grade WHERE GradeID = {id}";
            int rowsAffected = SqlHelper.executeDML(query);
            return rowsAffected > 0;
        }

        public List<object> GetGradeNamesFromDB()
        {
            string query = "Select GradeName from grade";
            string columnName = "GradeName";
            List<object> gradeNames = SqlHelper.GetColumnValues(query, columnName);
            return gradeNames;
        }


        public int GetGradeIDFromDB(string GradeName)
        {
            string query = "Select GradeID From grade Where GradeName = '{0}'";
            query = String.Format(query, GradeName);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }
    }
}
