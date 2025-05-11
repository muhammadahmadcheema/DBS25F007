using System;
using System.Collections.Generic;
using System.Data;
using DBProjectBackend.BL;

namespace DBProjectBackend.DL
{
    class Student
    {
        public bool AddStudentToDB(BL.Student s)
        {
            string insertQuery = "INSERT INTO student(RegistrationNo, Hostellite, CGPA, SessionYear, Nationality, EnrollmentDate, UserID, SessionTerm, DepartmentID) " +
                                 "VALUES ('{0}', {1}, {2}, {3}, '{4}', '{5}', {6},'{7}',{8})";
            insertQuery = string.Format(insertQuery, s.GetRegistrationNo(), s.GetHostellite(), s.GetCGPA(), s.GetSessionYear(), s.GetNationality(), s.GetEnrollmentDate(), s.GetStdUserID(), s.GetSessionTerm(), s.GetStudentDeptID());

            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public List<object> GetStudentUserNamesFromDB()
        {
            string query = "Select Username from user Where role = '{0}' ";
            query = String.Format(query, "Student");
            string columnName = "UserName";
            List<object> userNames = SqlHelper.GetColumnValues(query, columnName);
            return userNames;
        }

        public DataTable GetAllStudents()
        {
            string query = "SELECT u.UserID, s.RegistrationNo, u.Name,u.CNIC,u.Username,u.Email,u.DOB,u.Phone,u.Status,s.Hostellite,s.CGPA,CONCAT(s.SessionTerm, ' ', s.SessionYear) AS Session,s.Nationality,s.EnrollmentDate,d.name AS Department FROM user u JOIN student s ON u.UserID = s.userID JOIN Department d ON s.departmentID = d.DepartmentID  WHERE u.Role LIKE 'Student'";
            DataTable usersTable = SqlHelper.getDataTable(query);
            return usersTable;
        }            

        public bool UpdateStudentInDB(BL.Student s)
        {
            string updateQuery = "UPDATE student SET RegistrationNo = '{0}', Hostellite = {1}, CGPA = {2}, SessionYear = {3}, " +
                                 "Nationality = '{4}',EnrollmentDate = '{5}',SessionTerm = '{6}', DepartmentID = '{7}' Where UserID = {8}";
            updateQuery = string.Format(updateQuery, s.GetRegistrationNo(), s.GetHostellite(), s.GetCGPA(), s.GetSessionYear(), s.GetNationality(), s.GetEnrollmentDate(), s.GetSessionTerm(), s.GetStudentDeptID(),s.GetUserID());


            int rowsAffected = SqlHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public int GetStudentIDByUserIDFromDB(int userID)
        {
            string query = "Select studentid from student where userid = {0}";
            query = String.Format(query, userID);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }

        public bool DeleteStudentFromDB(int studentid, int userid)
        {
            List<string> queries = new List<string>();

            queries.Add($"Delete From faculty Where StudentID = {studentid}");
            queries.Add($"DELETE FROM user WHERE UserID = {userid}");

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
        public int GetStudentDepartmentIDFromDB(int userid)
        {
            string query = "Select s.DepartmentID From User u Join Student s ON s.UserID = u.UserID WHere s.UserID = {0}";
            query = String.Format(query, userid);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }

        public int GetStudentIDFromDB(int userID)
        {
            string query = "Select s.StudentID From Student s WHere s.UserID = {0}";
            query = String.Format(query, userID);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }
    }
}
