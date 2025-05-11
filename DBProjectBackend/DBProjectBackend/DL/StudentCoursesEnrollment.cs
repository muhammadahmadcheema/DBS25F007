using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DBProjectBackend.DL
{
    class StudentCoursesEnrollment
    {
        public bool AddEnrollmentToDB(BL.StudentCoursesEnrollment obj)
        {
            string query = "INSERT INTO StudentCoursesEnrollment (StudentID, FacultyCourseID) " +
                           "VALUES ({0}, {1})";
            query = string.Format(query, obj.GetStudentID(), obj.GetFacultyCourseID());
            int rows = SqlHelper.executeDML(query);
            return rows > 0;
        }

        public bool DeleteEnrollmentFromDB(int enrollmentID)
        {
            string query = "DELETE FROM StudentCoursesEnrollment WHERE StudentCoursesEnrollmentID = {0}";
            query = string.Format(query, enrollmentID);
            int rows = SqlHelper.executeDML(query);
            return rows > 0;
        }

        public DataTable GetAllEnrollmentsFromDB()
        {
            string query = "SELECT * FROM StudentCoursesEnrollment";
            return SqlHelper.getDataTable(query);
        }

        public int GetStudentCourseEnrollmentsFromDB(int fcid)
        {
            string query = "Select StudentCoursesEnrollmentID From StudentCoursesEnrollment Where FacultyCourseID = {0}";
            query = String.Format(query, fcid);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }
    }
}

