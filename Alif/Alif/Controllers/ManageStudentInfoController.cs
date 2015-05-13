using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alif.Controllers
{
    public class ManageStudentInfoController : Controller
    {
        // GET: ManageStudentInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowStudents()
        {
            return PartialView("ShowAllStudent");
        }
    }
}