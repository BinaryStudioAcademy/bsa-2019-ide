using System.Threading.Tasks;

namespace IDE.BLL.Interfaces
{
    public interface IImageUploader
    {
        Task<string> UploadAsync(string imgSrc);
        Task<string> UploadAsync(byte[] byteArray);
    }
}
