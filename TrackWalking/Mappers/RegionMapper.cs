using NZWalks.DTOs.Region;
using NZWalks.Models;

namespace NZWalks.Mappers
{
    public static class RegionMapper
    {
        public static RegionDTO ToRegionDto(this Region model)
        {
            return new RegionDTO
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code,
                RegionImageUrl = model.RegionImageUrl
            };
        }


        public static Region ToCreateRegionDto(this CreateRegionDTO model) 
        {
            return new Region
            {
                Name = model.Name,
                Code = model.Code,
                RegionImageUrl = model.RegionImageUrl
            };
        }


    }
}
