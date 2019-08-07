using IDE.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IDE.BLL.Services
{
    public class ImgurUploaderService : IImageUploader
    {
        private readonly string _imgurClientId;
        private readonly string _imgurClientSecret;
        private readonly string _imgurApiUrl;
        // private readonly IConfiguration _configuration;
        private readonly HttpClient _client = new HttpClient();


        public ImgurUploaderService(IConfiguration configuration)
        {
            // _configuration = configuration;
            _imgurClientId = configuration["BsaIdeImgurClientId"];
            _imgurClientSecret = configuration["BsaIdeImgurClientSecret"];
            _imgurApiUrl = configuration.GetSection("ImgurApiUrl").Value;
        }

        public async Task<string> UploadFromBase64Async(string imageBase64, string imageTitle)
        {
            var body = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("image", imageBase64),
                new KeyValuePair<string, string>("title", imageTitle),
                new KeyValuePair<string, string>("type", "base64")
            });

            // headers??

            var imageUploadResult = await _client.PostAsync($"{_imgurApiUrl}/image", body);

            return "";
        }

        public async Task<string> UploadFromByteArrayAsync(byte[] byteArray)
        {
            return "";
        }

        public async Task<string> UploadFromUrlAsync(string url)
        {
            return "";
        }

        public string Upload(string imageAsBase64String)
        {
            string result = null;
            using (var webClient = new WebClient())
            {
                var values = new NameValueCollection
                {
                    { "key", _imgurClientId },
                    { "image", imageAsBase64String },
                    { "type", "base64" },
                };
                byte[] response = webClient.UploadValues("http://api.imgur.com/2/upload.xml", "POST", values);
            }
            return result;
        }
    }
}
