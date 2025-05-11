using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBFinalProject.UI
{
    public partial class ViewOrChangeStudentStatus : DBFinalProject.UI.AdminDashboard
    {
        public ViewOrChangeStudentStatus()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DBProjectBackend.BL.Student s = new DBProjectBackend.BL.Student();
            DataTable dt = s.GetStudents();

            kryptonDataGridView1.DataSource = dt;

            // Add SemesterFreezed Button Column
            if (!kryptonDataGridView1.Columns.Contains("btnSemesterFreezed"))
            {
                DataGridViewButtonColumn btnSemesterFreezed = new DataGridViewButtonColumn();
                btnSemesterFreezed.FlatStyle = FlatStyle.Flat;
                btnSemesterFreezed.HeaderText = "SemesterFreezed";
                btnSemesterFreezed.Text = "SemesterFreezed";
                btnSemesterFreezed.Name = "btnSemesterFreezed";
                btnSemesterFreezed.UseColumnTextForButtonValue = true;
                btnSemesterFreezed.DefaultCellStyle.BackColor = Color.Green;
                btnSemesterFreezed.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
                kryptonDataGridView1.Columns.Add(btnSemesterFreezed);
            }

            // Add Graduated Button Column
            if (!kryptonDataGridView1.Columns.Contains("btnGraduated"))
            {
                DataGridViewButtonColumn btnGraduated = new DataGridViewButtonColumn();
                btnGraduated.FlatStyle = FlatStyle.Flat;
                btnGraduated.HeaderText = "Graduated";
                btnGraduated.Text = "Graduated";
                btnGraduated.Name = "btnGraduated";
                btnGraduated.UseColumnTextForButtonValue = true;
                btnGraduated.DefaultCellStyle.BackColor = Color.Goldenrod;
                btnGraduated.DefaultCellStyle.SelectionBackColor = Color.DarkGoldenrod;
                kryptonDataGridView1.Columns.Add(btnGraduated);
            }
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(kryptonDataGridView1.Rows[e.RowIndex].Cells["UserID"].Value);
            string newStatus = null;

            if (e.ColumnIndex == kryptonDataGridView1.Columns["btnSemesterFreezed"].Index)
            {
                newStatus = "SemesterFreezed";
            }
            else if (e.ColumnIndex == kryptonDataGridView1.Columns["btnGraduated"].Index)
            {
                newStatus = "Graduated";
            }

            if (newStatus != null)
            {
                var result = MessageBox.Show($"Are you sure you want to mark this user as {newStatus}?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DBProjectBackend.BL.Student s = new DBProjectBackend.BL.Student();
                    bool success = s.UpdateUserStatus(id, newStatus);
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
