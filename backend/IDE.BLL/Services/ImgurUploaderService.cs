using IDE.BLL.Interfaces;
using IDE.Common.ModelsDTO.Enums;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ImgurUploaderService> _logger;
        public ImgurUploaderService(HttpClient client, ILogger<ImgurUploaderService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<string> UploadAsync(string imgSrc)
        {
            return await UploadImageAsync(imgSrc);
        }

        public async Task<string> UploadAsync(byte[] byteArray)
        {
            return await UploadImageAsync(byteArray);
        }

        private async Task<string> UploadImageAsync<T>(T source)
        {
            var url = source.ToString();
            var index = url.IndexOf(",") + 1;
            var content = new {image = url.Substring(index)};
            var json = JsonConvert.SerializeObject(content);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"image.json", body);

            if (response == null)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"Not response from Imgur");
                throw
                    new ApplicationException(
                        "Not response from Imgur"); // TODO: realize special custom Exceptions and its handling
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"Response status from Imgur is NOT FOUND");
                throw new ApplicationException(
                    "Response status from Imgur is NOT FOUND"); // TODO: realize special custom Exceptions and its handling
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogWarning(LoggingEvents.HaveException, $"Bad response from Imgur");
                throw
                    new ApplicationException(
                        "Bad response from Imgur"); // TODO: realize special custom Exceptions and its handling
            }

            var responseString = await response.Content.ReadAsStringAsync();
            var responseJson = JObject.Parse(responseString);
            var uploadedImageUrl = (string) responseJson["data"]["link"];

            return uploadedImageUrl;
        }


    }
}