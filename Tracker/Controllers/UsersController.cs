using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tracker.Services.IServices;
using Tracker.Services.Models;

namespace Tracker.Controllers
{
    public class UsersController : ApiController
    {
        protected IUserService UserService;
        public UsersController(IUserService userService)
        {
            this.UserService = userService;
        }
        //[Authorize]
        [HttpGet]
        public IHttpActionResult GetUser(string username, string password)
        {
            return Ok(UserService.FindUser(username, password));
        }

        //[Authorize]
        [HttpPost]
        public IHttpActionResult AddUser([FromBody] UserDTO user) 
        {
            return Ok(UserService.AddUser(user));
        }
    }
}
