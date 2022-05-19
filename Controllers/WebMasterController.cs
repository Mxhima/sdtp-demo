using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CodeZen_SDTP.Controllers
{
    public class WebMasterController : Controller
    {
        private readonly IConfiguration _configuration;

        public WebMasterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePolice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePolice(string Email, string Pssword, string District, string City)
        {
            //master ID
            using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("WebMasterAddPolice", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Pssword);
                cmd.Parameters.AddWithValue("@District", District);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        public IActionResult CreateRDA()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRDA(string Email, string Pssword, string Branch)
        {
            //master ID
            using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("WebMasterAddRDA", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Pssword);
                cmd.Parameters.AddWithValue("@Branch", Branch);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }
        public IActionResult CreateInsurance()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateInsurance(string Email, string Pssword, string InsuranceName)
        {
            //master ID
            using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("WebMasterAddInsurance", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Pssword);
                cmd.Parameters.AddWithValue("@Insurance_Name", InsuranceName);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

    }
}
