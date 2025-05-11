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
	public partial class AddOrEditAttendance : DBFinalProject.UI.FacultyDashboard
	{
		public AddOrEditAttendance()
		{
			InitializeComponent();
            LoadData();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            //int userID = LoggedInUser.GetUserID();

            //Student student = new Student();
            //int studentID = student.GetStudentID(userID);
            //int departmentID = student.GetDepartmentID(userID);

            //FacultyCourses courseManager = new FacultyCourses();
            //DataTable dt = courseManager.GetAllCoursesWithEnrollmentStatus(studentID, departmentID);

            //kryptonDataGridView1.DataSource = dt;
            //kryptonDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //kryptonDataGridView1.Dock = DockStyle.Fill;

            //// Add Enroll/Unenroll Button Column if it doesn't already exist
            //if (!kryptonDataGridView1.Columns.Contains("btnEnroll"))
            //{
            //    DataGridViewButtonColumn btnAction = new DataGridViewButtonColumn();
            //    btnAction.FlatStyle = FlatStyle.Flat;
            //    btnAction.HeaderText = "Action";
            //    btnAction.Name = "btnEnroll";
            //    btnAction.UseColumnTextForButtonValue = true;
            //    btnAction.DefaultCellStyle.BackColor = Color.Cyan;
            //    btnAction.DefaultCellStyle.SelectionBackColor = Color.Aqua;
            //    kryptonDataGridView1.Columns.Add(btnAction);

            //}

        }
    }
}
