using System.Collections.Generic;
using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Image;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    // [Authorize] // use in prod
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IImageUploader _imageUploadService;

        public ImageUploadController(IImageUploader imageUploadService)
        {
            _imageUploadService = imageUploadService;
        }

        [HttpPost("base64")]
        public async Task<IActionResult> UploadBase64Async([FromBody] ImageUploadBase64DTO imageBase64Dto)
        {
            var uploadedimageDto = new ImageDTO();
            uploadedimageDto.Url = await _imageUploadService.UploadFromBase64Async(imageBase64Dto.Base64);
            return Created(uploadedimageDto.Url, uploadedimageDto);
        }
    }
}