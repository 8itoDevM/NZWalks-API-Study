using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase {
        // POST: /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request) {
            ValidadeFileUpload(request);

            if(ModelState.IsValid) {
                // user repository to upload image

            }

            return BadRequest(ModelState);
        }

        private void ValidadeFileUpload(ImageUploadRequestDto request) {
            var allowedExtensions = new string[] { " .jpg ", ".png", "jpeg" };

            if(!allowedExtensions.Contains(Path.GetExtension(request.File.FileName))) {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if(request.File.Length > 10485760) { // 10MB maximum
                ModelState.AddModelError("file", "File size exceeds 10MB");
            }
        }
    }
}
