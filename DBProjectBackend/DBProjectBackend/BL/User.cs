using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DBProjectBackend.BL
{
    public class User
    {
        protected int UserID;
        protected string Password_Hash;
        protected string CNIC;
        protected string Username;
        protected string Email;
        protected string DOB;
        protected string Phone;
        protected string Status;
        protected string Role;
        protected string Name;
        protected string CreatedDate;

        public User()
        { }

        public User(string username)
        {
            this.Username = username;
        }

        public User(string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Role, string Name)  // Will be used for Adding 
        {            
            SetPassword(Password);
            SetCNIC(CNIC);
            SetUsername(Username);
            SetEmail(Email);
            SetDOB(DOB);
            SetPhone(Phone);
            this.Role = Role;
            SetName(Name);
            this.Status = "Present";
            this.CreatedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public User(int UserID,string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Name)  // Will be Used For Updating
        {            
            this.UserID = UserID;
            SetPassword(Password);
            SetCNIC(CNIC);
            SetUsername(Username);
            SetEmail(Email);
            SetDOB(DOB);
            SetPhone(Phone);            
            SetName(Name);                      
        }

        public bool AddUser(string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Role, string Name)
        {
            bool flag = DL.User.AddUsertoDB(Password, CNIC, Username, Email, DOB, Phone,Role, Name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return flag;
        }

        public bool AddUser(User u)
        {
            bool flag = DL.User.AddUsertoDB(u.GetPasswordHash(), u.GetCNIC(), u.GetUsername(),u.GetEmail(), u.GetDOB(), u.GetPhone(), u.GetRole(), u.GetName(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return flag;
        }

        public DataTable GetAdminsTable()
        {
            DataTable dt = DL.User.GetAllAdmins();
            return dt;
        }

        public DataTable GetUsersTable()
        {
            DataTable dt = DL.User.GetAllUsers();
            return dt;
        }

        public bool UpdateUser(int UserID, string Password, string CNIC, string Username, string Email, string DOB, string Phone, string Name)
        {
            bool flag = DL.User.UpdateUsertoDB(UserID, Password, CNIC, Username, Email, DOB, Phone, Name);
            return flag;
        }

        public bool UpdateUser(User u)
        {
            bool flag = DL.User.UpdateUsertoDB(u.GetUserID(), u.GetPasswordHash(), u.GetCNIC(), u.GetUsername(), u.GetEmail(), u.GetDOB(), u.GetPhone(), u.GetName());
            return flag;
        }

        public int GetUserID(string userName)
        {
            DL.User dl = new DL.User();
            return dl.GetUserIDFromDB(userName);
        }

        public object GetUserID(string username, string hashedpassword)
        {
            DL.User dl = new DL.User();
            return dl.GetUserIDFromDB(username, hashedpassword);
        }

        public object GetUserRole(string username, string hashedpassword)
        {
            DL.User dl = new DL.User();
            return dl.GetUserRoleFromDB(username, hashedpassword);
        }

        public virtual List<object> GetUserNames()
        {
            DL.User dl = new DL.User();
            List<object> userNames = dl.GetUserNamesFromDB();
            return userNames;
        }

        public List<object> GetAdminUserNames()
        {
            DL.User dl = new DL.User();
            List<object> userNames = dl.GetAdminUserNamesFromDB();
            return userNames;
        }

        public int GetUserID()
        {
            return UserID;
        }

        public string GetPasswordHash()
        {
            return Password_Hash;
        }

        public string GetCNIC()
        {
            return CNIC;
        }

        public string GetUsername()       
        {
            return Username;
        }

        public string GetEmail()
        {
            return Email ;
        }

        public string GetDOB()
        {
            return DOB;
        }

        public string GetPhone()
        {
            return Phone;
        }

        public string GetStatus()
        {
            return Status;
        }

        public string GetRole()
        {
            return Role;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetCreatedDate()
        {
            return CreatedDate;
        }

        public void SetCNIC(string CNIC)
        {
            if (CNIC.Length != 13)
            {
                throw new ArgumentException("CNIC must be exactly 13 digits long.");
            }

            if (!CNIC.All(char.IsDigit))
            {
                throw new ArgumentException("CNIC must contain only numeric digits.");
            }

            this.CNIC = CNIC;                        
        }

        public void SetPassword(string Password)
        {                                
            if (Password.Length < 8 && Password.Length > 20)
            {
                throw new ArgumentException("Password must be at least 8 characters long.");
            }
            
            if (!Password.Any(char.IsUpper))
            {
                throw new ArgumentException("Password must contain at least one uppercase letter.");
            }
            
            if (!Password.Any(char.IsLower))
            {
                throw new ArgumentException("Password must contain at least one lowercase letter.");
            }
            
            if (!Password.Any(char.IsDigit))
            {
                throw new ArgumentException("Password must contain at least one digit.");
            }
            
            if (!Password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                throw new ArgumentException("Password must contain at least one special character.");
            }

            this.Password_Hash = HashingHelper.HashPassword(Password);        
        }
        
        public void SetUsername(string Username)
        {           
            if (string.IsNullOrWhiteSpace(Username))
            {
                throw new ArgumentException("Username cannot be empty.");
            }
            
            if (Username.All(c => char.IsDigit(c) || c == '.' || !char.IsLetterOrDigit(c)))
            {
                throw new ArgumentException("Username must not consist of only digits, dots, or special characters.");
            }
           
            this.Username = Username;
        }

        public void SetEmail(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                throw new ArgumentException("Email cannot be empty.");
            }

            // Regular expression to match basic email format (you can adjust it to be more restrictive if needed)
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
 
            if (!Regex.IsMatch(Email, emailPattern))
            {
                throw new ArgumentException("Email is not in a valid format.");
            }
            
            this.Email = Email;
        }

        public void SetDOB(string DOB)
        {
            /*if (DOB > DateTime.Now)
            {
                throw new ArgumentException("Date of birth cannot be in the future.");
            }
            */
            this.DOB = DOB;
        }

        public void SetPhone(string Phone)
        {
            if (Phone.Length != 11)
            {
                throw new ArgumentException("Phone No must be exactly 11 digits long.");
            }

            if (!Phone.All(char.IsDigit))
            {
                throw new ArgumentException("Phone No must contain only numeric digits.");
            }
            this.Phone = Phone;
        }

        public void SetStatus(string Status)
        {
            this.Status = Status;
        }

        public void SetName(string Name)
        {
            Regex regex = new Regex(@"^\D*$"); // ^ means start, \D* means any non-digit characters, $ means end
            if (!regex.IsMatch(Name))
            {
                throw new ArgumentException("Name consists of alphabets only.");
            }
            this.Name = Name;
        }

        public bool DeleteUser(int UserId)
        {
            bool flag = DL.User.DeleteUserFromDB(UserId);
            return flag;
        }

        public bool UpdateUserStatus(int id, string newStatus)
        {
            DL.User dl = new DL.User();
            return dl.UpdateUserStatusInDB(id,newStatus);
        }

    }
}
