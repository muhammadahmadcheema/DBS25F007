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
    class Attendance
    {
        public bool AddAttendancetoDB(BL.Attendance f)
        {
            string query = "Insert into attendance(Date,Status,StudentCoursesEnrolllmentID) Values ('{0}',{1},{2})";
            query = String.Format(query, f.GetDate(), f.GetStatus(), f.GetStudentCoursesEnrollmentID());
            int rowsAffected = SqlHelper.executeDML(query);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
    }
}
