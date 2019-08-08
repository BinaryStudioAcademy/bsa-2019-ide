using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using IDE.Common.DTO.Image;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    // [Authorize] // TODO: use after authorization launch
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
            var uploadedImageDto = new ImageDTO();
            uploadedImageDto.Url = await _imageUploadService.UploadFromBase64Async(imageBase64Dto.Base64);
            return Created(uploadedImageDto.Url, uploadedImageDto);
        }

        [HttpPost("fromUrl")]
        public async Task<IActionResult> UploadFromUrlAsync([FromBody] ImageUploadFromUrlDTO imageFromUrl)
        {
            var uploadedImageDto = new ImageDTO();
            uploadedImageDto.Url = await _imageUploadService.UploadFromUrlAsync(imageFromUrl.Url);
            return Created(uploadedImageDto.Url, uploadedImageDto);
        }

        [HttpPost("byteArray")]
        public async Task<IActionResult> UploadByteArrayAsync([FromBody] ImageUploadByteArrayDTO imageByteArray)
        {
            var uploadedImageDto = new ImageDTO();
            uploadedImageDto.Url = await _imageUploadService.UploadFromByteArrayAsync(imageByteArray.ByteArray);
            return Created(uploadedImageDto.Url, uploadedImageDto);
        }
    }
}