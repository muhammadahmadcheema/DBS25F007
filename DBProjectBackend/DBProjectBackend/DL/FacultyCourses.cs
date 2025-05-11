using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBProjectBackend.BL;

namespace DBProjectBackend.DL
{
    class FacultyCourse
    {
        public bool AddFacultyCourseToDB(BL.FacultyCourses fc)
        {
            string insertQuery = "INSERT INTO facultycourses(FacultyID, CourseID, SemesterID) " +
                                 "VALUES ({0}, {1}, {2})";
            insertQuery = String.Format(insertQuery, fc.GetFacultyID(), fc.GetCourseID(), fc.GetSemesterID());

            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }
                
        public bool UpdateFacultyCourseInDB(BL.FacultyCourses fc)
        {
            string updateQuery = "UPDATE facultycourses SET FacultyID = {0}, CourseID = {1}, SemesterID = {2} " +
                                 "WHERE FacultyCourseID = {3}";
            updateQuery = String.Format(updateQuery, fc.GetFacultyID(), fc.GetCourseID(), fc.GetSemesterID(), fc.GetFacultyCourseID());

            int rowsAffected = SqlHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public bool DeleteFacultyCourseFromDB(int facultyCourseID)
        {
            string deleteQuery = "DELETE FROM facultycourses WHERE FacultyCourseID = {0}";
            deleteQuery = String.Format(deleteQuery, facultyCourseID);

            int rowsAffected = SqlHelper.executeDML(deleteQuery);
            return rowsAffected > 0;
        }

        public List<object> GetFacultyCourseIDsFromDB()
        {
            string query = "SELECT FacultyCourseID FROM faculty_course";
            return SqlHelper.GetColumnValues(query, "FacultyCourseID");
        }

        public List<object> GetFacultyAssignmentsFromDB()
        {
            string query = "SELECT FacultyCourseAssignment FROM Retrievefacultycourses";
            return SqlHelper.GetColumnValues(query, "FacultyCourseAssignment");
        }

        public int? GetFacultyCourseIDFromDB(string editassignment)
        {
            string query = "Select FacultyCourseID From retrievefacultycourses Where FacultyCourseAssignment = '{0}'";
            query = String.Format(query, editassignment);
            object id = SqlHelper.ExecuteScalar(query);
            return (int?)id;
        }

        public int? GetFacultyCourseAssignmentIDFromDB(string facultyName, string courseName, string SemesterName)
        {
            string query = "Select FacultyCourseID From retrievefacultycourses Where FacultyCourseAssignment = '{0}'";
            query = String.Format(query, (facultyName + " " + courseName + " " + SemesterName));
            object id = SqlHelper.ExecuteScalar(query);
            return (int?)id;
        }

        public DataTable GetAllFacultyCoursesByNameFromDB(int studentid, int LoggedInUserDeptID, string coursename)
        {
            string query = "SELECT fc.FacultyCourseID,c.Name AS CourseName,c.Type AS CourseType, c.CreditHours AS CourseCH, c.Fee AS CourseFee, d.Name AS DepartmentName, u.Name AS FacultyName,CONCAT(s.Term, ' ', s.Year) AS Semester,CASE WHEN se.StudentID IS NOT NULL THEN 1 ELSE 0 END AS IsEnrolled FROM facultycourses fc JOIN faculty f ON fc.facultyID = f.facultyID JOIN Course c ON fc.CourseID = c.CourseID JOIN Semester s ON fc.semesterID = s.SemesterID  JOIN user u ON u.userID = f.faculty_userID JOIN department d ON c.DepartmentID = d.DepartmentID LEFT JOIN studentCoursesEnrollment se ON se.facultyCourseID = fc.facultyCourseID AND se.StudentID = {0} LEFT JOIN student std ON u.userID = std.userID  WHERE c.status = '{1}' AND c.Name Like '{2}'   AND d.DepartmentID = {3} ORDER BY IsEnrolled DESC, CourseName";
            query = String.Format(query,studentid,"Approved",coursename,LoggedInUserDeptID);
            return SqlHelper.getDataTable(query);
        }

        public DataTable GetAllCoursesWithEnrollmentStatusFromDB(int studentID,int departmentID)
        {
            string query = "SELECT fc.FacultyCourseID,c.Name AS CourseName,c.Type AS CourseType, c.CreditHours AS CourseCH, c.Fee AS CourseFee, d.Name AS DepartmentName, u.Name AS FacultyName,CONCAT(s.Term, ' ', s.Year) AS Semester,CASE WHEN se.StudentID IS NOT NULL THEN 1 ELSE 0 END AS IsEnrolled FROM facultycourses fc JOIN faculty f ON fc.facultyID = f.facultyID JOIN Course c ON fc.CourseID = c.CourseID JOIN Semester s ON fc.semesterID = s.SemesterID  JOIN user u ON u.userID = f.faculty_userID JOIN department d ON c.DepartmentID = d.DepartmentID LEFT JOIN studentCoursesEnrollment se ON se.facultyCourseID = fc.facultyCourseID AND se.StudentID = {0} LEFT JOIN student std ON u.userID = std.userID  WHERE c.status = '{1}'   AND d.DepartmentID = {2} ORDER BY IsEnrolled DESC, CourseName";
            query = String.Format(query, studentID, "Approved", departmentID);
            return SqlHelper.getDataTable(query);
        }

    }
}

