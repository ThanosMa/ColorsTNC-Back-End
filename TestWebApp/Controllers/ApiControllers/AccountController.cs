﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Cors;
using TestWebApp.Models;

namespace TestWebApp.Controllers.ApiControllers
{
    [EnableCors("*", "*", "GET,POST,PUT,DELETE")]
    public class AccountController : ApiController
    {
        
        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(AccountModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("irthe null");
            }
            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };
            IdentityResult result = manager.Create(user, model.Password);
            // --> Uncomment this if you want to create more Admins.
            //if (model.Roles.Contains("Admin"))
            //{
            //    return IdentityResult.Failed("Admin Allready exists");
            //}
            manager.AddToRoles(user.Id, model.Roles);
            return result;
        }

        /// <summary>
        /// Method that displays User's information.
        /// At the moment is not consumed by angular.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetUserClaims")]
        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("Username").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };
            return model;
        }

        /// <summary>
        /// Testing Roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("api/ForAdminRole")]
        public string ForAdminRole()
        {
            return "for admin role";
        }

        [HttpGet]
        [Authorize(Roles = "Employee")]
        [Route("api/ForEmployeeRole")]
        public string ForAuthorRole()
        {
            return "For Employee role";
        }

        [HttpGet]
        [Authorize(Roles = "Employee,Visitor")]
        [Route("api/ForEmployeeOrVisitor")]
        public string ForAuthorOrReader()
        {
            return "For Employee/Visitor role";
        }
    }
}

