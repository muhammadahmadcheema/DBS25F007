using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Org.BouncyCastle.Asn1.Mozilla;
using DBProjectBackend.DL;

namespace DBProjectBackend.BL
{
    public class StudentCoursesEnrollment
    {
        private int StudentCoursesEnrollmentID;
        private int StudentID;
        private int FacultyCourseID;


        public StudentCoursesEnrollment() { }
        public StudentCoursesEnrollment(int studentID, int FacultycourseID)
        {
            this.StudentID = studentID;
            this.FacultyCourseID = FacultycourseID;
        }

        public int GetEnrollmentID() { return StudentCoursesEnrollmentID; }
        public int GetStudentID() { return StudentID; }
        public int GetFacultyCourseID() { return FacultyCourseID; }


        public void SetEnrollmentID(int id) { this.StudentCoursesEnrollmentID = id; }
        public void SetStudentID(int studentID) { this.StudentID = studentID; }
        public void SetFacultyCourseID(int FacultycourseID) { this.FacultyCourseID = FacultycourseID; }


        public bool AddEnrollment(StudentCoursesEnrollment obj)
        {
            DL.StudentCoursesEnrollment dl = new DL.StudentCoursesEnrollment();
            return dl.AddEnrollmentToDB(obj);
        }

        public bool DeleteEnrollment(int enrollmentID)
        {
            DL.StudentCoursesEnrollment dl = new DL.StudentCoursesEnrollment();
            return dl.DeleteEnrollmentFromDB(enrollmentID);
        }

        public DataTable GetAllEnrollments()
        {
            DL.StudentCoursesEnrollment dl = new DL.StudentCoursesEnrollment();
            return dl.GetAllEnrollmentsFromDB();
        }

        public int GetStudentCourseEnrollmentID(int fcid)
        {
            DL.StudentCoursesEnrollment dl = new DL.StudentCoursesEnrollment();
            return dl.GetStudentCourseEnrollmentsFromDB(fcid);
        }

        
    }
}

