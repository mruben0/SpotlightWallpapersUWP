using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SpotLightUWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace SpotLightUWP.Services
{
    public class HTTPService
    {
        private ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;
        private IOManager IOManager => Locator.IOManager;

        RestClient _client = new RestClient("http://spotlight.gear.host/");       

        public async Task<List<ImageDTO>> URLParserAsync(int[] interval)
        {
            int count = 0;
            var countRequest = new RestRequest("Images/GetCount", Method.GET);
            List<ImageDTO> ImageDtos = new List<ImageDTO>();

            var countRes = await ExecuteAsync(_client,countRequest);

            if (countRes.StatusCode == HttpStatusCode.OK)
            {
                count = Convert.ToInt32(countRes.Content);
                for (int i = interval[0]; i <= interval[0] + 12; i++)
                {
                    var request = new RestRequest("Images/GetById/{Id}", Method.GET);
                    request.AddParameter("Id", i, ParameterType.UrlSegment);

                    var queryResult = await ExecuteAsync(_client,request);

                    if (queryResult.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        JObject image = JObject.Parse(queryResult.Content);
                        ImageDtos.Add(JsonConvert.DeserializeObject<ImageDTO>(image.ToString()));
                    }
                }
            }
            return ImageDtos;
        }

        public async Task<string> DownloadByIdAsync(string Id)
        {
            var request = new RestRequest($"Images/GetById/{Id}", Method.GET);
            var queryResult = _client.Execute(request);
            if (queryResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject image = JObject.Parse(queryResult.Content);
                ImageDTO imageDTO = JsonConvert.DeserializeObject<ImageDTO>(image.ToString());

                using (WebClient client = new WebClient())
                {
                    var filePath = IOManager.ResultPathGenerator(imageDTO.URI, IOManager.DownloadPath, Id, imageDTO.Name);
                    if (!File.Exists(filePath))
                    {
                        await client.DownloadFileTaskAsync(new Uri(imageDTO.URI), filePath);
                    }
                    return filePath;
                }
            }
            return null;
        }

        public async Task<string> DownLoadAsync(Uri uri,string downloadPath)
        {
            var name = Path.GetFileNameWithoutExtension(uri.ToString());            
            using (WebClient client = new WebClient())
            {
                var filePath = IOManager.ResultPathGenerator(uri.ToString(), downloadPath, name);
                if (!File.Exists(filePath))
                {
                    await client.DownloadFileTaskAsync(uri, filePath);
                }
                return filePath;
            }         
        }

        public int GetCount()
        {
            var countRequest = new RestRequest("Images/GetCount", Method.GET);
            IRestResponse countResult = _client.Execute(countRequest);
            if (countResult.StatusCode == HttpStatusCode.OK)
            {
                return Convert.ToInt32(countResult.Content);
            }
            else return 0;
        }

        private async Task<IRestResponse> ExecuteAsync(RestClient client, RestRequest request)
        {
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return response;
        }
    }
}
