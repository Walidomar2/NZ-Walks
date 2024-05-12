using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models
{
    public class Walk
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public double LengthInKm { get; set; }
        public string WalkImageUrl { get; set; }

        public Guid RegionId { get; set; }

        public Guid DifficultyId { get; set; } 
    }
}
