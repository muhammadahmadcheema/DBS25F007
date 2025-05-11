using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFinalProject.UI
{
    public partial class FacultyDashboard : Form
    {
        public FacultyDashboard()
        {
            InitializeComponent();
        }

        private void kryptonHeader1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch(e.Node.Name)
            { 
            /*case "Node0":
                MarkClassAttendance attendance = new MarkClassAttendance();
                attendance.Show();
                this.Hide();
                break;
            case "Node1":
                UploadResults results = new UploadResults();
                results.Show();
                this.Hide();
                break;
            case "Node2":
                PersonalTimetable personaltimetable = new PersonalTimetable();
                personaltimetable.Show();
                this.Hide();
                break;*/
            case "Node3":
                CreateOrEditExams exams = new CreateOrEditExams();
                exams.Show();
                this.Hide();
                break;
            }
        }
    }
}
