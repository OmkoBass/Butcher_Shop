using AutoMapper;
using Butcher_Shop.Dtos;
using Butcher_Shop.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Butcher_Shop.Models.Employee, EmployeeDto>().ReverseMap();
        }
    }
}
