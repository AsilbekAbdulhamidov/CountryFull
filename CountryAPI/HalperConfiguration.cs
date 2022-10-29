using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data1.DTO;
using Data1.Models;

namespace Data
{
    public class HalperConfiguration:Profile
    {
        public HalperConfiguration()
        {
            CreateMap<CounrtyDto, Country>().ReverseMap();
            CreateMap<Region,RegionDto>().ReverseMap(); 
        }
      
    }
}
