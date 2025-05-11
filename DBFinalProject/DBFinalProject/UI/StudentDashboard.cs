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
    public partial class StudentDashboard: Form
    {        
        public StudentDashboard()
        {
            InitializeComponent();
        }
        
        private void kryptonTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {

        }

        private void kryptonTreeView1_MouseClick(object sender, MouseEventArgs e)
        {

        }
       
        private void kryptonTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return; // Only handle left-click

            switch (e.Node.Name)
            {
                case "Node0":
                    var form = new StudentEnrollCourse();
                    form.FormClosed += (s, args) =>
                    {
                        this.Show();
                    };
                    form.Show();
                    this.Hide();
                    break;

                case "Node1":
                    var deptForm = new AddOrEditDepartmentHead();
                    deptForm.FormClosed += (s, args) =>
                    {
                        this.Show();
                    };
                    deptForm.Show();
                    this.Hide();
                    break;
                case "Node6":
                    var examForm = new StudentEnrollExam();
                    examForm.FormClosed += (s, args) =>
                    {
                        this.Show();
                    };
                    examForm.Show();
                    this.Hide();
                    break;
            }

        }
    }
}
