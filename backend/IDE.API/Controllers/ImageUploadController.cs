using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Image;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    // [Authorize] // TODO: use after authorization launch
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IImageUploader _imageUploadService;
        private readonly ILogger<ImageUploadController> _logger;
        public ImageUploadController(IImageUploader imageUploadService, ILogger<ImageUploadController> logger)
        {
            _imageUploadService = imageUploadService;
            _logger = logger;
        }

        [HttpPost("base64")]
        public async Task<IActionResult> UploadBase64Async([FromBody] ImageUploadBase64DTO imageBase64Dto)
        {
            var imgSrc = await _imageUploadService.UploadAsync(imageBase64Dto.Base64);
            var uploadedImageDto = new ImageDTO {Url = imgSrc};

            return Created(uploadedImageDto.Url, uploadedImageDto);
        }

        [HttpPost("fromUrl")]
        public async Task<IActionResult> UploadFromUrlAsync([FromBody] ImageUploadFromUrlDTO imageFromUrl)
        {
            var imgSrc = await _imageUploadService.UploadAsync(imageFromUrl.Url);
            var uploadedImageDto = new ImageDTO {Url = imgSrc};

            return Created(uploadedImageDto.Url, uploadedImageDto);
        }

        [HttpPost("byteArray")]
        public async Task<IActionResult> UploadByteArrayAsync([FromBody] ImageUploadByteArrayDTO imageByteArray)
        {
            var imgSrc = await _imageUploadService.UploadAsync(imageByteArray.ByteArray);
            var uploadedImageDto = new ImageDTO {Url = imgSrc};

            return Created(uploadedImageDto.Url, uploadedImageDto);
        }
    }
}