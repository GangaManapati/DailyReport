using Day2852024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day2852024.Controllers
{
    public class UserModelController : Controller
    {
        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                // Save the data to the database
                return RedirectToAction("Register");
            }

            // If we got this far, something failed; redisplay form
            return View(model);
        }

    }
}