using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CodeZen_SDTP.Models;
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

        public class ModelCollection
        {
            public IEnumerable<PoliceViewModel> _policeList { get; set; }
            public IEnumerable<InsuranceViewModel> _insuranceList { get; set; }
            public IEnumerable<RDAViewModel> _rdaList { get; set; }
            public IEnumerable<DriverViewModel> _driverList { get; set; }
        }

        public IActionResult Index()
        {
            ModelCollection modelCollection = new ModelCollection();
            modelCollection._policeList = getPoliceList();
            modelCollection._rdaList = getRDAList();
            modelCollection._insuranceList = getInsList();
            modelCollection._driverList = getDrivList();
            return View(modelCollection);
        }
        public List<PoliceViewModel> getPoliceList()
        {
            var _Policelist = new List<PoliceViewModel>();

            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlcon.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("WebMasterPolice", sqlcon);
                DataSet ds = new DataSet();
                cmd.Fill(ds, "Police_Account");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        _Policelist.Add(new PoliceViewModel()
                        {
                            Police_ID = (int)ds.Tables[0].Rows[i]["Police_ID"],
                            Email = (String)ds.Tables[0].Rows[i]["Email"],
                            District = (String)ds.Tables[0].Rows[i]["District"],
                            City = (String)ds.Tables[0].Rows[i]["City"],
                            Created_Master_ID = (int)ds.Tables[0].Rows[i]["Created_Master_ID"]
                        });
                    }
                }
            }

            return _Policelist;
        }
        
        public List<RDAViewModel> getRDAList()
        {
            var _RDAlist = new List<RDAViewModel>();

            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlcon.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("WebMasterRDA", sqlcon);
                DataSet ds = new DataSet();
                cmd.Fill(ds, "RDA_Account");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        _RDAlist.Add(new RDAViewModel()
                        {
                            RDA_ID = (int)ds.Tables[0].Rows[i]["RDA_ID"],
                            Email = (string)ds.Tables[0].Rows[i]["Email"],
                            Branch = (string)ds.Tables[0].Rows[i]["Branch"],
                            Created_Master_ID = (int)ds.Tables[0].Rows[i]["Created_Master_ID"]
                        });
                    }
                }
            }

            return _RDAlist;
        }

        public List<InsuranceViewModel> getInsList()
        {
            var _Inslist = new List<InsuranceViewModel>();

            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlcon.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("WebMasterInsurance", sqlcon);
                DataSet ds = new DataSet();
                cmd.Fill(ds, "Insurance_Account");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        _Inslist.Add(new InsuranceViewModel()
                        {
                            Insurance_ID = (int)ds.Tables[0].Rows[i]["Insurance_ID"],
                            Email = (string)ds.Tables[0].Rows[i]["Email"],
                            Insurance_Name = (string)ds.Tables[0].Rows[i]["Insurance_Name"],
                            Created_Master_ID = (int)ds.Tables[0].Rows[i]["Created_Master_ID"]
                        });
                    }
                }
            }

            return _Inslist;
        }

        public List<DriverViewModel> getDrivList()
        {
            var _drvlist = new List<DriverViewModel>();

            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlcon.Open();
                SqlDataAdapter cmd = new SqlDataAdapter("WebMasterDriver", sqlcon);
                DataSet ds = new DataSet();
                cmd.Fill(ds, "Driver");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        _drvlist.Add(new DriverViewModel()
                        {
                            Driver_ID = (int)ds.Tables[0].Rows[i]["Driver_ID"],
                            Name = (string)ds.Tables[0].Rows[i]["Name"],
                            Email = (string)ds.Tables[0].Rows[i]["Email"],
                            Mobile_Number = (string)ds.Tables[0].Rows[i]["Mobile_Number"],
                            NIC = (string)ds.Tables[0].Rows[i]["NIC"],
                            License_Number = (string)ds.Tables[0].Rows[i]["License_Number"],
                        });
                    }
                }
            }

            return _drvlist;
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
