using System;
using System.Collections.Generic;
using System.Text;

namespace IDE.BLL.Interfaces
{
    interface IImageUploader
    {
        string UploadFromBase64(string base64);
        string UploadFromByteArray(byte[] byteArray);
        string UploadFromUrl(string url);
    }
}
