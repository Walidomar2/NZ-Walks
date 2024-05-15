using AutoMapper;
using NZWalks.DTOs.Region;
using NZWalks.Models;

namespace NZWalks.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<Region, CreateRegionDTO>().ReverseMap();  
            CreateMap<Region, UpdateRegionDTO>().ReverseMap();
        }
    }
}
