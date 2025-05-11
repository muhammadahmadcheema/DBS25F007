using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBProjectBackend.BL;
using DBProjectBackend;

namespace DBFinalProject.UI
{
    public partial class AssignCoursetoFaculty : DBFinalProject.UI.AdminDashboard
    {
        public AssignCoursetoFaculty()
        {
            InitializeComponent();
            bindcmbCourseName();
            bindcmbFacultyName();
            bindcmbSemesterName();
            bindcmbeditAssignment();
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {

            //Add Button Implementation
            try
            {

                string facultyName = cmbfacultyName.Text.ToString().Trim();
                string courseName = cmbcourseName.Text.ToString().Trim();
                string semesterName = cmbsemesterName.Text.ToString().Trim();

                //Fetch FacultyID because we have to store ID not Faculty Name
                Faculty bl = new Faculty();
                int facultyID = bl.GetFacultyID(facultyName);

                //Fetch CourseID because we have to store ID not Course Name
                Course bl1 = new Course();
                int CourseID = bl1.GetCourseID(courseName);

                //Fetch SemesterID because we have to store ID not Semester Name
                Semester bl2 = new Semester();
                int semesterID = (int)bl2.GetSemesterID(semesterName);

                DBProjectBackend.BL.FacultyCourses facultyCourse = new DBProjectBackend.BL.FacultyCourses(facultyID, CourseID, semesterID);
                bool flag = facultyCourse.AddFacultyCourse(facultyCourse,facultyName,courseName,semesterName);

                if (flag)
                {
                    MessageBox.Show("Course Assignment Successful");
                }
                else
                {
                    MessageBox.Show("Course Already Assigned");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

            private void bindcmbFacultyName()
            {
            DBProjectBackend.BL.Faculty faculty = new DBProjectBackend.BL.Faculty();
            List<object> facultynames = faculty.GetUserNames();
            cmbfacultyName.DataSource = facultynames;
            cmbfacultyName.SelectedIndex = -1;
            }

        private void bindcmbCourseName()
        {
            DBProjectBackend.BL.Course course = new DBProjectBackend.BL.Course();
            List<object> coursenames = course.GetCourseNames();
            cmbcourseName.DataSource = coursenames;
            cmbcourseName.SelectedIndex = -1;
        }

        private void bindcmbSemesterName()
        {
            DBProjectBackend.BL.Semester semester = new DBProjectBackend.BL.Semester();
            List<object> semesternames = semester.GetSemesterNames();
            cmbsemesterName.DataSource = semesternames;
            cmbsemesterName.SelectedIndex = -1;
        }

        private void bindcmbeditAssignment()
        {
            DBProjectBackend.BL.FacultyCourses facultyCourse = new DBProjectBackend.BL.FacultyCourses();
            List<object> assignmentnames = facultyCourse.GetFacultyCoursesAssignment();
            cmbeditAssignment.DataSource = assignmentnames;
            cmbeditAssignment.SelectedIndex = -1;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //Edit Button Implementation
            try
            {
                string facultyName = cmbfacultyName.Text.ToString().Trim();
                string courseName = cmbcourseName.Text.ToString().Trim();
                string semesterName = cmbsemesterName.Text.ToString().Trim();
                string editAssignment = cmbeditAssignment.Text.ToString().Trim();

                //Fetch FacultyID because we have to store ID not Faculty Name
                Faculty bl = new Faculty();
                int facultyID = bl.GetFacultyID(facultyName);

                //Fetch CourseID because we have to store ID not Course Name
                Course bl1 = new Course();
                int CourseID = bl1.GetCourseID(courseName);

                //Fetch SemesterID because we have to store ID not Semester Name
                Semester bl2 = new Semester();
                int semesterID = (int)bl2.GetSemesterID(semesterName);

                //Fetch FacultyCourseID because we have to store ID
                FacultyCourses fc = new FacultyCourses();
                int? facultyCourseID = fc.GetFacultyCourseID(editAssignment);


                DBProjectBackend.BL.FacultyCourses facultyCourse = new DBProjectBackend.BL.FacultyCourses((int)facultyCourseID,facultyID, CourseID, semesterID);
                bool flag = facultyCourse.UpdateFacultyCourse(facultyCourse,facultyName,courseName,semesterName);

                
                if (flag)
                {
                    MessageBox.Show("Faculty Course Assignment Updation Successful");
                }
                else
                {
                    MessageBox.Show("Faculty Course Assignment Already Exist");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}

