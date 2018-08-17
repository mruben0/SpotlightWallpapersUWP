using Newtonsoft.Json.Linq;
using RestSharp;
using SpotLightUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

                JObject o = JObject.Parse(queryResult.Content);
                JArray arr = (JArray)o.SelectToken("images");

                foreach (var item in arr)
                {
                    var url = item.Value<string>("url");
                    var bingUrl = "https://www.bing.com" + url;
                    var name = System.IO.Path.GetFileNameWithoutExtension(url);

                    if (!ImageUrls.Contains(bingUrl))
                    {
                        ImageUrls.Add($@"{bingUrl}");

                        var newImageDto = new ImageDTO() { Name = name, URI = bingUrl, Id = (imageDTOs.Count() - 1).ToString() };
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
