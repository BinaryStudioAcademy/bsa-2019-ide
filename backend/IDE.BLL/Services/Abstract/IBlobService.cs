using IDE.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Services.Abstract
{
    public interface IBlobService
    {
        Task<Uri> UploadAsync(IFormFile file, int projectId, int buildId);
        Task<IEnumerable<Uri>> ListAsync(int projectId);
        Task<MemoryStream> DownloadFileAsync(string fileUri);
        Task DeleteAsync(string fileUri);
    }
}
