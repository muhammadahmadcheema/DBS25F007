using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using DBProjectBackend.BL;

namespace DBFinalProject.UI
{
    public partial class AddOrEditDepartments : DBFinalProject.UI.AdminDashboard
    {
        public AddOrEditDepartments()
        {
            InitializeComponent();
            binddepartment();
        }

        private void AddOrEditDepartments_Load(object sender, EventArgs e)
        {

        }

        private void kryptonLabel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string departmentname = txtname.Text.ToString().Trim();
                string departmentcode = txtcode.Text.ToString().Trim();
                
                DBProjectBackend.BL.Department department = new DBProjectBackend.BL.Department(departmentname, departmentcode);
                bool flag = department.AddDepartment(department);

                if (flag)
                {
                    MessageBox.Show("Department Added Successfully");
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
            cmbeditdepartment.DataSource = departmentNames;
            cmbeditdepartment.SelectedIndex = -1;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //Edit Button Implementation
            try
            {
                string departmentname = txtname.Text.ToString().Trim();
                string departmentcode = txtcode.Text.ToString().Trim();
                string editdepartment = cmbeditdepartment.Text.ToString().Trim();

                //Fetch DeptID because we have to store ID not Dept Name
                Department bl = new Department();
                int deptID = bl.GetDepartmentID(editdepartment);                

                DBProjectBackend.BL.Department department = new DBProjectBackend.BL.Department(deptID, departmentname, departmentcode);
                bool flag = department.UpdateDepartment(department);

                if (flag)
                {
                    MessageBox.Show("Department Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
