using System.ComponentModel.DataAnnotations;

namespace NZWalks.Models
{
    public class Difficulty
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
