using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Angular_demo.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Email {  get; set; }
        public string Password { get; set; }
        public int RoleId {  get; set; }

        [ForeignKey("RoleId")]
        public virtual Roles Role { get; set; }
    }
}