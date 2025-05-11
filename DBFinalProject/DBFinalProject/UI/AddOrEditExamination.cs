using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using DBProjectBackend.BL;

namespace DBFinalProject.UI
{
	public partial class AddOrEditExamination : DBFinalProject.UI.FacultyDashboard
	{
		public AddOrEditExamination()
		{
			InitializeComponent();
            bindcmbCourse();
            bindcmbFaculty();
            bindcmbEditExam();
        }

        private void bindcmbFaculty()
        {
            DBProjectBackend.BL.Faculty user = new DBProjectBackend.BL.Faculty();
            List<object> usernames = user.GetUserNames();
            cmbFaculty.DataSource = usernames;
            cmbFaculty.SelectedIndex = -1;
        }

        private void bindcmbCourse()
        {
            DBProjectBackend.BL.Course course = new DBProjectBackend.BL.Course();
            List<object> courseNames = course.GetCourseNames();
            cmbCourse.DataSource = courseNames;
            cmbCourse.SelectedIndex = -1;
        }

        private void bindcmbEditExam()
        {
            DBProjectBackend.BL.Examination exam = new DBProjectBackend.BL.Examination();
            List<object> examNames = exam.GetExamNames();
            cmbEditExam.DataSource = examNames;
            cmbEditExam.SelectedIndex = -1;
        }



        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            //Edit Button Implementation
            try
            {
                string type = cmbType.Text.ToString().Trim();
                string coursename = cmbCourse.Text.Trim();
                string status = cmbStatus.Text.ToString().Trim();
                string examdate = txtExamDate.Text.Trim();
                string facultyname = cmbFaculty.Text.ToString().Trim();
                int totalmarks = int.Parse(txtTotalMarks.Text.Trim());
                int passingmarks = int.Parse(txtPassingMarks.Text.Trim());
                string duration = txtDuration.Text.Trim();


                //Fetch FacultyID because we have to store ID not Faculty Name
                Faculty bl = new Faculty();
                int facultyID = bl.GetFacultyID(facultyname);

                //Fetch CourseID because we have to store ID not Course Name
                Course bl1 = new Course();
                int CourseID = bl1.GetCourseID(coursename);


                DBProjectBackend.BL.Examination exam = new DBProjectBackend.BL.Examination(type, CourseID, status, examdate, facultyID, totalmarks, passingmarks, duration);
                bool flag = exam.AddExam(exam);

                if (flag)
                {
                    MessageBox.Show("Exam Added Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //Add Button Implementation
            try
            {
                string type = cmbType.Text.ToString().Trim();
                string coursename = cmbCourse.Text.Trim();
                string status = cmbStatus.Text.ToString().Trim();
                string examdate = txtExamDate.Text.Trim();
                int totalmarks = int.Parse(txtTotalMarks.Text.Trim());
                int passingmarks = int.Parse(txtPassingMarks.Text.Trim());
                string duration = txtDuration.Text.Trim();
                int ExamID = int.Parse(cmbEditExam.Text.Trim());

                

                //Fetch CourseID because we have to store ID not Course Name
                Course bl1 = new Course();
                int CourseID = bl1.GetCourseID(coursename);




                DBProjectBackend.BL.Examination exam = new DBProjectBackend.BL.Examination(ExamID, type, CourseID, status, examdate, totalmarks, passingmarks, duration);
                bool flag = exam.UpdateExam(exam);

                if (flag)
                {
                    MessageBox.Show("Exam Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
    
}
