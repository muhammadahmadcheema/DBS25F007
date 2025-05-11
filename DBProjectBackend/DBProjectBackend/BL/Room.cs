using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBProjectBackend.BL
{
    public class Room
    {
        private int RoomID;
        private string Name;
        private string Type;
        private int Capacity;
        private int DepartmentID;

        public Room() { }

        public Room(string Name, string Type, int Capacity, int DepartmentID)
        {
            SetName(Name);
            this.Type = Type;
            SetCapacity(Capacity);
            this.DepartmentID = DepartmentID;
        }

        public Room(int RoomID, string Name, string Type, int Capacity, int DepartmentID)
        {
            this.RoomID = RoomID;
            SetName(Name);
            this.Type = Type;
            SetCapacity(Capacity);
            this.DepartmentID = DepartmentID;
        }

        public bool AddRoom(Room r)
        {
            DL.Room dl = new DL.Room();
            return dl.AddRoomToDB(r);
        }

        public DataTable GetRooms()
        {
            DL.Room dl = new DL.Room();
            return dl.GetAllRooms();
        }

        public bool UpdateRoom(Room r)
        {
            DL.Room dl = new DL.Room();
            return dl.UpdateRoomInDB(r);
        }

        public bool DeleteRoom(int id)
        {
            DL.Room dl = new DL.Room();
            return dl.DeleteRoomFromDB(id);
        }

        public int GetRoomID()
        {
            return RoomID;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetType()
        {
            return Type;
        }

        public int GetCapacity()
        {
            return Capacity;
        }

        public int GetDepartmentID()
        {
            return DepartmentID;
        }


        public void SetRoomID(int id)
        {
            this.RoomID = id;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Room Name cannot be empty.");
            }
            this.Name = name;
        }

        public void SetType(string type)
        {
            this.Type = type;
        }

        public void SetCapacity(int capacity)
        {
            if (capacity < 0 && capacity > 100)
            {
                throw new ArgumentException("Capacity must be in range of [0,100]");
            }
            this.Capacity = capacity;
        }

        public void SetDepartmentID(int id)
        {
            this.DepartmentID = id;
        }

        public List<object> GetRoomNames()
        {
            DL.Room room = new DL.Room();
            List<object> roomnames = room.GetRoomNamesFromDB();
            return roomnames;
        }

        public int GetRoomID(string RoomName)
        {
            DL.Room r1 = new DL.Room();
            return r1.GetRoomIDFromDB(RoomName);
        }

    }
}

