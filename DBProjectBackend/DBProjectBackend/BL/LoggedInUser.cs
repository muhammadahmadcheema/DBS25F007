using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProjectBackend.BL
{
    public static class LoggedInUser
    {
        private static string Username;
        private static int userid;


        public static void SetUsername(string username)
        {
            Username = username;
        }

        public static void SetUserID(int userID)
        {
            userid = userID;
        }

        public static string GetUsername()
        {
            return Username;
        }

        public static int GetUserID()
        {
            return userid;
        }
        
        
    }
}