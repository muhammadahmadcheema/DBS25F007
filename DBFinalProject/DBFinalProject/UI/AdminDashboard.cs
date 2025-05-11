using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBProjectBackend.BL;
using DBProjectBackend;

namespace DBFinalProject.UI
{
    public partial class AdminDashboard: Form
    {        
       

        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        

        private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Node1":                    
                    AddOrEditAdmin admin = new AddOrEditAdmin();
                    admin.Show();
                    this.Hide();
                    break;                
                case "Node2":                    
                    AddOrEditFaculty faculty = new AddOrEditFaculty();
                    faculty.Show();
                    this.Hide();                  
                    break;
                case "Node3":                    
                    AddOrEditStudent student = new AddOrEditStudent();
                    student.Show();
                    this.Hide();
                    break;
                case "Node4":                    
                    AddOrEditDepartmentHead departmentHead = new AddOrEditDepartmentHead();
                    departmentHead.Show();
                    this.Hide();
                    break;
                case "Node5":                    
                    AddOrEditTechnicalStaff techStaff = new AddOrEditTechnicalStaff();
                    techStaff.Show();
                    this.Hide();
                    break;
                case "Node7":                    
                    ViewOrChangeAdminStatus adminStatus = new ViewOrChangeAdminStatus();
                    adminStatus.Show();
                    this.Hide();
                    break;
                case "Node8":                    
                    ViewOrChangeFacultyStatus facultyStatus = new ViewOrChangeFacultyStatus();
                    facultyStatus.Show();
                    this.Hide();
                    break;
                case "Node9":
                    ViewOrChangeStudentStatus studentStatus = new ViewOrChangeStudentStatus();
                    studentStatus.Show();
                    this.Hide();
                    break;
                case "Node10":
                    ViewOrChangeDepartmentHeadStatus deptHeadStatus = new ViewOrChangeDepartmentHeadStatus();
                    deptHeadStatus.Show();
                    this.Hide();
                    break;
                case "Node11":                    
                    ViewOrChangeTechnicalStaffStatus techStaffStatus = new ViewOrChangeTechnicalStaffStatus();
                    techStaffStatus.Show();
                    this.Hide();
                    break;
                case "Node12":
                    AddOrEditCourse course = new AddOrEditCourse();
                    course.Show();
                    this.Hide();
                    break;
                case "Node13":
                    ViewOrRemoveCourse removeCourse = new ViewOrRemoveCourse();
                    removeCourse.Show();
                    this.Hide();
                    break;
                case "Node15":
                    AddorEditRoom room = new AddorEditRoom();
                    room.Show();
                    this.Hide();
                    break;
                case "Node16":
                    ViewOrRemoveRoom removeRoom = new ViewOrRemoveRoom();
                    removeRoom.Show();
                    this.Hide();
                    break;
                case "Node17":
                    AddOrEditSemester semester = new AddOrEditSemester();
                    semester.Show();
                    this.Hide();
                    break;
                case "Node18":
                    ViewOrRemoveSemester removeSemester = new ViewOrRemoveSemester();
                    removeSemester.Show();
                    this.Hide();
                    break;
                case "Node21":
                    AddOrEditDepartments departments = new AddOrEditDepartments();
                    departments.Show();
                    this.Hide();
                    break;
                case "Node22":
                    ViewOrRemoveDepartment removeDepartment = new ViewOrRemoveDepartment();
                    removeDepartment.Show();
                    this.Hide();
                    break;
                case "Node23":
                    AddOrEditGrade grade = new AddOrEditGrade();
                    grade.Show();
                    this.Hide();
                    break;
                case "Node24":
                    ViewOrRemoveGrade removeGrade = new ViewOrRemoveGrade();
                    removeGrade.Show();
                    this.Hide();
                    break;
                case "Node26":
                    AssignCoursetoFaculty facultyCourse = new AssignCoursetoFaculty();
                    facultyCourse.Show();
                    this.Hide();
                    break;
                
            }
        }
    }
}
