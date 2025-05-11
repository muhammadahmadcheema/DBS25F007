using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.DL
{
    class Room
    {
        public bool AddRoomToDB(BL.Room r)
        {
            string insertQuery = "INSERT INTO room(Name, Type, Capacity, DepartmentID) VALUES ('{0}', '{1}', {2}, {3})";
            insertQuery = String.Format(insertQuery, r.GetName(), r.GetType(), r.GetCapacity(), r.GetDepartmentID());
            int rowsAffected = SqlHelper.executeDML(insertQuery);
            return rowsAffected > 0;
        }

        public DataTable GetAllRooms()
        {
            string query = "SELECT * FROM room";
            DataTable dt = SqlHelper.getDataTable(query);
            return dt;
        }

        public bool UpdateRoomInDB(BL.Room r)
        {
            string updateQuery = "UPDATE room SET Name = '{0}', Type = '{1}', Capacity = {2}, DepartmentID = {3} WHERE RoomID = {4}";
            updateQuery = String.Format(updateQuery, r.GetName(), r.GetType(), r.GetCapacity(), r.GetDepartmentID(), r.GetRoomID());
            int rowsAffected = SqlHelper.executeDML(updateQuery);
            return rowsAffected > 0;
        }

        public bool DeleteRoomFromDB(int id)
        {
            string query = $"DELETE FROM room WHERE RoomID = {id}";
            int rowsAffected = SqlHelper.executeDML(query);
            return rowsAffected > 0;
        }

        public List<object> GetRoomNamesFromDB()
        {
            string query = "Select Name from Room";
            string columnName = "Name";
            List<object> roomnames = SqlHelper.GetColumnValues(query, columnName);
            return roomnames;
        }

        public int GetRoomIDFromDB(string RoomName)
        {
            string query = "Select RoomID From room Where Name = '{0}'";
            query = String.Format(query, RoomName);
            object id = SqlHelper.ExecuteScalar(query);
            return (int)id;
        }

    }
}

