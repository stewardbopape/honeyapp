using HoneyComb.BusinessObjects;
using HoneyComb.IProvider.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HoneyComb.WebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private IUserProvider _userProvider;

        public UserController(IUserProvider userProvider)
        {
            this._userProvider = userProvider;
        }
        [HttpGet, Route("login/{username}/{password}")]
        public IHttpActionResult Login(string username, string password)

        {
            MCR_PERSONS user = new MCR_PERSONS() { LOGIN_USERNAME = username, LOGIN_PASSWORD = password };
            var result = _userProvider.Login(user);
            return Ok(result);
        }
    }
}
