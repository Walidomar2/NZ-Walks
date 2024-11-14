using NZWalks.Data;
using NZWalks.Interfaces;
using NZWalks.Models;

namespace NZWalks.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ImageRepository(ApplicationDbContext context, 
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Image> Upload(Image image)
        {
            // making the local file path in the Images folder + image name + image extension
            var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",$"{image.FileName}{image.FileExtension}");

            // open file stream object to upload the image to the location

            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // creating a variable that contain the image URL path

            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;   

            // saving changes to the database
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();

            return image;   
        }
    }
}
