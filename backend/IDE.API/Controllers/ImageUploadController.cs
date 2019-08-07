using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDE.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDE.API.Controllers
{
    [Route("[controller]")]
    // [Authorize]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        private readonly IImageUploader _imageUploadService;

        public ImageUploadController(IImageUploader imageUploadService)
        {
            _imageUploadService = imageUploadService;
        }

        [HttpGet("base64")]
        public ActionResult<IEnumerable<string>> GetBase64()
        {
            return new string[] { "GetBase64", "works" };
        }

        [HttpPost("base64")]
        public async Task<IActionResult> UploadBase64Async(string imageBase64, string imageTitle)
        {
            var result = await _imageUploadService.UploadFromBase64Async(imageBase64, imageTitle);
            return Created(result, null);
        }


    }
}