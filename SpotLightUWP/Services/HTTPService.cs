using Newtonsoft.Json;
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
   public class HTTPService
    {

        private RestClient client = new RestClient("http://spotlight.gear.host/");
        
        public List<ImageDTO> URLParser()
        {
            List<ImageDTO> ImageDtos = new List<ImageDTO >();

            var request = new RestRequest("imageuri", Method.GET);

            var queryResult = client.Execute(request);

            JObject o = JObject.Parse(queryResult.Content);
            JArray images = (JArray)o.SelectToken("Images");

            foreach (var item in images)
            {
                ImageDtos.Add(JsonConvert.DeserializeObject<ImageDTO>(item.ToString()));
            }
            return ImageDtos;
        }

        public int UpdatedDate()
        {
            var request = new RestRequest("imageuri", Method.GET);

            var queryResult = client.Execute(request);

            JObject o = JObject.Parse(queryResult.Content);

            return  (int)o.SelectToken("Meta.Date");
        }

    }
}
