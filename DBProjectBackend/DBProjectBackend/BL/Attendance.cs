using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Security;


namespace DBProjectBackend.BL
{
    public class Attendance
    {
        private int AttendanceID;
        private string Date;
        private string Status;
        private int StudentCoursesEnrollmentID;

        public Attendance() { }

        public Attendance(string date, string status, int studentCoursesEnrollmentID)
        {
            this.Date = date;
            this.Status = status;
            this.StudentCoursesEnrollmentID = studentCoursesEnrollmentID;
        }

        public Attendance(int attendanceID, string date, string status, int studentCoursesEnrollmentID)
        {
            this.AttendanceID = attendanceID;
            this.Date = date;
            this.Status = status;
            this.StudentCoursesEnrollmentID = studentCoursesEnrollmentID;
        }

        public int GetAttendanceID()
        {
            return AttendanceID;
        }

        public void SetAttendanceID(int attendanceID)
        {
            this.AttendanceID = attendanceID;
        }

        public string GetDate()
        {
            return Date;
        }

        public void SetDate(string date)
        {
            this.Date = date;
        }

        public string GetStatus()
        {
            return Status;
        }

        public void SetStatus(string status)
        {
            this.Status = status;
        }

        public int GetStudentCoursesEnrollmentID()
        {
            return StudentCoursesEnrollmentID;
        }

        public void SetStudentCoursesEnrollmentID(int studentCoursesEnrollmentID)
        {
            this.StudentCoursesEnrollmentID = studentCoursesEnrollmentID;
        }

        public bool AddAttendance(Attendance attendance)
        {
            DL.Attendance dl = new DL.Attendance();
            return dl.AddAttendancetoDB(attendance);
        }


    }
}
