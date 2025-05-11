using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBProjectBackend.BL;
using System.Xml.Linq;
using System.Data;
using System.Collections;

namespace DBProjectBackend.DL
{
    class User
    {
        static public bool AddUsertoDB(string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Role, string Name, string createdDate)
        {
            string insertQuery = "INSERT INTO user(Password_Hash,CNIC,Username, Email,DOB, Phone,Status,Role,Name,CreatedDate) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
            insertQuery = String.Format(insertQuery, Password, CNIC, Username, Email, DOB, Phone, "Present", Role, Name, createdDate);
            int rowsAffected = SqlHelper.executeDML(insertQuery);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        static public DataTable GetAllAdmins()
        {
            string query = "Select * From user WHERE Role = 'Admin'";
            DataTable usersTable = SqlHelper.getDataTable(query);
            return usersTable;
        }


        static public DataTable GetAllUsers()
        {
            string query = "Select * From user";
            DataTable usersTable = SqlHelper.getDataTable(query);
            return usersTable;
        }

        static public bool UpdateUsertoDB(int UserID, string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Name)
        {
            string updateQuery = "UPDATE user SET Password_Hash = '{0}',CNIC = '{1}',Username = '{2}', Email = '{3}',DOB = '{4}', Phone = '{5}',Name = '{6}' Where UserID = {7}";
            updateQuery = String.Format(updateQuery, Password, CNIC, Username, Email, DOB, Phone, Name, UserID);
            int rowsAffected = SqlHelper.executeDML(updateQuery);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        static public bool DeleteUserFromDB(int UserId)
        {
            string query = "Delete From user Where UserID = {UserId}";
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

        public bool UpdateUserStatusInDB(int id, string newStatus)
        {
            string query = "Update user Set Status = '{0}' Where UserID = {1}";
            query = String.Format(query, newStatus, id);
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

        public object GetUserRoleFromDB(string username, string hashedpassword)
        {
            string query = "Select role From user Where Username = '{0}' AND Password_Hash = '{1}'";
            query = String.Format(query, username, hashedpassword);
            object role = SqlHelper.ExecuteScalar(query);
            return role;
        }

        public object GetUserIDFromDB(string username, string hashedpassword)
        {
            string query = "Select UserID From user Where Username = '{0}' AND Password_Hash = '{1}'";
            query = String.Format(query, username, hashedpassword);
            object id = SqlHelper.ExecuteScalar(query);
            return id;
        }

        public int GetUserIDFromDB(string userName)
        {
            string query = "Select UserID From user Where Username = '{0}'";
            query = String.Format(query, userName);
            object id = SqlHelper.ExecuteScalar(query);
            return int.Parse(id.ToString());
        }




        public List<object> GetAdminUserNamesFromDB()
        {
            string query = "Select Username from user Where role = '{0}' ";
            query = String.Format(query, "Admin");
            string columnName = "UserName";
            List<object> userNames = SqlHelper.GetColumnValues(query, columnName);
            return userNames;
        }

        public List<object> GetUserNamesFromDB()
        {
            string query = "Select Username from user Where role = '{0}' ";
            query = String.Format(query, "Admin");
            string columnName = "UserName";
            List<object> userNames = SqlHelper.GetColumnValues(query, columnName);
            return userNames;
        }

    }
}
