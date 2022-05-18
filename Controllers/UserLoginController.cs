using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeZen_SDTP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Web;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace CodeZen_SDTP.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IConfiguration _configuration;

        public UserLoginController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string txtEmail, string txtPassword, string slctUserType)
        {
            using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("dbo.UserLogin", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 40).Value = txtEmail ?? "";
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 200).Value = txtPassword ?? "";
                cmd.Parameters.Add("@UserType", SqlDbType.VarChar, 50).Value = slctUserType ?? "";

                SqlParameter RuturnValue = new SqlParameter("@UserID", SqlDbType.Int);
                RuturnValue.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(RuturnValue);
                cmd.ExecuteNonQuery();
                int? UID = (int)cmd.Parameters["@UserID"].Value;

                if (UID == 0)
                {
                    
                }

            
                
                else
                {
                    
                    if (slctUserType == "Driver")
                    {
                        int? expTime = 120;
                        string keyID = "UserID";
                        string keyUserType = "UserType";
                        string uid = UID.ToString();
                        CookieOptions options = new CookieOptions();
                        if (expTime.HasValue)
                        {
                            options.Expires = DateTime.Now.AddMinutes(expTime.Value);
                            Response.Cookies.Append(keyID, uid, options);
                            Response.Cookies.Append(keyUserType, slctUserType, options);
                        }
                        else
                        {
                            options.Expires = DateTime.Now.AddMinutes(120);
                            Response.Cookies.Append(keyID, uid, options);
                            Response.Cookies.Append(keyUserType, slctUserType, options);
                        }
                        return RedirectToAction("Index", "Driver");
                    }
                    
                    else if (slctUserType == "Police")
                    {
                        int? expTime = 120;
                        string keyID = "UserID";
                        string keyUserType = "UserType";
                        string uid = UID.ToString();
                        CookieOptions options = new CookieOptions();
                        if (expTime.HasValue)
                        {
                            options.Expires = DateTime.Now.AddMinutes(expTime.Value);
                            Response.Cookies.Append(keyID, uid, options);
                            Response.Cookies.Append(keyUserType, slctUserType, options);
                        }
                        else
                        {
                            options.Expires = DateTime.Now.AddMinutes(120);
                            Response.Cookies.Append(keyID, uid, options);
                            Response.Cookies.Append(keyUserType, slctUserType, options);
                        }
                        return RedirectToAction("Index", "UserLogin");
                    }

                    else if (slctUserType == "RDA")
                    {
                        int? expTime = 120;
                        string keyID = "UserID";
                        string keyUserType = "UserType";
                        string uid = UID.ToString();
                        CookieOptions options = new CookieOptions();
                        if (expTime.HasValue)
                        {
                            options.Expires = DateTime.Now.AddMinutes(expTime.Value);
                            Response.Cookies.Append(keyID, uid, options);
                            Response.Cookies.Append(keyUserType, slctUserType, options);
                        }
                        else
                        {
                            options.Expires = DateTime.Now.AddMinutes(120);
                            Response.Cookies.Append(keyID, uid, options);
                            Response.Cookies.Append(keyUserType, slctUserType, options);
                        }
                        return RedirectToAction("Index", "UserLogin");
                    }

                    else
                    {
                        int? expTime = 120;
                        string keyID = "UserID";
                        string keyUserType = "UserType";
                        string uid = UID.ToString();
                        CookieOptions options = new CookieOptions();
                        if (expTime.HasValue)
                        {
                            options.Expires = DateTime.Now.AddMinutes(expTime.Value);
                            Response.Cookies.Append(keyID, uid, options);
                            Response.Cookies.Append(keyUserType, slctUserType, options);
                        }
                        else
                        {
                            options.Expires = DateTime.Now.AddMinutes(120);
                            Response.Cookies.Append(keyID, uid, options);
                            Response.Cookies.Append(keyUserType, slctUserType, options);
                        }
                        return RedirectToAction("Index", "UserLogin");
                    }
                }
                sqlcon.Close();
            } 
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult Index(UserLoginModel ULM)
        //{
        //    using (SqlConnection sqlcon = new SqlConnection(_configuration.GetConnectionString("DevConnection")))
        //    {
        //        sqlcon.Open();
        //        SqlDataAdapter SqlDA = new SqlDataAdapter("VehicleViewByID", sqlcon);
        //        SqlDA.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        SqlCommand sqlcom = new SqlCommand();
        //        sqlcom.Parameters.AddWithValue("@Email", ULM.Email);
        //        sqlcom.Parameters.AddWithValue("@Password", ULM.Password);
        //        sqlcom.Parameters.AddWithValue("@UserType", ULM.UserType);
        //        SqlDataReader sdr = sqlcom.ExecuteReader();
        //        if (sdr.Read())
        //        {
        //           HttpContext.Session["Email"] = ULM.Email.ToString();
        //        }
        //    }
            
        //    return View();
        //}
    }
}
