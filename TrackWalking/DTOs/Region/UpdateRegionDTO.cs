using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NZWalks.DTOs.Region
{
    public class UpdateRegionDTO
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 characters")]
        [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string Name { get; set; }

        [DisplayName("Region Image URL")]
        public string? RegionImageUrl { get; set; }
    }
}
