using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.BL
{
    public class Grade
    {
        private int GradeID;
        private string GradeName;
        private float GradePoints;

        public Grade() { }
        public Grade(string GradeName, float GradePoints)
        {
            this.GradeName = GradeName;
            SetGradePoints(GradePoints);
        }

        public Grade(int GradeID, string GradeName, float GradePoints)
        {
            this.GradeID = GradeID;
            this.GradeName = GradeName;
            SetGradePoints(GradePoints);
        }


        public bool AddGrade(Grade g)
        {
            DL.Grade dl = new DL.Grade();
            return dl.AddGradeToDB(g);
        }

        public DataTable GetGrades()
        {
            DL.Grade dl = new DL.Grade();
            return dl.GetAllGrades();
        }

        public bool UpdateGrade(Grade g)
        {
            DL.Grade dl = new DL.Grade();
            return dl.UpdateGradeInDB(g);
        }

        public bool DeleteGrade(int id)
        {
            DL.Grade dl = new DL.Grade();
            return dl.DeleteGradeFromDB(id);
        }


        public int GetGradeID()
        {
            return GradeID;
        }

        public string GetGradeName()
        {
            return GradeName;
        }

        public float GetGradePoints()
        {
            return GradePoints;
        }

        public void SetGradeID(int id)
        {
            this.GradeID = id;
        }

        public void SetGradeName(string name)
        {
            this.GradeName = name;
        }

        public void SetGradePoints(float points)
        {
            if (points < 0 || points > 4)
            {
                throw new ArgumentException("Grade points must be in range of [0,4]");
            }
            this.GradePoints = points;
        }

        public int GetGradeID(string GradeName)
        {
            DL.Grade dl = new DL.Grade();
            return dl.GetGradeIDFromDB(GradeName);
        }

        public List<object> GetGradeNames()
        {
            DL.Grade dl = new DL.Grade();
            List<object> gradeNames = dl.GetGradeNamesFromDB();
            return gradeNames;
        }

    }    
}
