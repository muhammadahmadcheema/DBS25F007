using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBProjectBackend.BL;
using DBProjectBackend;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBFinalProject.UI
{
    public partial class AddOrEditCourse : DBFinalProject.UI.AdminDashboard
    {
        public AddOrEditCourse()
        {
            InitializeComponent();
            bindcmbDepartment();
            bindcmbPrerequisiteCourse();
            bindcmbCourseEdit();
        }

        private void kryptonLabel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonHeader3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            //Add Button Implementation
            try
            {
                string courseName = txtCourseName.Text.ToString().Trim();
                int creditHours = int.Parse(cmbCreditHours.Text.Trim());
                string courseType = cmbCourseType.Text.ToString().Trim();
                int courseFee = int.Parse(txtCourseFee.Text.Trim());
                string departmentName = cmbDepartment.Text.ToString().Trim();
                string prerequisiteCourse = cmbPrerequisiteCourse.SelectedItem?.ToString().Trim();

                //Fetch DeptID because we have to store ID not Dept Name
                Department bl = new Department();
                int deptID = bl.GetDepartmentID(departmentName);

                int? preCourseID = null;
                //Fetch Prerequisite Course ID 
                if (!string.IsNullOrEmpty(prerequisiteCourse))
                {
                    DBProjectBackend.BL.Course bl1 = new DBProjectBackend.BL.Course();
                    preCourseID = bl1.GetPrerequisiteCourseID(prerequisiteCourse);
                }

                DBProjectBackend.BL.Course course = new DBProjectBackend.BL.Course(courseName, creditHours, courseType, courseFee, deptID, preCourseID);
                bool flag = course.AddCourse(course);

                if (flag)
                {
                    MessageBox.Show("Course Added Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void bindcmbDepartment()
        {
            Department dept = new Department();
            List<object> departmentNames = dept.GetDepartmentNames();
            cmbDepartment.DataSource = departmentNames;
            cmbDepartment.SelectedIndex = -1;
        }

        private void bindcmbPrerequisiteCourse()
        {
            DBProjectBackend.BL.Course course = new DBProjectBackend.BL.Course();
            List<object> courseNames = course.GetCourseNames();
            cmbPrerequisiteCourse.DataSource = courseNames;
            cmbPrerequisiteCourse.SelectedIndex = -1;
        }

        private void bindcmbCourseEdit()
        {
            DBProjectBackend.BL.Course course = new DBProjectBackend.BL.Course();
            List<object> courseNames = course.GetCourseNames();
            cmbCourseEdit.DataSource = courseNames;
            cmbCourseEdit.SelectedIndex = -1;
        }

        private void kryptonLabel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //Edit Button Implementation
            try
            {
                string courseName = txtCourseName.Text.ToString().Trim();
                int creditHours = int.Parse(cmbCreditHours.Text.Trim());
                string courseType = cmbCourseType.Text.ToString().Trim();
                int courseFee = int.Parse(txtCourseFee.Text.Trim());
                string departmentName = cmbDepartment.Text.ToString().Trim();
                string prerequisiteCourse = cmbPrerequisiteCourse.SelectedItem?.ToString().Trim();
                string editCourse = cmbCourseEdit.Text.ToString().Trim();

                //Fetch DeptID because we have to store ID not Dept Name
                Department bl = new Department();
                int deptID = bl.GetDepartmentID(departmentName);

                int? preCourseID = null;
                //Fetch Prerequisite Course ID 
                if (!string.IsNullOrEmpty(prerequisiteCourse))
                {
                    DBProjectBackend.BL.Course bl1 = new DBProjectBackend.BL.Course();
                    preCourseID = bl1.GetPrerequisiteCourseID(prerequisiteCourse);
                }

                //Fetch Course ID
                DBProjectBackend.BL.Course bl2 = new DBProjectBackend.BL.Course();
                int CourseID = bl2.GetPrerequisiteCourseID(prerequisiteCourse);

                DBProjectBackend.BL.Course course = new DBProjectBackend.BL.Course(CourseID, courseName, creditHours, courseType, courseFee,preCourseID);
                bool flag = course.UpdateCourse(course);

                if (flag)
                {
                    MessageBox.Show("Course Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
