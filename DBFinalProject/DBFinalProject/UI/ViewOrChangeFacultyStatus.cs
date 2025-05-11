using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace DBFinalProject.UI
{
    public partial class ViewOrChangeFacultyStatus : DBFinalProject.UI.AdminDashboard
    {
        public ViewOrChangeFacultyStatus()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DBProjectBackend.BL.Faculty f = new DBProjectBackend.BL.Faculty();
            DataTable dt = f.GetFaculty();

            kryptonDataGridView1.DataSource = dt;

            // Add Resign Button Column
            if (!kryptonDataGridView1.Columns.Contains("btnResign"))
            {
                DataGridViewButtonColumn btnResign = new DataGridViewButtonColumn();
                btnResign.FlatStyle = FlatStyle.Flat;
                btnResign.HeaderText = "Resign";
                btnResign.Text = "Resign";
                btnResign.Name = "btnResign";
                btnResign.UseColumnTextForButtonValue = true;
                btnResign.DefaultCellStyle.BackColor = Color.Green;
                btnResign.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
                kryptonDataGridView1.Columns.Add(btnResign);
            }

            // Add Retired Button Column
            if (!kryptonDataGridView1.Columns.Contains("btnRetired"))
            {
                DataGridViewButtonColumn btnRetired = new DataGridViewButtonColumn();
                btnRetired.FlatStyle = FlatStyle.Flat;
                btnRetired.HeaderText = "Retired";
                btnRetired.Text = "Retired";
                btnRetired.Name = "btnRetired";
                btnRetired.UseColumnTextForButtonValue = true;
                btnRetired.DefaultCellStyle.BackColor = Color.Goldenrod;
                btnRetired.DefaultCellStyle.SelectionBackColor = Color.DarkGoldenrod;
                kryptonDataGridView1.Columns.Add(btnRetired);
            }
        }
        
        private void kryptonDataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(kryptonDataGridView1.Rows[e.RowIndex].Cells["UserID"].Value);
            string newStatus = null;

            if (e.ColumnIndex == kryptonDataGridView1.Columns["btnResign"].Index)
            {
                newStatus = "Resigned";
            }
            else if (e.ColumnIndex == kryptonDataGridView1.Columns["btnRetired"].Index)
            {
                newStatus = "Retired";
            }

            if (newStatus != null)
            {
                var result = MessageBox.Show($"Are you sure you want to mark this user as {newStatus}?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DBProjectBackend.BL.Faculty f = new DBProjectBackend.BL.Faculty();
                    bool success = f.UpdateUserStatus(id, newStatus);
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

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
