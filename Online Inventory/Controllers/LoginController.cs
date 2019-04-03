using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Online_Inventory.Models;


namespace Online_Inventory.Controllers
{
    public class LoginController : Controller
    {
        GiftsOnlineDBEntities db = new GiftsOnlineDBEntities();
        // GET: Session
        public ActionResult AdminLogin()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Autherize(LoginCred credModel)
        {

            using (GiftsOnlineDBEntities db = new GiftsOnlineDBEntities())
            {
                var check = db.LoginCreds.Where(hs => hs.emailadmin.Equals(credModel.emailadmin)).FirstOrDefault();
                var check2 = db.LoginCreds.Where(x => x.passtologin.Equals(credModel.passtologin)).FirstOrDefault();

                if (check == null || check2 == null)
                {
                    credModel.LoginErrorMessage = "Invalid or Empty Credentials!";
                    return View("AdminLogin", credModel);
                }

                else
                {
                    Session["email"] = check.emailadmin;

                    return RedirectToAction("HomePage", "Home");
                }
            }
        }
    }
}