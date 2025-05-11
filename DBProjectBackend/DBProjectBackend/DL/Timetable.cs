using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProjectBackend.DL
{
    class Timetable
    {
        public bool AddTimetableSlottoDB(BL.Timetable t)
        {
            string insertQuery = "INSERT INTO timetable(StartTime, EndTime, Type) VALUES ('{0}', '{1}', '{2}')";
            insertQuery = String.Format(insertQuery, t.GetStartTime(), t.GetEndTime(), t.GetSlotType());
            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public bool UpdateSlotInDB(BL.Timetable t)
        {
            string updateQuery = "UPDATE timetable SET StartTime = '{0}', EndTime = '{1}', Type = '{2}' WHERE SlotID = {3}";
            updateQuery = String.Format(updateQuery, t.GetStartTime(), t.GetEndTime(), t.GetSlotType(), t.GetSlotID());
            int rowsAffected = SqlHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public List<object> GetSlotsDetailsFromDB()
        {
            string query = "Select SlotDetails from retrievetimetable";
            string columnName = "SlotDetails";
            List<object> details = SqlHelper.GetColumnValues(query, columnName);
            return details;
        }

        public int? GetTimeTableSlotIDFromDB(string editSlot)
        {
            string query = "Select SlotID From retrievetimetable Where SlotDetails = '{0}'";
            query = String.Format(query, editSlot);
            object id = SqlHelper.ExecuteScalar(query);
            return (int?)id;
        }

        public DataTable GetTimeTableSlotsFromDB()
        {
            string query = "SELECT * FROM timetable";
            DataTable dt = SqlHelper.getDataTable(query);
            return dt;
        }

        public bool DeleteTimeTableSlotFromDB(int Id)
        {
            string query = "Delete From timetable Where SlotID = {0}";
            query = String.Format(query, Id);
            int rowsAffected = SqlHelper.executeDML(query);
            return rowsAffected > 0;
        }

        public int? GetSlotIDFromDB(string editSlot)
        {
            string query = "Select SlotID From retrievetimetable Where SlotDetails = '{0}'";
            query = String.Format(query, editSlot);
            object id = SqlHelper.ExecuteScalar(query);
            return (int?)id;
        }

    }
}
