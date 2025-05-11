using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBProjectBackend.BL;
using System.Xml.Linq;
using DBProjectBackend;

namespace DBFinalProject.UI
{
    public partial class AddOrEditAdmin : DBFinalProject.UI.AdminDashboard
    {
        public AddOrEditAdmin()
        {
            InitializeComponent();
            bindcmbUserNameEdit();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            //Add Button Implementation
            try
            {
                string Name = txtname.Text.ToString().Trim();
                string Password = txtpassword.Text.Trim();
                string CNIC = txtcnic.Text.ToString().Trim();
                string username = txtusername.Text.Trim();
                string email = txtemail.Text.ToString().Trim();
                string DOB = txtdob.Text.ToString().Trim();
                string phone = txtphone.Text.ToString().Trim();
                string role = "Admin";
                                
                DBProjectBackend.BL.User user = new DBProjectBackend.BL.User(Password, CNIC, username, email, DOB, phone, role, Name);
                bool flag = user.AddUser(user);

                if (flag)
                {
                    MessageBox.Show("Admin Added Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //Add Button Implementation
            try
            {
                string Name = txtname.Text.ToString().Trim();
                string Password = txtpassword.Text.Trim();
                string CNIC = txtcnic.Text.ToString().Trim();
                string username = txtusername.Text.Trim();
                string email = txtemail.Text.ToString().Trim();
                string DOB = txtdob.Text.ToString().Trim();
                string phone = txtphone.Text.ToString().Trim();
                string editUserName = cmbedituser.Text.ToString().Trim();
                               
                //Fetch UserID because we have to store ID not UserName
                User bl1 = new User();
                int userID = bl1.GetUserID(editUserName);


                DBProjectBackend.BL.User user = new DBProjectBackend.BL.User(userID,Password, CNIC, username, email, DOB, phone, Name);
                bool flag = user.UpdateUser(user);

                if (flag)
                {
                    MessageBox.Show("Admin Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void bindcmbUserNameEdit()
        {
            DBProjectBackend.BL.User user = new DBProjectBackend.BL.User();
            List<object> usernames = user.GetAdminUserNames();
            cmbedituser.DataSource = usernames;
            cmbedituser.SelectedIndex = -1;
        }
    }
}
