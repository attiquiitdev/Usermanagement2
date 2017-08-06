using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApiAppTask.Models;

namespace WebApiAppTask.DataAccessLayer
{
    public class UserDataAccessLayer
    {
        TestingEntities DB = new TestingEntities();
        public User CheckUserExists(string userName, string password)
        {
            User user = null;
            var IsUserExists = (from p in DB.Users where p.UserName == userName && p.Password == password select p).Count();
            if (IsUserExists.Equals(1))
            {
                user = (from p in DB.Users where p.UserName == userName && p.Password == password select p).FirstOrDefault();
                return user;
            }
            else
            {
                return user;
            }

            
        }
        public IEnumerable<User> GetAllUser()
        {
            var result = (from p in DB.Users select p).ToList();
            return result;
        }
        public bool SaveUser(User userdata)
        {
            userdata.IsAdmin = false;
            DB.Users.Add(userdata);
            DB.SaveChanges();
            return true;

        }
        public bool DeleteUser(int ID)
        {
            User deleteUser;
            deleteUser = (from p in DB.Users select p).FirstOrDefault();
            DB.Entry(deleteUser).State = EntityState.Deleted;
            DB.SaveChanges();
            return true;

        }
        public bool UpdateUser(User user)
        {
           
            DB.Entry(user).State = EntityState.Modified;
            DB.SaveChanges();
            return true;

        }
    }
}