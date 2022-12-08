using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JunaidAcademy.Models;

namespace JunaidAcademy.Controllers
{
    [Authorize(Users = "Admin")]
    public class CourseAssignsController : Controller
    {
        private JunaidAcademyEntities1 db = new JunaidAcademyEntities1();

        // GET: CourseAssigns
        public ActionResult Index()
        {
            var courseAssigns = db.CourseAssigns.Include(c => c.Course).Include(c => c.User);
            return View(courseAssigns.ToList());
        }

        // GET: CourseAssigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseAssign = db.CourseAssigns.Find(id);
            if (courseAssign == null)
            {
                return HttpNotFound();
            }
            return View(courseAssign);
        }

        // GET: CourseAssigns/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username");
            return View();
        }

        // POST: CourseAssigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseAssignID,UserID,CourseID")] CourseAssign courseAssign)
        {
            if (ModelState.IsValid)
            {
                db.CourseAssigns.Add(courseAssign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseAssign.CourseID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", courseAssign.UserID);
            return View(courseAssign);
        }

        // GET: CourseAssigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseAssign = db.CourseAssigns.Find(id);
            if (courseAssign == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseAssign.CourseID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", courseAssign.UserID);
            return View(courseAssign);
        }

        // POST: CourseAssigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseAssignID,UserID,CourseID")] CourseAssign courseAssign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseAssign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", courseAssign.CourseID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Username", courseAssign.UserID);
            return View(courseAssign);
        }

        // GET: CourseAssigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseAssign courseAssign = db.CourseAssigns.Find(id);
            if (courseAssign == null)
            {
                return HttpNotFound();
            }
            return View(courseAssign);
        }

        // POST: CourseAssigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseAssign courseAssign = db.CourseAssigns.Find(id);
            db.CourseAssigns.Remove(courseAssign);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
