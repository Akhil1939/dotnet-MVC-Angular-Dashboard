using MVC_Angular_demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Angular_demo.Extensions
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Check if the user is logged in by checking if the session contains the logged-in user

            if (httpContext.Session["SessionUser"] != null)
            {
                if (!string.IsNullOrEmpty(Roles))
                {
                    Users user = (Users)httpContext.Session["SessionUser"];
                    if (user != null)
                    {
                        if (!string.IsNullOrWhiteSpace(Roles))
                        {
                            string[] roles = Roles.Split(',');
                            return roles.Contains(user.RoleId.ToString());
                        }
                    }
                }
                return true;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Redirect the user to the login page if they are not logged in
            filterContext.Result = new RedirectResult("~/Account/Login");
        }
    }
}