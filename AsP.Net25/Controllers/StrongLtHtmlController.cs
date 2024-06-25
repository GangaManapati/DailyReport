using AspNETMVc24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNETMVc24.Controllers
{
    public class StrongLtHtmlController : Controller
    {
        // GET: StrongLtHtml
        public ActionResult StronglyHtml()
        {

            Employee emp = new Employee()
            {
                Id = 1,
                Name = "ganga",
                Title = "Developer",
                Description = "nothing",
                //  Salary=109987112
            };
            return View(emp);
        }
        [HttpPost]
        public ActionResult StronglyHtml(Employee emp)
        {
            return View(emp);
        }
    }
}