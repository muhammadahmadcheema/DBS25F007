using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DBProjectBackend.DL
{
    class FeeChallan
    {
        public bool AddFeeChallanToDB(BL.FeeChallan fc)
        {
            string insertQuery = "INSERT INTO FeeChallan (SemesterID, IssueDate, DueDate, TotalAmount, Status, StudentID) " +
                                 "VALUES ({0}, '{1}', '{2}', {3}, '{4}', {5})";
            insertQuery = string.Format(insertQuery,
                                        fc.GetSemesterID(),
                                        fc.GetIssueDate(),
                                        fc.GetDueDate(),
                                        fc.GetTotalAmount(),
                                        fc.GetStatus(),
                                        fc.GetStudentID());

            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public DataTable GetAllFeeChallansFromDB()
        {
            string query = "SELECT * FROM FeeChallan";
            DataTable dt = SqlHelper.getDataTable(query);
            return dt;
        }

       

        public bool UpdateFeeChallanToDB(BL.FeeChallan fc)
        {
            string updateQuery = "UPDATE FeeChallan SET SemesterID = {0}, IssueDate = '{1}', DueDate = '{2}', " +
                                 "TotalAmount = {3}, Status = '{4}', StudentID = {5} WHERE ChallanID = {6}";
            updateQuery = string.Format(updateQuery,
                                        fc.GetSemesterID(),
                                        fc.GetIssueDate(),
                                        fc.GetDueDate(),
                                        fc.GetTotalAmount(),
                                        fc.GetStatus(),
                                        fc.GetStudentID(),
                                        fc.GetChallanID());

            int rowsAffected = SqlHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public bool UpdateChallanStatusInDB(int id, string newStatus)
        {
            // string query = "Update feechallan Set Status = '{0}' Where ChallanID = {1}";
            string query = "Call UpdateChallanStatus({0},'{1}')";
            query = String.Format(query, id, newStatus);
            int rowsAffected = SqlHelper.executeDML(query);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteFeeChallanFromDB(int ChallanID)
        {
            string deleteQuery = "DELETE FROM FeeChallan WHERE ChallanID = {0}";
            deleteQuery = string.Format(deleteQuery, ChallanID);

            int rowsAffected = SqlHelper.executeDML(deleteQuery);
            return rowsAffected > 0;
        }
    }
}

