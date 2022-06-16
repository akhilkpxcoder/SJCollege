using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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