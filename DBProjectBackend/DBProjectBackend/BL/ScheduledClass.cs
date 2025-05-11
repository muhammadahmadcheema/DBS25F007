using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.BL
{
    class ScheduledClass
    {
        private int ScheduledClassID;
        private int RoomID;
        private int FacultyCourseID;
        private string Time;
        private int TimeSlotID;

        public ScheduledClass(int RoomID, int FacultyCourseID, string Time, int TimeSlotID)
        {
            this.RoomID = RoomID;
            this.FacultyCourseID = FacultyCourseID;
            this.Time = Time;
            this.TimeSlotID = TimeSlotID;
        }

        public ScheduledClass(int ScheduledClassID, int RoomID, int FacultyCourseID, string Time, int TimeSlotID)
        {
            this.ScheduledClassID = ScheduledClassID;
            this.RoomID = RoomID;
            this.FacultyCourseID = FacultyCourseID;
            this.Time = Time;
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
        public int GetFacultyCourseID() { return FacultyCourseID; }
        public string GetTime() { return Time; }
        public int GetTimeSlotID() { return TimeSlotID; }

        public void SetScheduledClassID(int id) { this.ScheduledClassID = id; }
        public void SetRoomID(int id) { this.RoomID = id; }
        public void SetFacultyCourseID(int id) { this.FacultyCourseID = id; }
        public void SetTime(string time) { this.Time = time; }
        public void SetTimeSlotID(int id) { this.TimeSlotID = id; }
    }
}

