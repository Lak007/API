using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewZealandWalks.Models.Domain;
using NewZealandWalks.Models.DTO;

namespace NewZealandWalks.Mapping
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionDto, Region>().ReverseMap();
            CreateMap<UpdateRegionDto, Region>().ReverseMap();
        }
    }
}
