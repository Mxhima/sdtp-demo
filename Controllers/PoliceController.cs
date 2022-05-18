using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeZen_SDTP.Controllers
{
    public class PoliceController : Controller
    {
        private readonly IHttpContextAccessor _HttpAccessor;
        public PoliceController(IHttpContextAccessor httpContextAccessor)
        {
            _HttpAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            string CookieValue = _HttpAccessor.HttpContext.Request.Cookies["key"];
            string CookieValueReq = Request.Cookies["key"];
            return View();
        }
    }
}
