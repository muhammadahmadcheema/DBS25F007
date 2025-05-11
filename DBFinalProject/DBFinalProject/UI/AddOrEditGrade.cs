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
    public partial class AddOrEditGrade : DBFinalProject.UI.AdminDashboard
    {
        public AddOrEditGrade()
        {
            InitializeComponent();
            bindcmbGradeEdit();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string gradeName = txtName.Text.ToString().Trim();
                float gradePoints = float.Parse(txtPoints.Text.Trim());
                string editGrade = cmbGradeEdit.Text.ToString().Trim();

                //Fetch GradeID because we have to store ID not Grade Name
                Grade bl = new Grade();
                int gradeID = bl.GetGradeID(gradeName);

                DBProjectBackend.BL.Grade grade = new DBProjectBackend.BL.Grade(gradeID, gradeName, gradePoints);
                bool flag = grade.UpdateGrade(grade);

                if (flag)
                {
                    MessageBox.Show("Grade Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string gradeName = txtName.Text.ToString().Trim();
                float gradePoints = float.Parse(txtPoints.Text.Trim());                
                
                DBProjectBackend.BL.Grade grade = new DBProjectBackend.BL.Grade(gradeName, gradePoints);
                bool flag = grade.AddGrade(grade);

                if (flag)
                {
                    MessageBox.Show("Grade Added Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void bindcmbGradeEdit()
        {
            DBProjectBackend.BL.Grade grade = new DBProjectBackend.BL.Grade();
            List<object> gradeNames = grade.GetGradeNames();
            cmbGradeEdit.DataSource = gradeNames;
            cmbGradeEdit.SelectedIndex = -1;
        }
    }
}
