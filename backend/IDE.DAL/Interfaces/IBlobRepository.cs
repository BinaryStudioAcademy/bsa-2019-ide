using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IDE.DAL.Interfaces
{
    public interface IBlobRepository
    {
        Task<Uri> UploadAsync(IFormFile file, int projectId, int buildId);
        Task<IEnumerable<Uri>> ListAsync(int projectId);
        Task<MemoryStream> DownloadFileAsync(string fileUri);
        Task DeleteAsync(string fileUri);
    }
}
