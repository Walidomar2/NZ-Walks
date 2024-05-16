using NZWalks.DTOs.Difficulty;
using NZWalks.DTOs.Region;
using NZWalks.Models;
using System.ComponentModel.DataAnnotations;

namespace NZWalks.DTOs.Walk
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public RegionDTO Region { get; set; }
        public DifficultyDTO Difficulty { get; set; }
       
    }
}
