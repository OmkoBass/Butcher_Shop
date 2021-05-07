using AutoMapper;
using Butcher_Shop.Dtos;
using Butcher_Shop.Dtos.Butcher;
using Butcher_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Profiles
{
    public class ButcherProfile : Profile
    {
        public ButcherProfile()
        {
            CreateMap<Butcher, ButcherDto>().ReverseMap();

            CreateMap<Butcher, AddButcherDto>().ReverseMap();
        }
    }
}
