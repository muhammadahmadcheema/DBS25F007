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
	public partial class GenerateFeeChallan : DBFinalProject.UI.AdminDashboard
	{
		public GenerateFeeChallan()
		{
            InitializeComponent();
            bindcmbStudent();
            bindcmbSemester();
        }

        private void bindcmbSemester()
        {
            DBProjectBackend.BL.Semester semester = new DBProjectBackend.BL.Semester();
            List<object> semesternames = semester.GetSemesterNames();
            cmbSemester.DataSource = semesternames;
            cmbSemester.SelectedIndex = -1;
        }

        private void bindcmbStudent()
        {
            DBProjectBackend.BL.Student user = new DBProjectBackend.BL.Student();
            List<object> usernames = user.GetUserNames();
            cmbStudent.DataSource = usernames;
            cmbStudent.SelectedIndex = -1;
        }


        private void kryptonLabel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string Semester = cmbSemester.Text.ToString().Trim();
                string IssueDate = txtIssueDate.Text.Trim();
                string DueDate = txtDueDate.Text.Trim();
                int TotalAmount = int.Parse(txtTotalAmount.Text.Trim());
                string Status = cmbStatus.Text.ToString().Trim();
                string StudentName = cmbStudent.Text.ToString().Trim();

                //Fetch SemesterID because we have to store ID not Semester Name
                Semester s1 = new Semester();
                int? SemesterID = s1.GetSemesterID(Semester);

                //Fetch UserID because we have to store ID not UserName
                User bl1 = new User();
                int userID = bl1.GetUserID(StudentName);

                //Fetch StudentID because we have to store ID not Student Name
                Student s2 = new Student();
                int StudentID = s2.GetStudentID(userID);



                DBProjectBackend.BL.FeeChallan challan = new DBProjectBackend.BL.FeeChallan(SemesterID, IssueDate, DueDate, TotalAmount, Status, StudentID);
                bool flag = challan.AddChallan(challan);

                if (flag)
                {
                    MessageBox.Show("Fee Challlan Added Successfully");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
    
}
