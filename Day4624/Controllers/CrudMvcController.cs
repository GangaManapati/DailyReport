using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using WebApplication4624.Models;

namespace WebApplication4624.Controllers
{
    public class CrudMvcController : Controller
    {
        // GET: CrudMvc
        HttpClient cli = new HttpClient();
        public ActionResult Index()
        {
            List<Employee> emp_list = new List<Employee>();
            cli.BaseAddress = new Uri("http://localhost:59098/api/CrudApi");
            var x = cli.GetAsync("CrudApi");  // for getting the data
            x.Wait();
            var test = x.Result;
            if (test.IsSuccessStatusCode)
            {
                var dis = test.Content.ReadAsAsync<List<Employee>>();
                dis.Wait();
                emp_list = dis.Result;
            }
            return View(emp_list);


        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee p = null;
            cli.BaseAddress = new Uri("http://localhost:59098/api/CrudApi");
            var x = cli.GetAsync("CrudApi?id=" + id.ToString());  // for getting the data
            x.Wait();
            var test = x.Result;
            if (test.IsSuccessStatusCode)
            {
                var dis = test.Content.ReadAsAsync<Employee>();
                dis.Wait();
                p = dis.Result;
            }
            return View(p);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            cli.BaseAddress = new Uri("http://localhost:59098/api/CrudApi");
            var x = cli.PostAsJsonAsync("CrudApi", emp);   // for post the data
            x.Wait();
            var t = x.Result;
            if (t.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }


        public ActionResult Edit(int id)
        {
            Employee p = null;
            cli.BaseAddress = new Uri("http://localhost:59098/api/CrudApi");
            var x = cli.GetAsync("CrudApi?id=" + id.ToString());  // for getting the data
            x.Wait();
            var test = x.Result;
            if (test.IsSuccessStatusCode)
            {
                var dis = test.Content.ReadAsAsync<Employee>();
                dis.Wait();
                p = dis.Result;
            }
            return View(p);


        }

        [HttpPost]
        public ActionResult Edit(Employee e)
        {

            cli.BaseAddress = new Uri("http://localhost:59098/api/CrudApi");
            var x = cli.PutAsJsonAsync<Employee>("CrudApi", e);   // for post the data
            x.Wait();
            var t = x.Result;
            if (t.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit");

        }
        public ActionResult Delete(int id)
        {
            Employee p = null;
            cli.BaseAddress = new Uri("http://localhost:59098/api/CrudApi");
            var x = cli.GetAsync("CrudApi?id=" + id.ToString());  // for getting the data
            x.Wait();
            var test = x.Result;
            if (test.IsSuccessStatusCode)
            {
                var dis = test.Content.ReadAsAsync<Employee>();
                dis.Wait();
                p = dis.Result;
            }
            return View(p);


        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            cli.BaseAddress = new Uri("http://localhost:59098/api/CrudApi");
            var x = cli.DeleteAsync("CrudApi/"+id.ToString());   // for post the data
            x.Wait();
            var t = x.Result;
            if (t.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
        }
    }
}
