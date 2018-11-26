using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace AngularApp.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "UserName must be 3 to 20 characters")]
        [Required(ErrorMessage = "UserName is a required field")]
        public string UserName { get; set; }


        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be 6 to 20 characters")]
        [Required(ErrorMessage = "Password is a required field")]
        public string Password { get; set; }

    }
}