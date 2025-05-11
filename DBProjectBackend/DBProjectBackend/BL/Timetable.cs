using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProjectBackend.BL
{
    public class Timetable
    {
        private int SlotID;
        private TimeSpan StartTime;
        private TimeSpan EndTime;
        private string Type;

        public Timetable() { }

        public Timetable(TimeSpan StartTime, TimeSpan EndTime, string Type)
        {
            SetStartTime(StartTime);
            SetEndTime(EndTime, StartTime);
            this.Type = Type;
        }

        public Timetable(int SlotID, TimeSpan StartTime, TimeSpan EndTime, string Type)
        {
            this.SlotID = SlotID;
            SetStartTime(StartTime);
            SetEndTime(EndTime, StartTime);
            this.Type = Type;
        }

        public bool AddTimeTableSlot(Timetable t)
        {
            DL.Timetable dl = new DL.Timetable();
            //Check if duplicate exists
            int? timetableID = null;
            timetableID = dl.GetSlotIDFromDB(t.GetStartTime() + " " + t.GetEndTime() + " " + t.GetSlotType());
            if (timetableID == null)
            {
                DL.Timetable dl1 = new DL.Timetable();
                return dl1.AddTimetableSlottoDB(t);
            }
            return false;
        }

        public void SetStartTime(TimeSpan StartTime)
        {
            this.StartTime = StartTime;
        }

        public void SetEndTime(TimeSpan EndTime, TimeSpan StartTime)
        {
            if (StartTime > EndTime)
            {
                throw new ArgumentException("Start Time must be early than End Time.");
            }

            this.EndTime = EndTime;
        }

        public void SetType(string Type) { this.Type = Type; }

        public TimeSpan GetStartTime()
        {
            return StartTime;
        }

        public TimeSpan GetEndTime()
        {
            return EndTime;
        }

        public string GetSlotType()
        {
            return Type;
        }

        public List<object> GetTimetableSlots()
        {
            DL.Timetable timetable = new DL.Timetable();
            List<object> list = timetable.GetSlotsDetailsFromDB();
            return list;
        }

        public int? GetTimetableID(string editSlot)
        {
            DL.Timetable dl = new DL.Timetable();
            return dl.GetTimeTableSlotIDFromDB(editSlot);
        }

        public int GetSlotID()
        {
            return SlotID;
        }

        public bool DeleteTimeTableSlot(int id)
        {
            DL.Timetable dl = new DL.Timetable();
            bool flag = dl.DeleteTimeTableSlotFromDB(id);
            return flag;
        }

        public DataTable GetTimetableDT()
        {
            DL.Timetable dl = new DL.Timetable();
            return dl.GetTimeTableSlotsFromDB();
        }

        public bool UpdateTimetable(Timetable t)
        {
            DL.Timetable dl = new DL.Timetable();
            int? slotID = null;
            slotID = dl.GetSlotIDFromDB(t.GetStartTime() + " " + t.GetEndTime() + " " + t.GetSlotType());
            if (slotID == null)
            {
                return dl.UpdateSlotInDB(t);
            }
            return false;

        }
    }
}
