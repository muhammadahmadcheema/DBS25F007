using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.DL
{
    class ScheduledClass
    {
        public bool AddScheduledClassToDB(BL.ScheduledClass sc)
        {
            string insertQuery = "INSERT INTO scheduledclass(RoomID, FacultyCourseID, TimeSlotID) " +
                                 "VALUES ({0}, {1}, {2})";
            insertQuery = string.Format(insertQuery,
                                        sc.GetRoomID(),
                                        sc.GetFacultyCourseID(),
                                        sc.GetTimeSlotID());

            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public DataTable GetAllScheduledClassesFromDB()
        {
            string query = "SELECT * FROM scheduledclasses";
            return SqlHelper.getDataTable(query);
        }

        public bool UpdateScheduledClassToDB(BL.ScheduledClass sc)
        {
            string updateQuery = "UPDATE scheduledclass SET RoomID = {0}, FacultyCourseID = {1}, TimeSlotID = {2} WHERE ScheduledClassID = {3}";
            updateQuery = string.Format(updateQuery,
                                        sc.GetRoomID(),
                                        sc.GetFacultyCourseID(),
                                        sc.GetTimeSlotID(),
                                        sc.GetScheduledClassID());

            int rowsAffected = SqlHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public bool DeleteScheduledClassFromDB(int scheduledClassID)
        {
            string deleteQuery = "DELETE FROM scheduledclasses WHERE ScheduledClassID = {0}";
            deleteQuery = string.Format(deleteQuery, scheduledClassID);

            int rowsAffected = SqlHelper.executeDML(deleteQuery);
            return rowsAffected > 0;
        }

        public List<object> GetScheduledClassNamesFromDB()
        {
            string query = "Select ScheduledClassID from scheduledclass";
            string columnName = "ScheduledClassID";
            List<object> scnames = SqlHelper.GetColumnValues(query, columnName);
            return scnames;
        }

        public int GetScheduledClassIDFromDB(int scid)
        {
            string query = "Select ScheduledClassID From scheduledclass Where ScheduledClassID = '{0}'";
            query = String.Format(query, scid);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }

        
    }
}
