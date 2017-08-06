using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeApiAjaxTask.Models;
using WeApiAjaxTask.Controllers;
using WeApiAjaxTask.DataAccessLayer;

namespace WeApiAjaxTask.Controllers.API
{
    public class UserApiController : ApiController
    {
        UserDataAccessLayer db = new UserDataAccessLayer();
        public HttpResponseMessage LoginUser(User userdata)
        {
            var newUrl = "";
            var res = db.CheckUserExists(userdata.UserName, userdata.Password);
            if (res!=null && res.IsAdmin == true)
            {
                newUrl = this.Url.Link("Default", new
                {
                    Controller = "Home",
                    Action = "AdminView"
                });
                return Request.CreateResponse(HttpStatusCode.OK, new {result = res, Success = true, RedirectUrl = newUrl });
            }
            else if (res !=null && res.IsAdmin == false)
            {
                newUrl = this.Url.Link("Default", new
                {
                    Controller = "Home",
                    Action = "UserView"
                });
                return Request.CreateResponse(HttpStatusCode.OK, new { result = res, Success = true, RedirectUrl = newUrl });
            }
            else
            {
                newUrl = this.Url.Link("Default", new
                {
                    Controller = "Home",
                    Action = "LoginView"
                });
                return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = newUrl });
            }

            
            
        }

       
    }
}
