using College_Management_System.DBContext;
using College_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace College_Management_System.Controllers
{
    [Route("api/Student")]
    public class StudentController : Controller
    {
        // GET: Student
        private CLGContext db = new CLGContext();
        public ActionResult Index()
        {
            return Json(db.Students.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Login()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Login(Student student)
        {
            var student1 = db.Students.Where(x => x.StudentName == student.StudentName && x.Password == student.Password).FirstOrDefault();
            if (student1==null)
                return RedirectToAction("Message", "Error");
            else
                return RedirectToAction("Details", "Student", new { id = student1.StudentId });

        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult Add(Models.Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index", "Student");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            return View(student);

        }
        [HttpPut, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var studentToUpdate = db.Students.Find(id);
            if (TryUpdateModel(studentToUpdate, "",
               new string[] { "Name", "Password", "Branch", "Semester" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (System.Data.DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(studentToUpdate);
        }

        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Student student = db.Students.Find(id);
                db.Students.Remove(student);
                db.SaveChanges();
            }
            catch (System.Data.DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }


    }
}