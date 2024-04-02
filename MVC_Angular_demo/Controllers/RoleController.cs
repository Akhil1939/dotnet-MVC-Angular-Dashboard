using MVC_Angular_demo.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Angular_demo.Controllers
{
    public class RoleController : Controller
    {
        private List<Role> roles = new List<Role>() {
                new Role() { Id = 1, Name= "Admin"},
                new Role() { Id = 2, Name = "Super User"}};
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public string GetRoles()
        {
            return JsonConvert.SerializeObject(roles);
        }

        public string GetRole(int id)
        {
            return JsonConvert.SerializeObject(roles.Where(r => r.Id == id).First());
        }

    }
}
