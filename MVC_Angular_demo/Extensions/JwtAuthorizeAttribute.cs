using MVC_Angular_demo.Models;
using MVC_Angular_demo.Services;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVC_Angular_demo.Extensions
{
    public class JwtAuthorizeAttribute : AuthorizeAttribute
    {
        private static readonly TokenService _tokenService = new TokenService();
        protected override bool AuthorizeCore(HttpContextBase httpContext)

        {
            try
            {

                var authHeader = httpContext.Request.Headers["Authorization"];
                if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    var token = authHeader.Substring("Bearer ".Length).Trim();

                    // Validate the token here (e.g., decode and verify JWT token)
                    // Example:
                    var claims = _tokenService.ValidateToken(token).Claims.ToList();
                    if (claims != null)
                    {
                        string email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                        string role = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                        if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(role))
                        {
                            if (!string.IsNullOrWhiteSpace(Roles))
                            {
                                string[] roles = Roles.Split(',');
                                return roles.Contains(role);
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                // User is authenticated but does not have access to the resource
                filterContext.Result = new HttpStatusCodeResult(403); // Return HTTP 403 Forbidden
            }
            else
            {
                // User is not authenticated
                filterContext.Result = new HttpUnauthorizedResult("Unauthorized request"); // Return HTTP 401 Unauthorized
            }
        }
    }
}
