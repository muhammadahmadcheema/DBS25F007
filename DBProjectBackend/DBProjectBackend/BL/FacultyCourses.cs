using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBProjectBackend.DL;
using ZstdSharp.Unsafe;

namespace DBProjectBackend.BL
{
    public class FacultyCourses
    {
        public FacultyCourses() { }

        private int FacultyCourseID;
        private int FacultyID;
        private int CourseID;
        private int SemesterID;
        public FacultyCourses(int facultyID, int CourseID, int semesterID)
        {
            this.FacultyID = facultyID;
            this.CourseID = CourseID;
            this.SemesterID = semesterID;
        }

        public FacultyCourses(int facultyCourseID, int facultyID, int CourseID, int semesterID)
        {
            this.FacultyCourseID = facultyCourseID;
            this.FacultyID = facultyID;
            this.CourseID = CourseID;
            this.SemesterID = semesterID;
        }

        public bool AddFacultyCourse(FacultyCourses facultyCourse, string facultyName, string courseName, string semesterName)
        {
            DL.FacultyCourse dl = new DL.FacultyCourse();
            int? facultycourseid = dl.GetFacultyCourseAssignmentIDFromDB(facultyName, courseName, semesterName);
            if (facultycourseid == null)
            {
                return dl.AddFacultyCourseToDB(facultyCourse);
            }
            return false;            
        }

        public int GetFacultyID()
        {
            return FacultyID;
        }

        public int GetCourseID()
        {
            return CourseID;
        }

        public int GetSemesterID()
        {
            return SemesterID;
        }
        
        public DataTable GetAllCoursesWithEnrollmentStatus(int studentID,int departmentID)
        {
            DL.FacultyCourse dl = new FacultyCourse();
            return dl.GetAllCoursesWithEnrollmentStatusFromDB(studentID, departmentID);
        }

        public List<object> GetFacultyCoursesAssignment()
        {
            DL.FacultyCourse dl = new DL.FacultyCourse();
            return dl.GetFacultyAssignmentsFromDB();
        }

        public bool UpdateFacultyCourse(FacultyCourses fc, string facultyName, string courseName, string semesterName)
        {
            DL.FacultyCourse dl = new DL.FacultyCourse();
            int? facultycourseid = dl.GetFacultyCourseAssignmentIDFromDB(facultyName, courseName, semesterName);
            if (facultycourseid == null)
            {
                return dl.UpdateFacultyCourseInDB(fc);
            }
            return false;
        }

        public int? GetFacultyCourseID(string editAssignment)
        {
            DL.FacultyCourse dl = new DL.FacultyCourse();
            return dl.GetFacultyCourseIDFromDB(editAssignment);
        }

        public int GetFacultyCourseID()
        {
            return FacultyCourseID;
        }
        public DataTable GetAllFacultyCoursesByName(int userid, int LoggedInUserDeptID, string coursename)
        {
            DL.FacultyCourse dl = new DL.FacultyCourse();
            return dl.GetAllFacultyCoursesByNameFromDB(userid, LoggedInUserDeptID, coursename);
        }



    }
}
