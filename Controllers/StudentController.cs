using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Project.Authorization;

namespace Project.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorize("Student")]
    public class StudentController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Mail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Mail(Mail mail, string ReceiverEmail)
        {
            mail.ReceiverID = (from u in (db.Users.ToList()) where u.Email == ReceiverEmail select u.UserId).FirstOrDefault<int>();
            if(mail.ReceiverID == null)
            {
                return View();
            }
            mail.Inbox = true;
            mail.Draft = false;
            mail.Sent = false;
            mail.Trash = false;
            mail.DateTime = DateTime.Now;

            db.Mails.Add(mail);
            db.SaveChanges();

            return View();
        }

        public ActionResult Index()
        {
            ViewData["Student"] = (Session["UserData"] as User).Student;
            return View();
        }

        [HttpGet, ActionName("Profile")]
        public ActionResult ProfileGet(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["Student"] = student;
            return View();
        }

        [HttpPost, ActionName("Profile")]
        public ActionResult ProfilePost(Student update, HttpPostedFileBase profileImg, bool deleteImg)
        {
            Student current = db.Students.Find(update.StudentID);
            current.User.Phone = update.User.Phone;
            current.User.Email = update.User.Email;
            current.User.Password = update.User.Password;
            current.User.Street = update.User.Street;
            current.User.City = update.User.City;
            current.User.Country = update.User.Country;

            if (deleteImg)
            {
                if (current.User.UserPicture != null) //check if there is an old image
                {
                    string imgPath = Server.MapPath(current.User.UserPicture.Path); //get path of the old image
                    if (System.IO.File.Exists(imgPath)) //check if image file is exist
                    {
                        System.IO.File.Delete(imgPath); //delete the old image
                    }
                    db.UserPictures.Remove(current.User.UserPicture);
                    db.SaveChanges();
                }
                return RedirectToAction("Profile" , new { id = current.StudentID.ToString() });
            }

            if (profileImg != null) //check if there is anychange in profile image
            {
                if (current.User.UserPicture != null && profileImg.ContentType.Contains("image")) //check if there is an old image
                {
                    string imgPath = Server.MapPath("~/" + current.User.UserPicture.Path); //get path of the old image
                    if (System.IO.File.Exists(imgPath)) //check if image file is exist
                    {
                        System.IO.File.Delete(imgPath); //delete the old image
                    }
                }
                if (profileImg.ContentType.Contains("image"))
                {
                    string path = "~/Database/Images/" + Path.GetFileName(profileImg.FileName); //get path of new image
                    profileImg.SaveAs(Server.MapPath(path)); //save new uploaded profile image file
                    if (current.User.UserPicture != null)
                    {
                        current.User.UserPicture.Path = path; //update profile image
                    }
                    else
                    {
                        current.User.UserPicture = new UserPicture() { Path = path};
                    }
                }
            }

            db.SaveChanges();
            return RedirectToAction("Profile", new { id = current.StudentID.ToString() });
        }

        [HttpGet]
        public ActionResult ViewCourses(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["Courses"] = student.Courses;
            //Redirect to the view of student's courses or edit it if you are doing it in different way.
            return View("~/Views/Student/Courses.cshtml");
        }

        [HttpGet]
        public ActionResult ViewTimetable(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return RedirectToAction("Index");
            }

            Timetable timetable = new Timetable();
            foreach (var item in db.Timetables)
            {
                if (item.Lvl == student.Lvl && item.MajorDepID == student.MajorDepID && item.MinorDepID == student.MinorDepID)
                {
                    timetable = item;
                }
            }
            ViewData["Timetable"] = timetable;
            return View();
        }
    }
}