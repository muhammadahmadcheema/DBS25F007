using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBProjectBackend;
using DBProjectBackend.BL;

namespace DBFinalProject.UI
{
    public partial class AddOrEditTechnicalStaff : DBFinalProject.UI.AdminDashboard
    {
        public AddOrEditTechnicalStaff()
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
                string role = "TechnicalStaff";                
                string hiredate = txthiredate.Text.ToString().Trim();
                string specialization = txtspecialization.Text.ToString().Trim();


                DBProjectBackend.BL.TechnicalStaff ts = new DBProjectBackend.BL.LogHandler(Password, CNIC, username, email, DOB, phone, role, Name, hiredate, specialization);
                bool flag = ts.AddTechnicalStaff(ts);

                if (flag)
                {
                    MessageBox.Show("Technical Staff Added Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void bindcmbUserNameEdit()
        {
            DBProjectBackend.BL.TechnicalStaff ts = new DBProjectBackend.BL.LogHandler();
            List<object> usernames = ts.GetUserNames();
            cmbedituser.DataSource = usernames;
            cmbedituser.SelectedIndex = -1;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //Edit Button Implementation
            try
            {
                string Name = txtname.Text.ToString().Trim();
                string Password = txtpassword.Text.Trim();
                string CNIC = txtcnic.Text.ToString().Trim();
                string username = txtusername.Text.Trim();
                string email = txtemail.Text.ToString().Trim();
                string DOB = txtdob.Text.ToString().Trim();
                string phone = txtphone.Text.ToString().Trim();                              
                string hiredate = txthiredate.Text.ToString().Trim();
                string specialization = txtspecialization.Text.ToString().Trim();
                string editUserName = cmbedituser.Text.ToString().Trim();


                //Fetch UserID because we have to store ID not UserName
                User bl1 = new User();
                int userID = bl1.GetUserID(editUserName);

                DBProjectBackend.BL.TechnicalStaff ts = new DBProjectBackend.BL.LogHandler(userID, Password, CNIC, username, email, DOB, phone,Name, hiredate, specialization);
                bool flag = ts.UpdateTechnicalStaff(ts);

                if (flag)
                {
                    MessageBox.Show("Technical Staff Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
