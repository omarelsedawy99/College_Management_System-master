using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            var users = db.Users.ToList();
            if(Email != null && Password != null)
            {
                var user = (from u in users where u.Email.Equals(Email) && u.Password.Equals(Password) select u).FirstOrDefault<User>();
                if (user != null)
                {
                    Session["UserData"] = user;
                    if(user.Role.Title == "Dean")
                    {
                        return RedirectToAction("Index", "Dean");
                    }
                    else if (user.Role.Title == "Doctor")
                    {
                        return RedirectToAction("Index", "Doctor");
                    }
                    else if (user.Role.Title == "Student")
                    {
                        return RedirectToAction("Index", "Student");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}