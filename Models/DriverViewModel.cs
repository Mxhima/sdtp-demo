using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeZen_SDTP.Models
{
    public class DriverViewModel
    {
        [Required(ErrorMessage = "Please Enter Your Name!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter Your Mobile Number!")]
        public string Mobile_Number { get; set; }
        [Required(ErrorMessage = "Please Enter Your NIC!")]
        public string NIC { get; set; }
        [Required(ErrorMessage = "Please Enter Your License Number!")]
        public string License_Number { get; set; }

        public int Driver_ID { get; set; }
        public int Vehicle_ID { get; set; }

        public int Insurance_ID { get; set; }
    }
}
