

using MVC_Angular_demo.DTOs;
using MVC_Angular_demo.Models;
using System;
using System.Linq;
using System.Web;

namespace MVC_Angular_demo.Services
{
    public class AuthServices
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public AuthServices()
        {

        }
        //add user
        public bool AddUser(RegisterViewModel model)
        {
            try
            {
                //check for exestance
                Users dbUser = _context.Users.Where(u => u.Email == model.Email).FirstOrDefault();
                if (dbUser == null)
                {
                    // Map RegisterViewModel to Users entity
                    var user = new Users
                    {
                        Email = model.Email,
                        Password = model.Password,
                        RoleId = 1
                        // You might want to set other properties like RoleId here
                    };

                    // Add user to the database
                    _context.Users.Add(user);
                }
                else
                {
                    dbUser.Password = model.Password;
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Users Login(RegisterViewModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            return user ?? null;
        }


    }
}