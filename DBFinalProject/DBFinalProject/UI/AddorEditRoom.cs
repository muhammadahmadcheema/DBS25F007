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
    public partial class AddorEditRoom : DBFinalProject.UI.AdminDashboard
    {
        public AddorEditRoom()
        {
            InitializeComponent();
            binddepartment();
            bindcmbRoomEdit();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string roomname = txtname.Text.ToString().Trim();
                string roomType = cmbtype.Text.ToString().Trim();
                int capacity = int.Parse(txtcapacity.Text.Trim());
                string departmentName = cmbdepartment.Text.ToString().Trim();

                //Fetch DeptID because we have to store ID not Dept Name
                Department bl = new Department();
                int deptID = bl.GetDepartmentID(departmentName);


                DBProjectBackend.BL.Room room = new DBProjectBackend.BL.Room(roomname, roomType, capacity, deptID);
                bool flag = room.AddRoom(room);

                if (flag)
                {
                    MessageBox.Show("Room Added Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void binddepartment()
        {
            Department dept = new Department();
            List<object> departmentNames = dept.GetDepartmentNames();
            cmbdepartment.DataSource = departmentNames;
            cmbdepartment.SelectedIndex = -1;
        }

        private void bindcmbRoomEdit()
        {
            DBProjectBackend.BL.Room room = new DBProjectBackend.BL.Room();
            List<object> roomnames = room.GetRoomNames();
            cmbeditroom.DataSource = roomnames;
            cmbeditroom.SelectedIndex = -1;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //Edit Button Implementation
            try
            {
                string roomname = txtname.Text.ToString().Trim();
                string roomType = cmbtype.Text.ToString().Trim();
                int capacity = int.Parse(txtcapacity.Text.Trim());
                string departmentName = cmbdepartment.Text.ToString().Trim();
                string editroom = cmbeditroom.Text.ToString().Trim();

                //Fetch DeptID because we have to store ID not Dept Name
                Department bl = new Department();
                int deptID = bl.GetDepartmentID(departmentName);

                //Fetch RoomID because we have to store ID not Dept Name
                Room rl = new Room();
                int roomID = rl.GetRoomID(editroom);


                DBProjectBackend.BL.Room room = new DBProjectBackend.BL.Room(roomID, roomname, roomType, capacity, deptID);
                bool flag = room.UpdateRoom(room);

                if (flag)
                {
                    MessageBox.Show("Room Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
