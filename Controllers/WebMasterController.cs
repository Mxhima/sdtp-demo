using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodeZen_SDTP.Controllers
{
    public class WebMasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
