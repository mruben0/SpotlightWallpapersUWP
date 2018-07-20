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

        RestClient client = new RestClient("http://spotlight.gear.host/");

        public List<ImageDTO> URLParser(int[] interval)
        {
            int count = 0;
            var countRequest = new RestRequest("Images/GetCount", Method.GET);
            IRestResponse countResult = client.Execute(countRequest);
            List<ImageDTO> ImageDtos = new List<ImageDTO>();

            if (countResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                count = Convert.ToInt32(countResult.Content);

                if (count > interval[1])
                {
                    count = interval[1];
                }

                for (int i = interval[0]; i <= count; i++)
                {
                    var request = new RestRequest("Images/GetById/{Id}", Method.GET);
                    request.AddParameter("Id", i, ParameterType.UrlSegment);

                    var queryResult = client.Execute(request);

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
            var queryResult = client.Execute(request);
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
    }
}
