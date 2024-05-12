using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models
{
    public class Region
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        public string? RegionImageUrl { get; set; }
    }
}
