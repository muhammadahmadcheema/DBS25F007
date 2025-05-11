using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBFinalProject.UI
{
	public partial class ViewOrChangeChallanStatus : DBFinalProject.UI.AdminDashboard
	{
		public ViewOrChangeChallanStatus()
		{
            InitializeComponent();
            LoadData();

        }


        private void LoadData()
        {
            DBProjectBackend.BL.FeeChallan f = new DBProjectBackend.BL.FeeChallan();
            DataTable dt = f.GetFeeChallan();

            kryptonDataGridView1.DataSource = dt;

            // Add Unpaid Button Column
            if (!kryptonDataGridView1.Columns.Contains("btnUnpaid"))
            {
                DataGridViewButtonColumn btnResign = new DataGridViewButtonColumn();
                btnResign.FlatStyle = FlatStyle.Flat;
                btnResign.HeaderText = "Unpaid";
                btnResign.Text = "Unpaid";
                btnResign.Name = "btnUnpaid";
                btnResign.UseColumnTextForButtonValue = true;
                btnResign.DefaultCellStyle.BackColor = Color.Green;
                btnResign.DefaultCellStyle.SelectionBackColor = Color.DarkGreen;
                kryptonDataGridView1.Columns.Add(btnResign);
            }

            // Add Paid Button Column
            if (!kryptonDataGridView1.Columns.Contains("btnPaid"))
            {
                DataGridViewButtonColumn btnRetired = new DataGridViewButtonColumn();
                btnRetired.FlatStyle = FlatStyle.Flat;
                btnRetired.HeaderText = "Paid";
                btnRetired.Text = "Paid";
                btnRetired.Name = "btnPaid";
                btnRetired.UseColumnTextForButtonValue = true;
                btnRetired.DefaultCellStyle.BackColor = Color.Goldenrod;
                btnRetired.DefaultCellStyle.SelectionBackColor = Color.DarkGoldenrod;
                kryptonDataGridView1.Columns.Add(btnRetired);
            }
        }


        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int id = Convert.ToInt32(kryptonDataGridView1.Rows[e.RowIndex].Cells["ChallanID"].Value);
            string newStatus = null;

            if (e.ColumnIndex == kryptonDataGridView1.Columns["btnUnpaid"].Index)
            {
                newStatus = "Unpaid";
            }
            else if (e.ColumnIndex == kryptonDataGridView1.Columns["btnPaid"].Index)
            {
                newStatus = "Paid";
            }

            if (newStatus != null)
            {
                var result = MessageBox.Show($"Are you sure you want to mark this user as {newStatus}?", "Confirm", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DBProjectBackend.BL.FeeChallan f = new DBProjectBackend.BL.FeeChallan();
                    bool success = f.UpdateChallanStatus(id, newStatus);
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
