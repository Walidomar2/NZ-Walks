using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.DTOs.Image;
using NZWalks.Interfaces;
using NZWalks.Models;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Upload([FromForm] UploadImageDto uploadImageModel)
        {
            ValidateFile(uploadImageModel);
            if (ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = uploadImageModel.File,
                    FileExtension = Path.GetExtension(uploadImageModel.File.FileName),
                    FileSizeInBytes = uploadImageModel.File.Length,
                    FileName = uploadImageModel.FileName,
                    FileDescription = uploadImageModel.FileDescription,
                };

                imageDomainModel = await _imageRepository.Upload(imageDomainModel);
                return Ok(imageDomainModel);    
            }

            return BadRequest(ModelState);
        }

        //Function To validate the sent image model
        private void ValidateFile(UploadImageDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            // validate the extension of the image
            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            // validate the size of the image must be less than 10MB
            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller size file.");
            }
        }
    }
}
