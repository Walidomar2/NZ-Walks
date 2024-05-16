using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.DTOs.Region
{
    public class RegionDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        [DisplayName("Region Image URL")]
        public string? RegionImageUrl { get; set; }
    }
}
