using System;
using System.Linq;
using System.Security.Policy;

namespace OldEF6Library
{
    public class OldEF6Class
    {
        public static string ConnectionString { get; set; }
        public long GetUserCount() {

            UserEntities userEntities;

            if (string.IsNullOrEmpty(ConnectionString))
                userEntities = new UserEntities();    
            else 
                userEntities = new UserEntities(ConnectionString);
     
            return userEntities.users.Count();
         
        } 
    }
}
