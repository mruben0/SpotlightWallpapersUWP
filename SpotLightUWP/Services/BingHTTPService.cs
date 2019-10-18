using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SpotLightUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotLightUWP.Services
{
    public class BingHTTPService
    {
        public List<ImageDTO> imageDTOs;

        public RestClient client = new RestClient("https://www.bing.com/");

        public async Task<List<ImageDTO>> URLParserAsync()
        {
            imageDTOs = new List<ImageDTO>();
            List<string> ImageUrls = new List<string>();
            for (int i = 0; i < 15; i += 9)
            {
                var request = new RestRequest("HPImageArchive.aspx?format=js&idx={idx}&n=1000", Method.GET);

                request.AddParameter("idx", i, ParameterType.UrlSegment);

                var queryResult = await ExecuteAsync(request);
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
            }
            return imageDTOs;
        }

        private async Task<IRestResponse> ExecuteAsync(RestRequest request)
        {
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return response;
        }
    }
}
