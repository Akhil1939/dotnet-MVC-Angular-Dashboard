using MVC_Angular_demo.Extensions;
using MVC_Angular_demo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Angular_demo.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [JwtAuthorizeAttribute(Roles="1,2")]
        public string UserList()
        {
            // Get the list of users
            List<UserModel> users = GetUsers();

            // Convert list of users to JSON string using Newtonsoft.Json
            string json = JsonConvert.SerializeObject(users);
            return json;
        }
        [JwtAuthorizeAttribute(Roles = "2")]
        public string GetUser(int Id)
        {
            List<UserModel> users = GetUsers();
            string json = JsonConvert.SerializeObject(users.Where(u => u.Id == Id).First());
            return json;
        }

        private List<UserModel> GetUsers()
        {
            List<UserModel> users = new List<UserModel>();
            // Dummy data for users
            string[] firstNames = { "John", "Emma", "Michael", "Sophia", "William", "Olivia", "James", "Ava", "Alexander", "Isabella", "Henry", "Mia", "Daniel", "Charlotte", "Benjamin", "Amelia", "Jacob", "Evelyn", "Samuel", "Abigail" };
            string[] lastNames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson" };
            string[] domains = { "gmail.com", "yahoo.com", "outlook.com", "hotmail.com" };

            // Adding 20 dummy user entries
            for (int i = 0; i < 10; i++)
            {
                UserModel user = new UserModel
                {
                    Id = i + 1,
                    FirstName = firstNames[i % firstNames.Length],
                    LastName = lastNames[i % lastNames.Length],
                    Email = $"{firstNames[i % firstNames.Length].ToLower()}.{lastNames[i % lastNames.Length].ToLower()}@{domains[i % domains.Length]}",
                    Age = new Random().Next(18, 60) // Generating a random age between 18 and 60
                };

                users.Add(user);
            }

            return users;
        }
    }
}
