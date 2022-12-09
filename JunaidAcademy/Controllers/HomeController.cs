using JunaidAcademy.Models;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.AccessControl;
using System.Web.Mvc;
using System.Web.Security;

namespace JunaidAcademy.Controllers
{
    public class HomeController : Controller
    {
        private JunaidAcademyEntities1 db = new JunaidAcademyEntities1();
        public ActionResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.courseList = getCourses().Take(5);
            dy.teacherList = getTeacher().Take(4);
            return View(dy);
        }
        public List<Course> getCourses()
        {
            List<Course> Lcourse = db.Courses.ToList();
            return Lcourse;
        }
        public List<Teacher> getTeacher()
        {
            List<Teacher> Lteacher = db.Teachers.ToList();
            return Lteacher;
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View(db.Teachers.ToList().Take(4));
        }
        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Courses()
        {
            return View(db.Courses.ToList());
        }
        //private int GetUserID()
        //{       //    var userId = db.Users.Where(w => w.Username == User.Identity.Name).First();
        //    return userId.UserID;
        //}
        private int GetUserID()
        {
            var userId = db.Users.Where(w => w.Username == User.Identity.Name).FirstOrDefault();
            if (userId != null)
            {
                return userId.UserID;
            }
            else
            {
                return 0;
            }
        }
        public ActionResult Course(int id)
        {
            var userId = GetUserID();
            if (userId == 0)
            {
                return View(db.Courses.Where(w => w.CourseID == id).First());
            }
            if (db.CourseAssigns.Any(a => a.CourseID == id && a.UserID == userId))
            {
                TempData["AlreadyRegistered"] = "Already Registered in this Course";
            }
            return View(db.Courses.Where(w => w.CourseID == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourse(String CourseID)
        {
            var courseAssign = new CourseAssign()
            {
                UserID = GetUserID(),
                CourseID = Int32.Parse(CourseID),
            };
            db.CourseAssigns.Add(courseAssign);
            db.SaveChanges();
            return RedirectToAction("Index","Student");
        }
        

        public ActionResult Faculty()
        {
            
            return View(db.Teachers.ToList());
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using (var context = new JunaidAcademyEntities1())
            {
                bool isValid = context.Users.Any(x => x.Username.Equals(user.Username, StringComparison.Ordinal) && x.Password.Equals(user.Password, StringComparison.Ordinal));
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(user.Username,false);
                    
                    if ((user.Username=="Admin" || user.Username=="admin") && (user.Password == "Admin" || user.Password == "admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else {
                    return RedirectToAction("Index", "Student");
                    }
                }
                ModelState.AddModelError("Error", "Invalid Username or Password!");
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserID,Username,Password,FirstName,LastName,Contact,Email,Role,Image")] User user)
        {
            if (ModelState.IsValid)
            {
                var usernameExists = db.Users.Any(x => x.Username == user.Username);
                if (usernameExists)
                {
                    ModelState.AddModelError("Username", "Username already exists. Please enter a different Username.");
                    //ViewBag.ErrorMessage = "Username already exists. Please enter a different Username.";
                    return View(user);
                }
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");

            }

            return View(user);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}