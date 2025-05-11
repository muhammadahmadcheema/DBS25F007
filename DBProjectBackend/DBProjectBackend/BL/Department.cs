using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ZstdSharp.Unsafe;

namespace DBProjectBackend.BL
{
    public class Department
    {
        private int DepartmentID;
        private string Name;
        private string Code;

        public Department() { }
        public Department(string Name, string Code)
        {
            this.Name = Name;
            this.Code = Code;
        }

        public Department(int DepartmentID, string Name, string Code)
        {
            this.DepartmentID = DepartmentID;
            this.Name = Name;
            this.Code = Code;
        }

        public bool AddDepartment(Department d)
        {
            DL.Department dl = new DL.Department();
            return dl.AddDepartmentToDB(d);
        }

        public DataTable GetDepartments()
        {
            DL.Department dl = new DL.Department();
            return dl.GetAllDepartments();
        }

        public bool UpdateDepartment(Department d)
        {
            DL.Department dl = new DL.Department();
            return dl.UpdateDepartmentInDB(d);
        }

        public bool DeleteDepartment(int DepartmentID)
        {
            DL.Department dl = new DL.Department();
            return dl.DeleteDepartmentFromDB(DepartmentID);
        }

        public int GetDepartmentID()
        {
            return DepartmentID;
        }

        public int GetDepartmentID(string DeptName)
        {
            DL.Department dl = new DL.Department();
            return dl.GetDepartmentIDFromDB(DeptName);
        }

        public List<object> GetDepartmentNames()
        {
            DL.Department dl = new DL.Department();
            List <object> deptNames = dl.GetDepartmentNamesFromDB();
            return deptNames;                        
        }

        public string GetName()
        {
            return Name;
        }

        public string GetCode()
        {
            return Code;
        }


        public void SetDepartmentID(int DepartmentID)
        {
            this.DepartmentID = DepartmentID;
        }

        public void SetName(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("Department name cannot be empty.");
            }
            this.Name = Name;
        }

        public void SetCode(string Code)
        {
            if (string.IsNullOrWhiteSpace(Code))
            {
                throw new ArgumentException("Department code cannot be empty.");
            }
            this.Code = Code;
        }
    }
}
