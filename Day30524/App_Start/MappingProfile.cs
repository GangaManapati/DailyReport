using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApplication3005.DTOs;
using WebApplication3005.Models;

namespace WebApplication3005.App_Start
{
    public class MappingProfile  :Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Employee, EmployeeDto>();
            Mapper.CreateMap<EmployeeDto,Employee>();//CreateMap<Employee, EmployeeDto>().ReverseMap();
        }

    }
}