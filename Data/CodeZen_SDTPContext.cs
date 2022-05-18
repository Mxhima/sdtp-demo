using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeZen_SDTP.Models;

namespace CodeZen_SDTP.Data
{
    public class CodeZen_SDTPContext : DbContext
    {
        public CodeZen_SDTPContext (DbContextOptions<CodeZen_SDTPContext> options)
            : base(options)
        {
        }

        public DbSet<CodeZen_SDTP.Models.DriverViewModel> DriverViewModel { get; set; }
    }
}
