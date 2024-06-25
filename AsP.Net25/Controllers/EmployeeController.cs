using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AspNETMVc24.Models;

namespace AspNETMVc24.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
       /* public String Index(int i)
        {
            String s=String.Empty;
            if(i==1)
            {
                s=s+"Ganga1";
            }
            else if (i == 2)
            {
                s =s+ "Ganga2";
            }
           else if (i == 3)
            {
                s = "Ganga3";
            }
            else
            {
                s = "no one with id";
            }
            return s;
        }
        public String Index1(int i, String Dep)
        {
            String s = String.Empty;
            if (i == 1)
            {
                s =  "Ganga1";
            }
            else if (i == 2)
            {
                s = s + "Ganga2";
            }
            else if (i == 3)
            {
                s = "Ganga3";
            }
            else
            {
                s = "no one with id";
            }
            return s+Dep;
        }  */
       public ActionResult Index()
        {
            var d=Get();
            return View(d);
        }
        public ActionResult Details()
        {
            return View("~/Views/Viewx/View.cshtml");
        }

        private Employee Get()
        {
            Employee emp = new Employee()
            {
                Id = 1,
                Name = "ganga",
                Title = "Developer",
                Description = "nothing",
             //  Salary=109987112
            };
            return emp;
        }


    }
}