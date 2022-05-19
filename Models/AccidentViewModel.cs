using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeZen_SDTP.Models
{
    public class AccidentViewModel
    {
        [Key]
        public int Accident_ID { get; set; }

        [Required]
        [ForeignKey("Driver_ID")]
        public ICollection<DriverViewModel> Driver_ID { get; set; }

        [Required]
        [ForeignKey("Vehicle_ID")]
        public ICollection<DriverViewModel> Vehicle_ID { get; set; }

        public string District { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }
        public int RDA_Validate { get; set; }
        public int Police_Validate { get; set; }
        public int Insurance_Validate { get; set; }

    }
}
