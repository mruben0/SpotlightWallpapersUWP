using Core.Base;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using SpotLightUWP.Core.Base;
using SpotLightUWP.Core.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SpotLightUWP.Core.Services
{
    public class BingHTTPService : BaseHttpService, IBingHTTPService
    {
        private static IConfiguration _configuration;
        private RestClient _client;

        public BingHTTPService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.Json");
            _configuration = builder.Build();
            _client = new RestClient(_configuration.GetSection("BingUri").Value);
        }

        public async Task<List<ImageDTO>> GetImages()
        {
            return await URLParserAsync();
        }

        public async Task<ImageDTO> GetLastImage()
        {
            var images = await URLParserAsync();
            return images.First();
        }

        public async Task<List<ImageDTO>> URLParserAsync()
        {
            var imageDTOs = new List<ImageDTO>();
            List<string> ImageUrls = new List<string>();
            var request = new RestRequest("HPImageArchive.aspx?format=js&idx={idx}&n=100", Method.GET);

            request.AddParameter("idx", 1, ParameterType.UrlSegment);

            var queryResult = await ExecuteAsync(_client, request);
            if (queryResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var bingImageModel = JsonConvert.DeserializeObject<BingImageModel>(queryResult.Content);

                foreach (var image in bingImageModel.images)
                {
                    var url = image.url;
                    var bingUrl = "https://www.bing.com" + url;
                    var name = System.IO.Path.GetFileNameWithoutExtension(url);

                    if (!ImageUrls.Contains(bingUrl))
                    {
                        ImageUrls.Add($@"{bingUrl}");
                    }
                    var newImageDto = new ImageDTO() { Id = (imageDTOs.Count() - 1).ToString(), Name = name, URI = bingUrl, Info = image.copyright };
                    imageDTOs.Add(newImageDto);
                }
            }
            return imageDTOs;
        }
    }
}