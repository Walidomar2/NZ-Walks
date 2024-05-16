using AutoMapper;
using NZWalks.DTOs.Difficulty;
using NZWalks.DTOs.Region;
using NZWalks.DTOs.Walk;
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
            CreateMap<Walk,CreateWalkDTO>().ReverseMap();
            CreateMap<Walk,WalkDTO>().ReverseMap(); 
            CreateMap<Difficulty,DifficultyDTO>().ReverseMap();
        }
    }
}
