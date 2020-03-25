using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Login
    {
        public string LoginUser { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Isvalid { get; set; }

        public Login LoginDetil()
        {  
           if ( this.LoginUser=="amb" &&   this.Password=="123")
            {
                this.Role = "Admin";
                this.Isvalid = true;
                return this;
            }
            if (this.LoginUser == "amb1" && this.Password == "123")
            {
                this.Role = "User";
                this.Isvalid = true;
                return this;
            }
            else
            {
                return this;
            }
        }
    }
}