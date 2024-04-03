using MVC_Angular_demo.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Angular_demo.Controllers
{
    [CustomAuthorizeAttribute(Roles = "1,2")]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
