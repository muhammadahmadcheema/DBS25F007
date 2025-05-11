using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.DL
{
    class TechnicalStaff
    {
        

        public bool AddToDB(BL.TechnicalStaff f)
        {
            string query = "Insert into technicalstaff(HireDate,Specialization,User_ID) Values ('{0}','{1}',{2})";
            query = String.Format(query, f.GetHireDate(), f.GetSpecialization(), f.GetUserID());
            int rowsAffected = SqlHelper.executeDML(query);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateTechnicalStaffInDB(BL.TechnicalStaff obj)
        {
            string query = "UPDATE TechnicalStaff SET HireDate = '{0}', Specialization = '{1}' Where User_ID = {2}";
            query = string.Format(query, obj.GetHireDate(), obj.GetSpecialization(), obj.GetUserID());
            int rows = SqlHelper.executeDML(query);
            return rows > 0;
        }

        public bool DeleteFromDB(int id)
        {
            string query = "DELETE FROM TechnicalStaff WHERE TechnicalStaffID = {0}";
            query = string.Format(query, id);
            int rows = SqlHelper.executeDML(query);
            return rows > 0;
        }

        public DataTable GetAllFromDB()
        {
            string query = "SELECT * FROM TechnicalStaff";
            return SqlHelper.getDataTable(query);
        }

        public List<object> GetTechnicalStaffUserNamesFromDB()
        {
            string query = "Select Username from user Where role = '{0}' ";
            query = String.Format(query, "TechnicalStaff");
            string columnName = "UserName";
            List<object> userNames = SqlHelper.GetColumnValues(query, columnName);
            return userNames;
        }

        public DataTable GetAllTechnicalStaff()
        {
            string query = "Select u.UserID,u.Name,u.CNIC,u.Username,u.Email,u.DOB,u.Phone,u.Status,u.createdDate,f.TechnicalStaffID, f.HireDate, f.Specialization From user u Join technicalstaff f ON u.UserID = f.User_ID Where u.Role Like 'TechnicalStaff'";
            DataTable usersTable = SqlHelper.getDataTable(query);
            return usersTable;
        }
    }
}
