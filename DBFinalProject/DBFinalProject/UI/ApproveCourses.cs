using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBFinalProject.UI
{
	public partial class ApproveCourses : DBFinalProject.UI.DepartmentHeadDashboard
	{
		public ApproveCourses()
		{
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DBProjectBackend.BL.Course f = new DBProjectBackend.BL.Course();
            DataTable dt = f.GetCourses();

            kryptonDataGridView1.DataSource = dt;

            // Add Approved Button Column
            if (!kryptonDataGridView1.Columns.Contains("btnApproved"))
            {
                DataGridViewButtonColumn btnResign = new DataGridViewButtonColumn();
                btnResign.FlatStyle = FlatStyle.Flat;
                btnResign.HeaderText = "Approved";
                btnResign.Text = "Approved";
                btnResign.Name = "btnApproved";
                btnResign.UseColumnTextForButtonValue = true;
                btnResign.DefaultCellStyle.BackColor = Color.Green;
                btnResign.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
                kryptonDataGridView1.Columns.Add(btnResign);
            }

            // Add Pending For Approval Button Column
            if (!kryptonDataGridView1.Columns.Contains("btnPendingForApproval"))
            {
                DataGridViewButtonColumn btnRetired = new DataGridViewButtonColumn();
                btnRetired.FlatStyle = FlatStyle.Flat;
                btnRetired.HeaderText = "Pending For Approval";
                btnRetired.Text = "Pending For Approval";
                btnRetired.Name = "btnPendingForApproval";
                btnRetired.UseColumnTextForButtonValue = true;
                btnRetired.DefaultCellStyle.BackColor = Color.Goldenrod;
                btnRetired.DefaultCellStyle.SelectionBackColor = Color.DarkGoldenrod;
                kryptonDataGridView1.Columns.Add(btnRetired);
            }
        }


        private void kryptonDataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(kryptonDataGridView1.Rows[e.RowIndex].Cells["CourseID"].Value);
            string newStatus = null;

            if (e.ColumnIndex == kryptonDataGridView1.Columns["btnApproved"].Index)
            {
                newStatus = "Approved";
            }
            else if (e.ColumnIndex == kryptonDataGridView1.Columns["btnPendingForApproval"].Index)
            {
                newStatus = "Pending For Approval";
            }

            if (newStatus != null)
            {
                var result = MessageBox.Show($"Are you sure you want to mark this user as {newStatus}?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DBProjectBackend.BL.Course f = new DBProjectBackend.BL.Course();
                    bool success = f.UpdateCourseStatus(id, newStatus);
                    if (success)
                    {
                        MessageBox.Show("Status updated successfully.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update status.");
                    }
                }
            }

        }
    }
}
