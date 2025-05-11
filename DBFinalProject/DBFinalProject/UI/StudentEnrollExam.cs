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
	public partial class StudentEnrollExam : DBFinalProject.UI.StudentDashboard
	{
		public StudentEnrollExam()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            int userID = LoggedInUser.GetUserID();

            Student student = new Student();
            int studentID = student.GetStudentID(userID);
            int departmentID = student.GetDepartmentID(userID);

            Examination examManager = new Examination();
            DataTable dt = examManager.GetAllExamsWithEnrollmentStatus(studentID, departmentID);

            kryptonDataGridView1.DataSource = dt;
            kryptonDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            kryptonDataGridView1.Dock = DockStyle.Fill;

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
        
        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || kryptonDataGridView1.Columns[e.ColumnIndex].Name != "btnEnroll")
                return;

            DataGridViewRow row = kryptonDataGridView1.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["ExamID"].Value);
            bool isEnrolled = Convert.ToBoolean(row.Cells["IsEnrolled"].Value);

            var confirmText = isEnrolled ? "unenroll from" : "enroll in";
            var result = MessageBox.Show($"Are you sure you want to {confirmText} this course?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                StudentEnrolledExam enrollmentManager = new StudentEnrolledExam();
                if (isEnrolled)
                {
                    int studentExamEnrollment = enrollmentManager.GetStudentExamEnrollmentID(id);
                    enrollmentManager.DeleteEnrollment(studentExamEnrollment);
                }
                else
                {
                    int userID = LoggedInUser.GetUserID();
                    Student s = new Student();
                    int studentID = s.GetStudentID(userID);
                    StudentEnrolledExam stdexam = new DBProjectBackend.BL.StudentEnrolledExam(studentID, id, 0, null);
                    bool flag = stdexam.AddEnrollment(stdexam);
                }

                LoadData(); // Refresh
            }
        }

        private void kryptonDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (kryptonDataGridView1.Columns[e.ColumnIndex].Name == "btnEnroll" && e.RowIndex >= 0)
            {
                bool isEnrolled = Convert.ToBoolean(kryptonDataGridView1.Rows[e.RowIndex].Cells["IsEnrolled"].Value);
                e.Value = isEnrolled ? "Unenroll" : "Enroll";
            }
        }
    }
}
