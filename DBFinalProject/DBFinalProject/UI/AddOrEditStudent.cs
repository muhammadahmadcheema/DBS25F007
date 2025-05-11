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
    public partial class AddOrEditStudent : DBFinalProject.UI.AdminDashboard
    {
        public AddOrEditStudent()
        {
            InitializeComponent();
            bindcmbDepartment();
            bindcmbUserNameEdit();

        }

        private void bindcmbUserNameEdit()
        {
            DBProjectBackend.BL.Student user = new DBProjectBackend.BL.Student();
            List<object> usernames = user.GetUserNames();
            cmbedituser.DataSource = usernames;
            cmbedituser.SelectedIndex = -1;
        }

        private void bindcmbDepartment()
        {
            Department dept = new Department();
            List<object> departmentNames = dept.GetDepartmentNames();
            cmbDepartment.DataSource = departmentNames;
            cmbDepartment.SelectedIndex = -1;
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
                string role = "Student";               

                string regnum = txtregnum.Text.ToString().Trim();
                bool ishostellite = bool.Parse(cmbHostellite.Text.ToString().Trim());
                float cgpa = float.Parse(txtcgpa.Text.ToString().Trim());
                int year = int.Parse(txtsession.Text.ToString().Trim());
                string nationality = txtnationality.Text.ToString().Trim();
                string enrollmentdate = txtdate.Text.ToString().Trim();
                string sessionterm = cmbSessionTerm.Text.ToString().Trim();
                string departmentName = cmbDepartment.Text.ToString().Trim();



                //Fetch DeptID because we have to store ID not Dept Name
                Department bl = new Department();
                int deptID = bl.GetDepartmentID(departmentName);

                DBProjectBackend.BL.Student student = new DBProjectBackend.BL.Student(Password, CNIC, username, email, DOB, phone, role, Name, regnum, ishostellite, cgpa, year, nationality, enrollmentdate, sessionterm, deptID);
                bool flag = student.AddStudent(student);

                if (flag)
                {
                    MessageBox.Show("Student Added Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

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

                string regnum = txtregnum.Text.ToString().Trim();
                bool ishostellite = bool.Parse(cmbHostellite.Text.ToString().Trim());
                float cgpa = float.Parse(txtcgpa.Text.ToString().Trim());
                int year = int.Parse(txtsession.Text.ToString().Trim());
                string nationality = txtnationality.Text.ToString().Trim();
                string enrollmentdate = txtdate.Text.ToString().Trim();
                string sessionterm = cmbSessionTerm.Text.ToString().Trim();
                string departmentName = cmbDepartment.Text.ToString().Trim();
                string editUserName = cmbedituser.Text.ToString().Trim();



                //Fetch DeptID because we have to store ID not Dept Name
                Department bl = new Department();
                int deptID = bl.GetDepartmentID(departmentName);

                //Fetch UserID because we have to store ID not UserName
                User bl1 = new User();
                int userID = bl1.GetUserID(editUserName);

                DBProjectBackend.BL.Student student = new DBProjectBackend.BL.Student(userID, Password, CNIC, username, email, DOB, phone,Name, regnum, ishostellite, cgpa, year, nationality, enrollmentdate, sessionterm, deptID);
                bool flag = student.UpdateStudent(student);

                if (flag)
                {
                    MessageBox.Show("Student Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
