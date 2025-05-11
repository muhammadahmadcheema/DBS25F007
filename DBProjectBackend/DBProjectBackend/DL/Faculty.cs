using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DBProjectBackend.BL;

namespace DBProjectBackend.DL
{
    class Faculty
    {        
        public bool AddFacultytoDB(BL.Faculty f)
        {
            string query = "Insert into faculty(Designation,ResearchArea,MaxWorkingHours,Qualification,faculty_DeptID,faculty_UserID) Values ('{0}','{1}',{2},'{3}',{4},{5})";
            query = String.Format(query, f.GetDesignation(), f.GetResearchArea(), f.GetMaxWorkingHours(), f.GetQualification(), f.GetFacultyDeptID(), f.GetFacultyUserID());
            int rowsAffected = SqlHelper.executeDML(query);
            if (rowsAffected > 0)
            {
                return true;
            }         
            return false;
        }

        public bool UpdateFacultytoDB(BL.Faculty f)
        {
            string updateQuery = "UPDATE faculty SET Designation = '{0}', ResearchArea = '{1}',MaxWorkingHours = {2}, Qualification = '{3}',faculty_DeptID = {4} Where faculty_UserID = {5}";
            updateQuery = String.Format(updateQuery, f.GetDesignation(), f.GetResearchArea(), f.GetMaxWorkingHours(), f.GetQualification(), f.GetFacultyDeptID(), f.GetUserID());
            int rowsAffected = SqlHelper.executeDML(updateQuery);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public List<object> GetFacultyUserNamesFromDB()
        {
            string query = "Select Username from user Where role = '{0}' ";
            query = String.Format(query, "Faculty");
            string columnName = "UserName";
            List<object> userNames = SqlHelper.GetColumnValues(query, columnName);
            return userNames;
        }

        public DataTable GetAllFaculty()
        {                       
            string query = "Select u.UserID,u.Name,u.CNIC,u.Username,u.Email,u.DOB,u.Phone,u.Status,u.createdDate,f.Designation,f.ResearchArea,f.MaxWorkingHours,f.Qualification,d.name AS Department From user u Join faculty f ON u.UserID = f.faculty_UserID Join Department d ON f.faculty_DeptID = d.DepartmentID Where u.Role Like 'Faculty'";
            DataTable usersTable = SqlHelper.getDataTable(query);
            return usersTable;            
        }

        public bool DeleteFacultyFromDB(int FacultyId,int UserId)
        {                           
            List<string> queries = new List<string>();
           
            queries.Add($"Delete From faculty Where FacultyID = {FacultyId}");
            queries.Add($"DELETE FROM user WHERE UserID = {UserId}");
                
                
            bool rowsAffected = SqlHelper.ExecuteTransaction(queries);

            if (rowsAffected)
            {
                return true;
            }
            else
            {
                return false;
            }                        
        }

        public int GetFacultyIDFromDB(string facultyName)
        {
            string query = "Select f.FacultyID From faculty f JOin user u On u.userID = f.faculty_userID Where u.UserName = '{0}'";
            query = String.Format(query, facultyName);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }

        public int GetFacultyIDFromDBForAttendance(int userID)
        {
            string query = "Select s.FacultyID From faculty s WHere s.faculty_UserID = {0}";
            query = String.Format(query, userID);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }


    }
}
