using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeZen_SDTP.Data;
using CodeZen_SDTP.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace CodeZen_SDTP.Controllers
{
    public class DriverController : Controller
    {
        private readonly IConfiguration _configuration;

        public DriverController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public int getUserID()
        {
            string key = "UserID";
            string CookieValue = Request.Cookies[key];
            int uid;
            int.TryParse(CookieValue, out uid);
            return uid;
        }

        public int uid;

        // GET: Driver
        public IActionResult Index()
        {
            uid = getUserID();
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlcon.Open();
                SqlDataAdapter SqlDA = new SqlDataAdapter("VehicleViewByID", sqlcon);
                SqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlDA.Fill(dtbl);

            }
            return View(dtbl);
        }

        // GET: Driver/AddOrEdit/
        public IActionResult AddOrEdit(int uid)
        {
            DriverViewModel driverViewModel = new DriverViewModel();
            if (uid > 0)
            {
                driverViewModel = FetchDriverByID(uid);
            }
            return View(driverViewModel);
        }
        
        public IActionResult VehicleAddOrEdit()
        {
            return View();
        }

        public IActionResult VehicleDelete()
        {
            return View();
        }

        public IActionResult AccidentAddOrEdit()
        {
            return View();
        }

        public IActionResult AccidentDelete()
        {
            return View();
        }

        // POST: Driver/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult AddOrEdit([Bind("Name,Email,Password,Mobile_Number,NIC,License_Number")] DriverViewModel driverViewModel)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("DriverAddOrEdit", sqlcon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("Name", driverViewModel.Name);
                    sqlcmd.Parameters.AddWithValue("Email", driverViewModel.Email);
                    sqlcmd.Parameters.AddWithValue("Password", driverViewModel.Password);
                    sqlcmd.Parameters.AddWithValue("Mobile_Number", driverViewModel.Mobile_Number);
                    sqlcmd.Parameters.AddWithValue("NIC", driverViewModel.NIC);
                    sqlcmd.Parameters.AddWithValue("License_Number", driverViewModel.License_Number);
                    sqlcmd.ExecuteNonQuery();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(driverViewModel);
        }

        // GET: Driver/Delete/5
        public IActionResult Delete(int? id)
        {
            DriverViewModel driverViewModel = FetchDriverByID(id);
            return View(driverViewModel);
        }

        // POST: Driver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("DriverDeleteByID", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("Driver_ID", uid);
                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public DriverViewModel FetchDriverByID(int? id)
        {
            DriverViewModel driverViewModel = new DriverViewModel();
            using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                DataTable dtbl = new DataTable();
                sqlcon.Open();
                SqlDataAdapter SqlDA = new SqlDataAdapter("DriverViewByID", sqlcon);
                SqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                //SqlDA.SelectCommand.Parameters.AddWithValue("Driver_ID", id);
                SqlDA.Fill(dtbl);
                if(dtbl.Rows.Count == 1)
                {
                    //driverViewModel.Driver_ID =Convert.ToInt32(dtbl.Rows[0]["Driver_ID"].ToString());
                    driverViewModel.Name = dtbl.Rows[0]["Name"].ToString();
                    driverViewModel.Email = dtbl.Rows[0]["Email"].ToString();
                    driverViewModel.Password = dtbl.Rows[0]["Password"].ToString();
                    driverViewModel.Mobile_Number = dtbl.Rows[0]["Mobile_Number"].ToString();
                    driverViewModel.NIC = dtbl.Rows[0]["NIC"].ToString();
                    driverViewModel.License_Number = dtbl.Rows[0]["License_Number"].ToString();
                }
                return (driverViewModel);
            }
        }
    }
}
