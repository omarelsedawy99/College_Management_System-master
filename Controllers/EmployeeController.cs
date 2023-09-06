using Project.Authorization;
using Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    [CustomAuthenticationFilter]
    [CustomAuthorize("Employee")]
    public class EmployeeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            ViewData["Employee"] = (Session["UserData"] as User).Employee;
            return View();
        }

        [HttpGet, ActionName("Profile")]
        public ActionResult ProfileGet(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["Employee"] = employee;
            return View();
        }

        [HttpPost, ActionName("Profile")]
        public ActionResult ProfilePost(Employee update, HttpPostedFileBase profileImg, bool deleteImg)
        {
            Employee current = db.Employees.Find(update.EmployeeID);
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
                return RedirectToAction("Profile", new { id = current.EmployeeID });
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
                        current.User.UserPicture = new UserPicture() { Path = path };
                    }
                }
            }

            db.SaveChanges();
            return RedirectToAction("Profile", new { id = current.EmployeeID });
        }

        public ActionResult Mail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Mail(Mail mail, string ReceiverEmail)
        {
            mail.ReceiverID = (from u in (db.Users.ToList()) where u.Email == ReceiverEmail select u.UserId).FirstOrDefault<int>();
            if (mail.ReceiverID == null)
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
    }
}