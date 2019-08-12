using IDE.DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace IDE.API.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ArchivesBlobController : ControllerBase
    {
        private readonly IBlobRepository _blobService;

        public ArchivesBlobController(IBlobRepository blobService)
        {
            _blobService = blobService;
        }

        [HttpPost]
        public async Task<ActionResult> UploadAsync(IFormFile file, int projectId, int buildId)
        {
            try
            {
                var request = await HttpContext.Request.ReadFormAsync();
                if (request.Files == null)
                {
                    return BadRequest("Could not upload files");
                }
                var files = request.Files;
                if (files.Count == 0)
                {
                    return BadRequest("Could not upload empty files");
                }
                return Ok(await _blobService.UploadAsync(files[0], 141, 2324));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult> ListAsync(int projectId)
        {
            try
            {
                var allBlobs = await _blobService.ListAsync(projectId);
                return Ok(allBlobs);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }

        [HttpGet("download/{fileUri}")]
        public async Task<ActionResult> DownloadFileAsync(string fileUri)
        {
            try
            {
                var stream = await _blobService.DownloadFileAsync(fileUri);
                return Ok(stream);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(string fileUri)
        {
            try
            {
                await _blobService.DeleteAsync(fileUri);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error {ex.Message}");
            }
        }
    }
}
