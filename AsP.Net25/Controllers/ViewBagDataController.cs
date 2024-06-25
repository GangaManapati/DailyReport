using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNETMVc24.Controllers
{
    public class ViewBagDataController : Controller
    {
        // GET: ViewBagData
        public ActionResult Index()
        {
            ViewBag.X = "Ganga";
            ViewBag.List = new List<string>(){ "ganga", "ram", "dfsgf", "shgfdtf" };


            ViewData["p"] = 1;

            return View();
        }
    }
}