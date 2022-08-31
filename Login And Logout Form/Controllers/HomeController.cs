using Login_And_Logout_Form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Login_And_Logout_Form.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult login(Loginclass lobj)
        {
            logindbEntities eobj = new logindbEntities();
            var result = eobj.LoginTableOuts.Where(a => a.UserEmail == lobj.UserEmail).FirstOrDefault();
            if (result==null)
            {
                TempData["email"] = "Rong Email";
            }
            else
            {
                if (result.UserEmail==lobj.UserEmail && result.UserPassword==lobj.UserPassword)
                {
                    FormsAuthentication.SetAuthCookie(result.UserEmail,false);
                    Session["email"] = result.UserEmail;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["pass"] = "Password Rong";
                }
            }

            return View();
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
         return   RedirectToAction("login");
        }
    }
}