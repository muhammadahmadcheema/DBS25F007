using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.BL
{
    public class ScheduledClass
    {
        private int ScheduledClassID;
        private int RoomID;
        private int? FacultyCourseID;
        private int? TimeSlotID;

        public ScheduledClass() { }

        public ScheduledClass(int RoomID, int? FacultyCourseID, int? TimeSlotID)
        {
            this.RoomID = RoomID;
            this.FacultyCourseID = FacultyCourseID;
            this.TimeSlotID = TimeSlotID;
        }

        public ScheduledClass(int ScheduledClassID, int RoomID, int? FacultyCourseID, int? TimeSlotID)
        {
            this.ScheduledClassID = ScheduledClassID;
            this.RoomID = RoomID;
            this.FacultyCourseID = FacultyCourseID;
            this.TimeSlotID = TimeSlotID;
        }

        public bool AddScheduledClass(ScheduledClass sc)
        {
            DL.ScheduledClass dl = new DL.ScheduledClass();
            return dl.AddScheduledClassToDB(sc);
        }

        public DataTable GetScheduledClasses()
        {
            DL.ScheduledClass dl = new DL.ScheduledClass();
            return dl.GetAllScheduledClassesFromDB();
        }

        public bool UpdateScheduledClass(ScheduledClass sc)
        {
            DL.ScheduledClass dl = new DL.ScheduledClass();
            return dl.UpdateScheduledClassToDB(sc);
        }

        public bool DeleteScheduledClass(int ScheduledClassID)
        {
            DL.ScheduledClass dl = new DL.ScheduledClass();
            return dl.DeleteScheduledClassFromDB(ScheduledClassID);
        }

        public int GetScheduledClassID() { return ScheduledClassID; }
        public int GetRoomID() { return RoomID; }
        public int? GetFacultyCourseID() { return FacultyCourseID; }
        public int? GetTimeSlotID() { return TimeSlotID; }

        public void SetScheduledClassID(int id) { this.ScheduledClassID = id; }
        public void SetRoomID(int id) { this.RoomID = id; }
        public void SetFacultyCourseID(int id) { this.FacultyCourseID = id; }
        public void SetTimeSlotID(int id) { this.TimeSlotID = id; }

        public List<object> GetScheduledClassNames()
        {
            DL.ScheduledClass sc = new DL.ScheduledClass();
            List<object> scnames = sc.GetScheduledClassNamesFromDB();
            return scnames;
        }

        public int GetScheduledClassID(int scname)
        {
            DL.ScheduledClass r1 = new DL.ScheduledClass();
            return r1.GetScheduledClassIDFromDB(scname);
        }

    }
}

