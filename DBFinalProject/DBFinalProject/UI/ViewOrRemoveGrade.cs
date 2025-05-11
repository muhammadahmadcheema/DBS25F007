using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBFinalProject.UI
{
    public partial class ViewOrRemoveGrade : DBFinalProject.UI.AdminDashboard
    {
        public ViewOrRemoveGrade()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DBProjectBackend.BL.Grade g = new DBProjectBackend.BL.Grade();
            DataTable dt = g.GetGrades();

            kryptonDataGridView1.DataSource = dt;

            // Add Delete Button Column
            if (!kryptonDataGridView1.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();

                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.HeaderText = "Delete Grade";
                btnDelete.Text = "Delete";
                btnDelete.Name = "btnDelete";
                btnDelete.UseColumnTextForButtonValue = true;
                btnDelete.DefaultCellStyle.BackColor = Color.Red;
                btnDelete.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                kryptonDataGridView1.Columns.Add(btnDelete);
            }
        }


        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header and out-of-range clicks
            if (e.RowIndex < 0 || e.ColumnIndex != kryptonDataGridView1.Columns["btnDelete"].Index)
                return;

            // Get ID of the selected row
            int id = Convert.ToInt32(kryptonDataGridView1.Rows[e.RowIndex].Cells["GradeID"].Value);

            // Confirm deletion
            var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DBProjectBackend.BL.Grade c = new DBProjectBackend.BL.Grade();
                bool flag = c.DeleteGrade(id);
                LoadData(); // Refresh the grid
            }
        }
    }
}
