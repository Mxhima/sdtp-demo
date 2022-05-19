using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeZen_SDTP.Models
{
    public class VehicleViewModel
    {
        [Key]
        public int Vehicle_ID { get; set; }
        [Required]
        public string Vehicle_Reg_No { get; set; }

        public string Vehicle_Type { get; set; }

        [ForeignKey("Driver_ID")]
        public int Driver_ID { get; set; }
        [ForeignKey("Insurance_ID")]
        public int Insurance_ID { get; set; }
    }
}
