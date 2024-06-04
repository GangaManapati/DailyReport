using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4624.Models;

namespace WebApplication4624.Controllers
{
    public class CrudApiController : ApiController
    {
        web_api_CRUD_dbEntities1 db=new web_api_CRUD_dbEntities1();
        [HttpGet]
        public IHttpActionResult GetEmployee()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult GetEmployeIde(int id)
        {
            Employee e=db.Employees.Where(c=>c.id==id).SingleOrDefault();  
            return Ok(e);
        }
         [HttpPost]
        public IHttpActionResult Emp(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }


        [HttpPut]
        public IHttpActionResult EmpUpdate(Employee e)
        {
            db.Entry(e).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            /* Employee s = db.Employees.Where(c => c.id == e.id).SingleOrDefault();
             if (s != null)
             {
                   s.id = e.id;
                 s.name = e.name;
                 s.age = e.age;
                 s.gender = e.gender;
                 s.salary = e.salary;
                 s.designition = e.designition;
                 db.SaveChanges();

             }
             else
             {
                 return NotFound();
             } 


             return Ok(s);
            */

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {
            Employee e = db.Employees.Where(c => c.id == id).SingleOrDefault();
            db.Entry(e).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }


    }
}
