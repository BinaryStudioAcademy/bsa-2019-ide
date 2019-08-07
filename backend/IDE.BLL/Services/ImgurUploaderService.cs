using IDE.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class ImgurUploaderService : IImageUploader
    {
        private readonly string _imgurClientId;
        private readonly string _imgurApiUrl;
        private readonly HttpClient _client = new HttpClient();

        public ImgurUploaderService(IConfiguration configuration)
        {
            _imgurClientId = configuration["BsaIdeImgurClientId"];
            _imgurApiUrl = configuration.GetSection("ImgurApiUrl").Value;
            _client.DefaultRequestHeaders.Add("Authorization", $"Client-ID {_imgurClientId}");
        }

        public async Task<string> UploadFromBase64Async(string imageBase64)
        {
            var body = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("image", imageBase64),
                new KeyValuePair<string, string>("type", "base64")
            });
                        
            var response = await _client.PostAsync($"{_imgurApiUrl}/image", body);

            if (response == null)
                throw new Exception("Not response from Imgur");
            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception("Response status from Imgur is NOT FOUND");
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Bad response from Imgur");

            var responseSring = await response.Content.ReadAsStringAsync();
            JObject responseJson = JObject.Parse(responseSring);
            var uploadedImageUrl = (string)responseJson["data"]["link"];

            return uploadedImageUrl;            
        }

        public async Task<string> UploadFromByteArrayAsync(byte[] byteArray)
        {
            return "";
        }

        public async Task<string> UploadFromUrlAsync(string url)
        {
            return "";
        }
    }
}
