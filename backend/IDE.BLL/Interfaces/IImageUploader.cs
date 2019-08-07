using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IImageUploader
    {
        Task<string> UploadFromBase64Async(string imageBase64);
        Task<string> UploadFromByteArrayAsync(byte[] byteArray);
        Task<string> UploadFromUrlAsync(string url);
    }
}
