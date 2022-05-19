using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeZen_SDTP.Models
{
    public class RDAViewModel
    {
        [Key]
        public int RDA_ID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        [ForeignKey("Master_ID")]

        public int Created_Master_ID { get; set; }
    }
}
