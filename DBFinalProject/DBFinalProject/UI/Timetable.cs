using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBProjectBackend.BL;
using DBProjectBackend;

namespace DBFinalProject.UI
{
	public partial class Timetable : DBFinalProject.UI.AdminDashboard
	{
		public Timetable()
		{
			InitializeComponent();
            bindcmbeditSlot();
            LoadData();

        }

        private void bindcmbeditSlot()
        {
            DBProjectBackend.BL.Timetable t = new DBProjectBackend.BL.Timetable();
            List<object> timetableSlots = t.GetTimetableSlots();
            editTimetable.DataSource = timetableSlots;
            editTimetable.SelectedIndex = -1;
        }

        private void LoadData()
        {
            DBProjectBackend.BL.Timetable t = new DBProjectBackend.BL.Timetable();
            DataTable dt = t.GetTimetableDT();

            kryptonDataGridView1.DataSource = dt;
            kryptonDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            kryptonDataGridView1.Dock = DockStyle.Fill;

            // Add Delete Button Column
            if (!kryptonDataGridView1.Columns.Contains("btnDelete"))
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();

                btnDelete.FlatStyle = FlatStyle.Flat;
                btnDelete.HeaderText = "Delete Slot";
                btnDelete.Text = "Delete";
                btnDelete.Name = "btnDelete";
                btnDelete.UseColumnTextForButtonValue = true;
                btnDelete.DefaultCellStyle.BackColor = Color.Red;
                btnDelete.DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                kryptonDataGridView1.Columns.Add(btnDelete);
            }
        }


        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan startTime = TimeSpan.Parse(txtStartTime.Text.ToString().Trim());
                TimeSpan endTime = TimeSpan.Parse(txtEndTime.Text.ToString().Trim());
                string slot = cmbType.Text.ToString().Trim();

                DBProjectBackend.BL.Timetable timetable = new DBProjectBackend.BL.Timetable(startTime, endTime, slot);
                bool flag = timetable.AddTimeTableSlot(timetable);
                if (flag)
                {
                    MessageBox.Show("Timetable Slot Added Successfully");
                }
                else
                {
                    MessageBox.Show("Timetable Slot Addition Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            TimeSpan startTime = TimeSpan.Parse(txtStartTime.Text.ToString().Trim());
            TimeSpan endTime = TimeSpan.Parse(txtEndTime.Text.ToString().Trim());
            string slot = cmbType.Text.ToString().Trim();
            string editSlot = editTimetable.Text.ToString().Trim();

            //Fetch SlotID because we have to store ID not Details 
            DBProjectBackend.BL.Timetable t = new DBProjectBackend.BL.Timetable();
            int? timeTableID = t.GetTimetableID(editSlot);

            DBProjectBackend.BL.Timetable timetable = new DBProjectBackend.BL.Timetable((int)timeTableID, startTime, endTime, slot);
            bool flag = timetable.UpdateTimetable(timetable);
            if (flag)
            {
                MessageBox.Show("Timetable Slot Updated Successfully");
            }
            else
            {
                MessageBox.Show("Timetable Slot Updation Unsuccessful");
            }
        

    }

        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header and out-of-range clicks
            if (e.RowIndex < 0 || e.ColumnIndex != kryptonDataGridView1.Columns["btnDelete"].Index)
                return;

            // Get ID of the selected row
            int id = Convert.ToInt32(kryptonDataGridView1.Rows[e.RowIndex].Cells["SlotID"].Value);

            // Confirm deletion
            var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DBProjectBackend.BL.Timetable c = new DBProjectBackend.BL.Timetable();
                bool flag = c.DeleteTimeTableSlot(id);
                LoadData(); // Refresh the grid
            }
        }
    }
}
