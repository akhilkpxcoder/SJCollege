using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using static RestSharp.RestClientOptions;
using SJCollege.Models;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Windows;

namespace SJCollege.Controllers
{
    public class AccountController : Controller
    {
        public class ID
        {
            public string Id { get; set; }
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            string url = "https://localhost:44386/api/login";
            var client = new RestClient();
            var requests = new RestRequest()
            {
                Resource = url
            };
            requests.AddHeader("Content-Type", "application/json");
            requests.AddHeader("Accept", "application/json");
            requests.AddJsonBody(userModel);
            var response = client.Post(requests);
            if (response.IsSuccessful)
            {
                var userdata = JsonConvert.DeserializeObject<UserModel>(response.Content);
                Session["Name"] = userdata.Name;
                Session["Batch"] = userdata.Batch;
                Session["ID"] = userdata.Id;
                if (userdata.Role == "student")
                {
                        return RedirectToAction("Index", "Student",true);
                }
                else if (userdata.Role == "faculty")
                {

                    return RedirectToAction("Index", "Faculty",true);

                }
                else if (userdata.Role == "admin")
                {
                    return RedirectToAction("Index", "Admin",true);
                }
                else
                {
                    MessageBox.Show("Incorrect Email or Password");
                    return View();
                }
            }
            else
            {
                MessageBox.Show("Incorrect Email or Password");
                return View();
            }
        }
        public ActionResult Register()
        {
            List<SelectListItem> obj = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Male", Value = "Male" },
                new SelectListItem { Text = "Female", Value = "Female" },
            };
            //Assigning generic list to ViewBag
            ViewBag.Gender = obj;

            List<SelectListItem> obj2 = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Student", Value = "Student" },
                new SelectListItem { Text = "Faculty", Value = "Faculty" },
            };
            //Assigning generic list to ViewBag
            ViewBag.Role = obj2;
            return View();
        }
    }

}