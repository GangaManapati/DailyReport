using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3005.DTOs
{
    public class EmployeeDto
    {
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpPhno { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }


    }
}