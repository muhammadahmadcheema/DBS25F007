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
using DBFinalProject.UI;


namespace DBFinalProject
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThemeForm paletteForm = new ThemeForm();
            kryptonManager1.GlobalPalette = paletteForm.MyPalette;

           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonGroupBox1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            try
            {
                //LogIN Button Implementaion            
                string username = txtUsername.Text.Trim(); // Removes extra spaces
                string password = txtPassword.Text.Trim();

                // Check if username or password is empty
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.");
                    return;
                }

                // Hash the entered password using the PasswordHelper class
                string hashedPassword = HashingHelper.HashPassword(password);

                User user = new User();
                var role = user.GetUserRole(username, hashedPassword);
                var UserID = user.GetUserID(username, hashedPassword);

                if (role != null && UserID != null)
                {
                    LoggedInUser.SetUsername((string)username);
                    LoggedInUser.SetUserID((int)UserID);
                }

                // Authenticate the user with the database            
                if (role != null && (string)role == "Admin")
                {
                    MessageBox.Show("Login successful!");
                    AdminDashboard admin = new AdminDashboard();
                    admin.Show();
                    this.Hide();
                }
                else if (role != null && (string)role == "Faculty")
                {
                    MessageBox.Show("Login successful!");
                    FacultyDashboard faculty = new FacultyDashboard();
                    faculty.Show();
                    this.Hide();
                }
                else if (role != null && (string)role == "Student")
                {
                    MessageBox.Show("Login successful!");
                    StudentDashboard student = new StudentDashboard();
                    student.Show();
                    this.Hide();
                }
                else if (role != null && (string)role == "TechnicalStaff")
                {
                    MessageBox.Show("Login successful!");
                    TechnicalStaffDashboard staff = new TechnicalStaffDashboard();
                    staff.Show();
                    this.Hide();
                }                
                else
                {
                    MessageBox.Show("Invalid credentials or incorrect role.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
    }

