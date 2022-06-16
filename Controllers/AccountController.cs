using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using static RestSharp.RestClientOptions;
using SJCollege.Models;


namespace SJCollege.Controllers
{
    public class AccountController : Controller
    {
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
            requests.AddHeader("Accept", "application/xml");
            requests.AddJsonBody(userModel);
            var response = client.Post(requests);
            string content = response.Content;

            return View();
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