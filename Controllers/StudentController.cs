using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJCollege.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewStudent()
        {
            return View();
        }
        public ActionResult ViewFaculty()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }

    }
}