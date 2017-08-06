using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAppTask.DataAccessLayer;
using WebApiAppTask.Models;

namespace WebApiAppTask.Controllers
{

    public class UserApiController : ApiController
    {
        UserDataAccessLayer userDb = new UserDataAccessLayer();
        //public UserApiController(UserDataAccessLayer _userDB)
        //{
        //    userDb = _userDB;
        //}
        public User CheckUserExists(string username, string password)
        {
            return userDb.CheckUserExists(username, password);

        }
        public bool SaveUser(User userdata)
        {
            return userDb.SaveUser(userdata);
        }

        public IEnumerable<User> GetAllUser()
        {
            return userDb.GetAllUser();
        }
        public bool DeleteUser(int Id)
        {
            return userDb.DeleteUser(Id);
        }
        public bool UpdateUser(User user)
        {
            return userDb.UpdateUser(user);
        }
        
    }
}
