using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DBProjectBackend.BL;
using System.Xml.Linq;

namespace DBFinalProject.UI
{
    public partial class AddOrEditDepartmentHead : DBFinalProject.UI.AdminDashboard
    {
        public AddOrEditDepartmentHead()
        {
            InitializeComponent();            
            bindcmbDepartment();
            bindcmbUserNameEdit();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            //Add Button Implementation
            try
            {
                string Name = txtName.Text.ToString().Trim();
                string Password = txtPassword.Text.Trim();
                string CNIC = txtCNIC.Text.ToString().Trim();
                string username = txtUsername.Text.Trim();
                string email = txtEmail.Text.ToString().Trim();
                string DOB = txtDOB.Text.ToString().Trim();
                string phone = txtPhone.Text.ToString().Trim();
                string designation = "Professor";
                string researchArea = txtResearchArea.Text.ToString().Trim();
                int maxWorkingHours = int.Parse(txtMaxWorkingHours.Text.ToString().Trim());
                string qualification = txtQualification.Text.ToString().Trim();
                string departmentName = cmbDepartment.Text.ToString().Trim();
                string appointmentEndDate = txtAppointmentend.Text.ToString().Trim();

                //Fetch DeptID because we have to store ID not Dept Name
                Department bl = new Department();
                int deptID = bl.GetDepartmentID(departmentName);


                DBProjectBackend.BL.DepartmentHead depthead = new DBProjectBackend.BL.DepartmentHead(Password, CNIC, username, email, DOB, phone, "DepartmentHead", Name, designation, researchArea, maxWorkingHours, qualification, deptID,appointmentEndDate);
                bool flag = depthead.AddDepartmentHead(depthead);

                if (flag)
                {
                    MessageBox.Show("Department Head Added Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void bindcmbDepartment()
        {
            Department dept = new Department();
            List<object> departmentNames = dept.GetDepartmentNames();
            cmbDepartment.DataSource = departmentNames;
            cmbDepartment.SelectedIndex = -1;
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void bindcmbUserNameEdit()
        {
            DBProjectBackend.BL.DepartmentHead user = new DBProjectBackend.BL.DepartmentHead();
            List<object> usernames = user.GetUserNames();
            cmbeditUserName.DataSource = usernames;
            cmbeditUserName.SelectedIndex = -1;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //Add Button Implementation
            try
            {
                string Name = txtName.Text.ToString().Trim();
                string Password = txtPassword.Text.Trim();
                string CNIC = txtCNIC.Text.ToString().Trim();
                string username = txtUsername.Text.Trim();
                string email = txtEmail.Text.ToString().Trim();
                string DOB = txtDOB.Text.ToString().Trim();
                string phone = txtPhone.Text.ToString().Trim();
                string designation = "Professor";
                string researchArea = txtResearchArea.Text.ToString().Trim();
                int maxWorkingHours = int.Parse(txtMaxWorkingHours.Text.ToString().Trim());
                string qualification = txtQualification.Text.ToString().Trim();
                string departmentName = cmbDepartment.Text.ToString().Trim();
                string appointmentEndDate = txtAppointmentend.Text.ToString().Trim();
                string editUserName = cmbeditUserName.Text.ToString().Trim();

                //Fetch DeptID because we have to store ID not Dept Name
                Department bl = new Department();
                int deptID = bl.GetDepartmentID(departmentName);

                //Fetch UserID because we have to store ID not UserName
                User bl1 = new User();
                int userID = bl1.GetUserID(editUserName);


                DBProjectBackend.BL.DepartmentHead depthead = new DBProjectBackend.BL.DepartmentHead(userID,Password, CNIC, username, email, DOB, phone, Name, designation, researchArea, maxWorkingHours, qualification, deptID, appointmentEndDate);
                bool flag = depthead.UpdateDepartmentHead(depthead);

                if (flag)
                {
                    MessageBox.Show("Department Head Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Department Head Updation UnSuccessful. One Department can have only one department head");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
