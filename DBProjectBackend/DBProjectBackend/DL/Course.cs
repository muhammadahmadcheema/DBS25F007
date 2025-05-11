using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProjectBackend.DL
{
    class Course
    {        
        public bool AddCoursetoDB(BL.Course c)
        {
            string preCourseValue = c.GetPrerequisiteCourseID().HasValue ? c.GetPrerequisiteCourseID().Value.ToString(): "NULL";
            string insertQuery = "INSERT INTO course(Name, CreditHours, Type, Fee, DepartmentID, PrerequisiteCourseID) " +
                                 "VALUES ('{0}', {1}, '{2}', {3}, {4}, {5})";
            insertQuery = String.Format(insertQuery,c.GetName(),c.GetCreditHours(),c.GetType(),c.GetFee(),c.GetDepartmentID(),preCourseValue);  

            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public DataTable GetAllCoursesFromDB()
        {
            string query = "Select * From course";
            DataTable coursesTable = SqlHelper.getDataTable(query);
            return coursesTable;
        }

        public bool UpdateCoursetoDB(BL.Course course)
        {
            string preCourseValue = course.GetPrerequisiteCourseID().HasValue ? course.GetPrerequisiteCourseID().Value.ToString() : "NULL";
            string updateQuery = "UPDATE course SET Name = '{0}',CreditHours = '{1}',Type = '{2}', Fee = '{3}',PrerequisiteCourseID = {4} Where CourseID = {5}";
            updateQuery = String.Format(updateQuery, course.GetName(), course.GetCreditHours(), course.GetType(), course.GetFee(), preCourseValue, course.GetCourseID());
            int rowsAffected = SqlHelper.executeDML(updateQuery);

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteCourseFromDB(int CourseId)
        {
            string query = "Delete From course Where CourseID = {0}";
            query = String.Format(query, CourseId);
            int rowsAffected = SqlHelper.executeDML(query);
            return rowsAffected > 0;
        }

        public int? GetPrerequisiteCourseIDFromDB(string CourseName)
        {
            string query = "Select CourseID From course Where Name = '{0}'";
            query = String.Format(query, CourseName);
            object id = SqlHelper.ExecuteScalar(query);
            return (int?)id;
        }

        public List<object> GetCourseNamesFromDB()
        {
            string query = "Select Name from course";
            string columnName = "Name";
            List<object> courseNames = SqlHelper.GetColumnValues(query, columnName);
            return courseNames;
        }

        public int GetCourseIDFromDB(string courseName)
        {
            string query = "Select CourseID From course Where Name = '{0}'";
            query = String.Format(query, courseName);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }

        public bool UpdateCourseStatusInDB(int id, string newStatus)
        {
            string query = "Update course Set Status = '{0}' Where CourseID = {1}";
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

    }
}
