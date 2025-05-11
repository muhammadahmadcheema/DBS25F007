using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.DL
{
    class Department
    {
        public bool AddDepartmentToDB(BL.Department d)
        {
            string insertQuery = "INSERT INTO department(Name, Code) VALUES ('{0}', '{1}')";
            insertQuery = String.Format(insertQuery, d.GetName(), d.GetCode());
            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public DataTable GetAllDepartments()
        {
            string query = "SELECT * FROM department";
            DataTable departmentTable = SqlHelper.getDataTable(query);
            return departmentTable;
        }

        public bool UpdateDepartmentInDB(BL.Department d)
        {
            string updateQuery = "UPDATE department SET Name = '{0}', Code = '{1}' WHERE DepartmentID = {2}";
            updateQuery = String.Format(updateQuery, d.GetName(), d.GetCode(), d.GetDepartmentID());
            int rowsAffected = SqlHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public bool DeleteDepartmentFromDB(int departmentId)
        {
            string query = $"DELETE FROM department WHERE DepartmentID = {departmentId}";
            int rowsAffected = SqlHelper.executeDML(query);
            return rowsAffected > 0;
        }

        public int GetDepartmentIDFromDB(string DeptName)
        {
            string query = "Select DepartmentID From department Where Name = '{0}'";
            query = String.Format(query, DeptName);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }

        public List<object> GetDepartmentNamesFromDB()
        {
            string query = "Select Name from department";
            string columnName = "Name";
            List<object> departmentNames = SqlHelper.GetColumnValues(query, columnName);
            return departmentNames;
        }

    }
}
