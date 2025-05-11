using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DBProjectBackend.BL
{
    public class FeeChallan
    {
        private int ChallanID;
        private int? SemesterID;
        private string IssueDate;
        private string DueDate;
        private int TotalAmount;
        private string Status;
        private int StudentID;

        public FeeChallan() { }

        public FeeChallan(int? SemesterID, string IssueDate, string DueDate, int TotalAmount, string Status, int StudentID)
        {
            this.SemesterID = SemesterID;
            this.IssueDate = IssueDate;
            this.DueDate = DueDate;
            this.TotalAmount = TotalAmount;
            this.Status = Status;
            this.StudentID = StudentID;
        }

        public bool AddChallan(FeeChallan d)
        {
            DL.FeeChallan dl = new DL.FeeChallan();
            return dl.AddFeeChallanToDB(d);
        }

        public DataTable GetFeeChallan()
        {
            DL.FeeChallan dl = new DL.FeeChallan();
            DataTable dt = dl.GetAllFeeChallansFromDB();
            return dt;
        }

        public bool UpdateChallanStatus(int id, string newStatus)
        {
            DL.FeeChallan dl = new DL.FeeChallan();
            return dl.UpdateChallanStatusInDB(id, newStatus);
        }


        public FeeChallan(int ChallanID, int SemesterID, string IssueDate, string DueDate, int TotalAmount, string Status, int StudentID)
        {
            this.ChallanID = ChallanID;
            this.SemesterID = SemesterID;
            this.IssueDate = IssueDate;
            this.DueDate = DueDate;
            this.TotalAmount = TotalAmount;
            this.Status = Status;
            this.StudentID = StudentID;
        }


        public int GetChallanID()
        {
            return ChallanID;
        }

        public void SetChallanID(int ChallanID)
        {
            this.ChallanID = ChallanID;
        }

        public int? GetSemesterID()
        {
            return SemesterID;
        }

        public void SetSemesterID(int SemesterID)
        {
            this.SemesterID = SemesterID;
        }

        public string GetIssueDate()
        {
            return IssueDate;
        }

        public void SetIssueDate(string IssueDate)
        {
            this.IssueDate = IssueDate;
        }

        public string GetDueDate()
        {
            return DueDate;
        }

        public void SetDueDate(string DueDate)
        {
            this.DueDate = DueDate;
        }

        public int GetTotalAmount()
        {
            return TotalAmount;
        }

        public void SetTotalAmount(int TotalAmount)
        {
            this.TotalAmount = TotalAmount;
        }

        public string GetStatus()
        {
            return Status;
        }

        public void SetStatus(string Status)
        {
            this.Status = Status;
        }

        public int GetStudentID()
        {
            return StudentID;
        }

        public void SetStudentID(int StudentID)
        {
            this.StudentID = StudentID;
        }
    }
}

