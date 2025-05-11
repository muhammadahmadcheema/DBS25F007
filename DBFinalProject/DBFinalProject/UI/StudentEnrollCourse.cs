using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBProjectBackend.BL;

namespace DBFinalProject.UI
{
    public partial class StudentEnrollCourse : DBFinalProject.UI.StudentDashboard
    {
        public StudentEnrollCourse()
        {
            InitializeComponent();
            LoadData();
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string Name = txtCourseName.Text.ToString().Trim();
            int userID = LoggedInUser.GetUserID();

            Student s = new Student();
            int studentID = s.GetStudentID(userID);
            int LoggedINStudentdeptID = s.GetDepartmentID(userID);
            FacultyCourses bl = new FacultyCourses();
            DataTable dt = bl.GetAllFacultyCoursesByName(studentID, LoggedINStudentdeptID, Name);
            kryptonDataGridView1.DataSource = dt;

        }

        private void LoadData()
        {            
            int userID = LoggedInUser.GetUserID();

            Student student = new Student();
            int studentID = student.GetStudentID(userID);
            int departmentID = student.GetDepartmentID(userID);

            FacultyCourses courseManager = new FacultyCourses();
            DataTable dt = courseManager.GetAllCoursesWithEnrollmentStatus(studentID, departmentID);

            kryptonDataGridView1.DataSource = dt;

            // Add Enroll/Unenroll Button Column if it doesn't already exist
            if (!kryptonDataGridView1.Columns.Contains("btnEnroll"))
            {
                DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn();
                btnAction.FlatStyle = FlatStyle.Flat;
                btnAction.HeaderText = "Action";
                btnAction.Name = "btnEnroll";
                btnAction.UseColumnTextForButtonValue = true;
                btnAction.DefaultCellStyle.BackColor = Color.Cyan;
                btnAction.DefaultCellStyle.SelectionBackColor = Color.Aqua;
                kryptonDataGridView1.Columns.Add(btnAction);

            }

        }

        private void kryptonDataGridView1_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (kryptonDataGridView1.Columns[e.ColumnIndex].Name == "btnEnroll" && e.RowIndex >= 0)
            {
                bool isEnrolled = Convert.ToBoolean(kryptonDataGridView1.Rows[e.RowIndex].Cells["IsEnrolled"].Value);
                e.Value = isEnrolled ? "Unenroll" : "Enroll";
            }
        }

        private void kryptonDataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || kryptonDataGridView1.Columns[e.ColumnIndex].Name != "btnEnroll")
                return;

            DataGridViewRow row = kryptonDataGridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["FacultyCourseID"].Value);
            bool isEnrolled = Convert.ToBoolean(row.Cells["IsEnrolled"].Value);

            var confirmText = isEnrolled ? "unenroll from" : "enroll in";
            var result = MessageBox.Show($"Are you sure you want to {confirmText} this course?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                StudentCoursesEnrollment enrollmentManager = new StudentCoursesEnrollment();
                if (isEnrolled)
                {
                    int studentCourseEnrollment = enrollmentManager.GetStudentCourseEnrollmentID(id);
                    enrollmentManager.DeleteEnrollment(studentCourseEnrollment);
                }
                else
                {
                    int userID = LoggedInUser.GetUserID();
                    Student s = new Student();
                    int studentID = s.GetStudentID(userID);
                    StudentCoursesEnrollment stdcourse = new DBProjectBackend.BL.StudentCoursesEnrollment(studentID, id);
                    bool flag = stdcourse.AddEnrollment(stdcourse);
                }

                LoadData(); // Refresh
            }
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudentEnrollCourse_Load(object sender, EventArgs e)
        {

        }
    }
}
