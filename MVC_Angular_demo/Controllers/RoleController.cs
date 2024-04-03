using MVC_Angular_demo.Extensions;
using MVC_Angular_demo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Angular_demo.Controllers
{
    public class RoleController : Controller
    {
        private List<RoleDto> roles = new List<RoleDto>() {
                new RoleDto() { Id = 1, Name= "Admin"},
                new RoleDto() { Id = 2, Name = "Super User"}};
        // GET: Role
        [CustomAuthorizeAttribute(Roles = "1,2")]
        public ActionResult Index()
        {
            return View();
        }
        [JwtAuthorizeAttribute(Roles = "1,2")]
        public string GetRoles()
        {
            return JsonConvert.SerializeObject(roles);
        }
        [JwtAuthorizeAttribute(Roles = "2")]
        public string GetRole(int id)
        {
            return JsonConvert.SerializeObject(roles.Where(r => r.Id == id).First());
        }

    }
}
