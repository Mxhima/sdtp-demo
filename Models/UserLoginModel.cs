using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeZen_SDTP.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Please enter your email")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public int UserType { get; set; }
    }
}
