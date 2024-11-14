using System.ComponentModel.DataAnnotations;

namespace NZWalks.DTOs.Image
{
    public class UploadImageDto
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
