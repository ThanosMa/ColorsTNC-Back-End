﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestWebApp.Controllers.ApiControllers
{
    public class RoleController : ApiController
    {
        [HttpGet]
        [Route("api/GetAllRoles")]
        [Authorize(Roles = "Admin")]
        public HttpResponseMessage GetRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(new TestWebApp.Models.ApplicationDbContext());
            var roleMngr = new RoleManager<IdentityRole>(roleStore);
            var roles = roleMngr.Roles
                .Select(x => new { x.Id, x.Name })
                .ToList();
            return this.Request.CreateResponse(HttpStatusCode.OK, roles);
        }
    }
}
