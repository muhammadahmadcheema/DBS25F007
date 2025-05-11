using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DBProjectBackend.BL;

namespace DBFinalProject.UI
{
	public partial class AddOrEditFaculty : DBFinalProject.UI.AdminDashboard
	{
		public AddOrEditFaculty()
		{
			InitializeComponent();
            bindcmbDepartment();
            bindcmbUserNameEdit();
        }

        private void kryptonLabel12_Paint(object sender, PaintEventArgs e)
        {

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
                string designation = cmbDesignation.Text.ToString().Trim();
                string researchArea = txtResearchArea.Text.ToString().Trim();
                int maxWorkingHours = int.Parse(txtMaxWorkingHours.Text.ToString().Trim());
                string qualification = txtQualification.Text.ToString().Trim();
                string departmentName = cmbDepartment.Text.ToString().Trim();

                //Fetch DeptID because we have to store ID not Dept Name
                Department bl = new Department();
                int deptID = bl.GetDepartmentID(departmentName);


                DBProjectBackend.BL.Faculty faculty = new DBProjectBackend.BL.Faculty(Password, CNIC, username, email, DOB, phone, "Faculty", Name, designation, researchArea, maxWorkingHours, qualification, deptID);
                bool flag = faculty.AddFaculty(faculty);

                if (flag)
                {
                    MessageBox.Show("Faculty Added Successfully");
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
                string designation = cmbDesignation.Text.ToString().Trim();
                string researchArea = txtResearchArea.Text.ToString().Trim();
                int maxWorkingHours = int.Parse(txtMaxWorkingHours.Text.ToString().Trim());
                string qualification = txtQualification.Text.ToString().Trim();
                string departmentName = cmbDepartment.Text.ToString().Trim();
                string editUserName = cmbeditUserName.Text.ToString().Trim();
                
                //Fetch DeptID because we have to store ID not Dept Name
                Department bl = new Department();
                int deptID = bl.GetDepartmentID(departmentName);

                //Fetch UserID because we have to store ID not UserName
                User bl1 = new User();
                int userID = bl1.GetUserID(editUserName);


                DBProjectBackend.BL.Faculty faculty = new DBProjectBackend.BL.Faculty(userID, Password, CNIC, username, email, DOB, phone, Name, designation, researchArea, maxWorkingHours, qualification, deptID);
                bool flag = faculty.UpdateFaculty(faculty);

                if (flag)
                {
                    MessageBox.Show("Faculty Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void bindcmbUserNameEdit()
        {
            DBProjectBackend.BL.Faculty user = new DBProjectBackend.BL.Faculty();
            List<object> usernames = user.GetUserNames();
            cmbeditUserName.DataSource = usernames;
            cmbeditUserName.SelectedIndex = -1;
        }
    }
}

