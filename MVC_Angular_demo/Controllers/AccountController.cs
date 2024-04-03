using MVC_Angular_demo.DTOs;
using MVC_Angular_demo.Models;
using MVC_Angular_demo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC_Angular_demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthServices _authService = new AuthServices();
        private readonly TokenService _tokenService = new TokenService();
        public AccountController()
        {

        }
        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            if (HttpContext.Session["SessionUser"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");

        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Code for registering the user goes here
                // Typically, you would save the user to the database
                // and then redirect to a different page (e.g., dashboard)
                var isUserAdded = _authService.AddUser(model);
                if (isUserAdded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to register user.");
                    return View(model);
                }
            }

            // If we got this far, something failed; redisplay the form
            return View(model);
        }

        [HttpPost]
        public string Login(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = _authService.Login(model);
                if (user != null)
                {
                    // Authentication successful, redirect to home page or dashboard
                    HttpContext.Session["SessionUser"] = user;
                    var token = _tokenService.GenerateToken(user);
                    return token;
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }

            // If we got this far, something failed; redisplay the form
            return null;
        }
    }
}