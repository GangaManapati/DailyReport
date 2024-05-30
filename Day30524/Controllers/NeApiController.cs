using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using WebApplication3005.Models;

namespace WebApplication3005.Controllers
{
    public class NeApiController : ApiController
    {
       
       EmployeeDBEntities1 e = new EmployeeDBEntities1();


        // api/NeApi
        [System.Web.Http.HttpGet]
        public IHttpActionResult Index()
        {
            List<Employee> emp = e.Employees.ToList();
            return Ok(emp);
        }

        // api/NeApi/{id}
        [System.Web.Http.HttpGet]
        public IHttpActionResult Index(int id)
        {
            var emp = e.Employees.Where(c=>c.EmpId==id );
            return Ok(emp);
        }


        // api/NeApi
        [System.Web.Http.HttpPost]
        public void  Index([FromBody]Employee em)
        {
            e.Employees.Add(em);
            e.SaveChanges();
           
        }
        // api/NeApi/{id}
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateEmployee(int id, [FromBody] Employee em)
        {
            if (em == null)
            {
                return BadRequest("Employee cannot be null.");
            }

            var existingEmployee = e.Employees.FirstOrDefault(c => c.EmpId == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.EmpName = em.EmpName;
            existingEmployee.EmpAddress = em.EmpAddress;
            existingEmployee.EmpPhno = em.EmpPhno;
            existingEmployee.DateOfBirth = em.DateOfBirth;
            existingEmployee.HireDate = em.HireDate;
          
         

            e.SaveChanges();

            return Ok(existingEmployee);
        }


        // api/NeApi/{id}
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var emp = e.Employees.FirstOrDefault(c => c.EmpId == id);
            if (emp == null)
            {
                return NotFound();
            }

            e.Employees.Remove(emp);
            e.SaveChanges();

            return Ok();
        }
    }





}