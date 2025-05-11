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
            string insertQuery = "INSERT INTO scheduledclasses(RoomID, FacultyCourseID, Time, TimeSlotID) " +
                                 "VALUES ({0}, {1}, '{2}', {3})";
            insertQuery = string.Format(insertQuery,
                                        sc.GetRoomID(),
                                        sc.GetFacultyCourseID(),
                                        sc.GetTime(),
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
            string updateQuery = "UPDATE scheduledclasses SET RoomID = {0}, FacultyCourseID = {1}, Time = '{2}', TimeSlotID = {3} WHERE ScheduledClassID = {4}";
            updateQuery = string.Format(updateQuery,
                                        sc.GetRoomID(),
                                        sc.GetFacultyCourseID(),
                                        sc.GetTime(),
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
    }
}
