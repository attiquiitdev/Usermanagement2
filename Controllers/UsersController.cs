using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiAppTask.Models;

namespace WebApiAppTask.Controllers
{
    public class UsersController : Controller
    {
        UserApiController userApi = new UserApiController();

        //public UsersController(UserApiController _userApi)
        //{
        //    //Injecting Dependency
        //   this.userApi = _userApi;
        //}
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin() {

            return View();
        }

        public ActionResult AdminLogin() {

            return View();

        }

        public ActionResult LoginUser()
        {
            User user = null;
            user = userApi.CheckUserExists(Request["username"], Request["password"]);
            if (user != null && user.IsAdmin == true)
            {
                Session["IsUserLogedIn"] = true;
                return RedirectToAction("AdminView");
            }           
            else if(user != null && user.IsAdmin == false)
            {
                Session["IsUserLogedIn"] = true;
                return RedirectToAction("UserView");
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
            
        }
        public ActionResult UserView()
        {
            if (Convert.ToBoolean(Session["IsUserLogedIn"]) == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
        }
        public ActionResult AdminView()
        {
            if (Convert.ToBoolean(Session["IsUserLogedIn"])== true)
            {
                IEnumerable<User> allusers = null;
                allusers = userApi.GetAllUser();
                return View(allusers);
            }
            else
            {
                return RedirectToAction("UserLogin");
            }
            
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        public ActionResult SaveUser(User userdata)
        {
           var res =  userApi.SaveUser(userdata);
            return RedirectToAction("UserLogin");
        }
        public ActionResult Logout()
        {
            Session["IsUserLogedIn"] = false;
            return RedirectToAction("UserLogin");
        }

        public string UpdateUser(int Id, string name, string country, bool role)
        {
            User updateUser = new User();
            updateUser.Id = Id;
            updateUser.UserName = name;
            updateUser.Country = country;
            updateUser.IsAdmin = role;
            userApi.UpdateUser(updateUser);
            return "abc";

        }
    }
}