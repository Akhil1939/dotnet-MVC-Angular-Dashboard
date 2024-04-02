using System.Collections.Generic;
using System;
using System.Web.Mvc;
using MVC_Angular_demo.Models;
using System.Threading.Tasks;
using System.Web.Helpers;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
namespace MVC_Angular_demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}