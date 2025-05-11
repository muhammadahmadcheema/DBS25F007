using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using DBProjectBackend.BL;
using System.Xml.Linq;

namespace DBFinalProject.UI
{
    public partial class AddOrEditSemester : DBFinalProject.UI.AdminDashboard
    {
        public AddOrEditSemester()
        {
            InitializeComponent();
            bindcmbSemesterEdit();
        }

        private void kryptonLabel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {                
                int year = int.Parse(txtyear.Text.Trim());
                string term = cmbterm.Text.ToString().Trim();
                
                DBProjectBackend.BL.Semester semester = new DBProjectBackend.BL.Semester(year, term);
                bool flag = semester.AddSemester(semester);

                if (flag)
                {
                    MessageBox.Show("Semester Added Successfully");
                }
                else
                {
                    MessageBox.Show("Semester Exist Already");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void bindcmbSemesterEdit()
        {
            DBProjectBackend.BL.Semester semester = new DBProjectBackend.BL.Semester();
            List<object> semesternames = semester.GetSemesterNames();
            cmbeditsemester.DataSource = semesternames;
            cmbeditsemester.SelectedIndex = -1;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            //Edit Button Implementation
            try
            {
                int year = int.Parse(txtyear.Text.Trim());
                string term = cmbterm.Text.ToString().Trim();
                string editsemester = cmbeditsemester.Text.ToString().Trim();
                
                //Fetch SemesterID because we have to store ID not Semester Name
                Semester s1 = new Semester();
                int? SemesterID = s1.GetSemesterID(editsemester);


                DBProjectBackend.BL.Semester semester = new DBProjectBackend.BL.Semester((int)SemesterID, year, term);
                bool flag = semester.UpdateSemester(semester);

                if (flag)
                {
                    MessageBox.Show("Semester Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Semester Exist Already");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
