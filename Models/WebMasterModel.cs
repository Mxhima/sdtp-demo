using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeZen_SDTP.Models
{
    public class WebMasterModel
    {
        [Key]
        public int Master_ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<PoliceViewModel> PoliceViewModel { get; set; }
        public ICollection<InsuranceViewModel> InsuranceViewModel { get; set;  }
    }
}
