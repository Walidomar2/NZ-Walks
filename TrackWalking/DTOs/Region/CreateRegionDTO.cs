using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NZWalks.DTOs.Region
{
    public class CreateRegionDTO
    {
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Region Image URL")]
        public string? RegionImageUrl { get; set; }
    }
}
