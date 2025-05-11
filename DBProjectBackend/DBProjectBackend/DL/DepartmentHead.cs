using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.DL
{
    class DepartmentHead
    {
        public bool AddDepartmentHeadToDB(BL.DepartmentHead d)
        {
            string insertQuery = "INSERT INTO departmenthead(AppointmentEndDate, DepartmentID,FacultyID) VALUES ('{0}', {1},{2})";
            insertQuery = String.Format(insertQuery, d.GetAppointmentEndDate(), d.GetDepartmentID(),d.GetFacultyID());
            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public bool AddDepartmentHeadToDB(string PasswordHash,string CNIC, string Username,string Email, string DOB, string Phone, string Role, string Name,string Designation,string ResearchArea,int MaxWorkingHours, string Qualification, int FacultyDeptID, string AppointmentEndDate, int DepartmentID)
        {
           
            
                // Prepare all queries for the transaction
                var queries = new List<string>();

                string insertQuery = "INSERT INTO user(Password_Hash,CNIC,Username, Email,DOB, Phone,Status,Role,Name,CreatedDate) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
                insertQuery = String.Format(insertQuery, PasswordHash, CNIC, Username, Email, DOB, Phone, "Present", Role, Name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                // 1. Add User query
                queries.Add(insertQuery);

                string insertquery1 = "Insert into faculty(Designation,ResearchArea,MaxWorkingHours,Qualification,faculty_DeptID,faculty_UserID) Values ('{0}','{1}',{2},'{3}',{4},LAST_INSERT_ID())";
                insertquery1 = String.Format(insertquery1, Designation, ResearchArea, MaxWorkingHours, Qualification, FacultyDeptID);
                
                // 2. Add Faculty query (uses LAST_INSERT_ID() for the new UserID)
                queries.Add(insertquery1);

                string insertQuery2 = "INSERT INTO departmenthead(AppointmentEndDate, DepartmentID,FacultyID) VALUES ('{0}', {1},LAST_INSERT_ID())";
                insertQuery2 = String.Format(insertQuery2, AppointmentEndDate, DepartmentID);
                // 3. Add DepartmentHead query (uses LAST_INSERT_ID() for the new FacultyID)
                queries.Add(insertQuery2);

                // Execute all queries in a single transaction
                return SqlHelper.ExecuteTransaction(queries);
          
        }

        public DataTable GetAllDepartmentHeads()
        {
            string query = "SELECT * FROM departmenthead";
            DataTable dt = SqlHelper.getDataTable(query);
            return dt;
        }

        public bool UpdateDepartmentHeadInDB(BL.DepartmentHead d)
        {
            string updateQuery = "UPDATE departmenthead SET AppointmentEndDate = '{0}', DepartmentID = {1} WHERE FacultyID = {2}";
            updateQuery = String.Format(updateQuery, d.GetAppointmentEndDate(), d.GetDepartmentID(),d.GetFacultyID());
            int rowsAffected = SqlHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public bool DeleteDepartmentHeadFromDB(int id)
        {
            string query = $"DELETE FROM departmenthead WHERE DepartmentHeadID = {id}";
            int rowsAffected = SqlHelper.executeDML(query);
            return rowsAffected > 0;
        }

        public List<object> GetDepartmentHeadNamesFromDB()
        {
            string query = "Select Username from user Where role = '{0}' ";
            query = String.Format(query, "DepartmentHead");
            string columnName = "UserName";
            List<object> userNames = SqlHelper.GetColumnValues(query, columnName);
            return userNames;
        }

        public DataTable GetAllDepartmentHead()
        {
            string query = "SELECT u.UserID, u.Name, u.CNIC, u.Username, u.Email, u.DOB, u.Phone, u.Status, u.CreatedDate, f.DepartmentHeadID, f.AppointmentEndDate, f.DepartmentID, f.FacultyID FROM user u JOIN faculty fa ON u.UserID = fa.faculty_UserID JOIN departmenthead f ON fa.FacultyID = f.FacultyID;";
            DataTable usersTable = SqlHelper.getDataTable(query);
            return usersTable;
        }
    }
}

