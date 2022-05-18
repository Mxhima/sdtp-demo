using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeZen_SDTP.Models
{
    public class InsuranceViewModel
    {
        public int Insurance_ID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Insurance_Name { get; set; }
        [Required]
        [ForeignKey("Master_ID")]
        public WebMasterModel Created_Master_ID { get; set; }
        public ICollection<VehicleViewModel> VehicleID { get; set; }
    }
}
