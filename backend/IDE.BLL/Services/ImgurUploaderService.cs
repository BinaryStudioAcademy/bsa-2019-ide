using IDE.BLL.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class ImgurUploaderService : IImageUploader
    {
        private readonly HttpClient _client;

        public ImgurUploaderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> UploadFromBase64Async(string imageBase64)
        {
            return await UploadImageAsync(imageBase64);         
        }

        public async Task<string> UploadFromUrlAsync(string url)
        {
            return await UploadImageAsync(url);
        }

        public async Task<string> UploadFromByteArrayAsync(byte[] byteArray)
        {
            return await UploadImageAsync(byteArray);
        }

        private async Task<string> UploadImageAsync<T>(T source)
        {
            var content = new { image = source };
            string json = JsonConvert.SerializeObject(content);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"image", body);

            if (response == null)
                throw new Exception("Not response from Imgur"); // TODO: realize custom Exceptions and its handling
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception("Response status from Imgur is NOT FOUND"); // TODO: realize custom Exceptions and its handling
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Bad response from Imgur"); // TODO: realize custom Exceptions and its handling

            var responseSring = await response.Content.ReadAsStringAsync();
            JObject responseJson = JObject.Parse(responseSring);
            var uploadedImageUrl = (string)responseJson["data"]["link"];

            return uploadedImageUrl;
        }

    }
}
