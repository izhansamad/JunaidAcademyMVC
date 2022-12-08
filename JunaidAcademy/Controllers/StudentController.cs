using JunaidAcademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using JunaidAcademy.Models;



namespace JunaidAcademy.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private JunaidAcademyEntities1 db = new JunaidAcademyEntities1();
        // GET: Student
        public ActionResult Index()
        {
            return View(db.CourseAssigns.Where(w=> w.User.Username == HttpContext.User.Identity.Name).ToList());
        }
    }
}