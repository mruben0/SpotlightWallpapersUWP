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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;

namespace SpotLightUWP.Services
{
    public class HTTPService
    {
        private ViewModels.ViewModelLocator Locator => Application.Current.Resources["Locator"] as ViewModels.ViewModelLocator;
        private IOManager IOManager => Locator.IOManager;

        public async Task<List<ImageDTO>> GetPhotosByPageAsync(int page)
        {
            var ImageDtos = new List<ImageDTO>();

            var albumClient = new RestClient("https://api.flickr.com/services/rest/?method=flickr.photosets.getPhotos");
            var request = new RestRequest();
            request.AddParameter("api_key", "key");
            request.AddParameter("photoset_id", "72157698748876834");
            request.AddParameter("user_id", "93113931%40N08", ParameterType.QueryStringWithoutEncode);
            request.AddParameter("format", "json");
            request.AddParameter("page", page);
            request.AddParameter("per_page", 14);
            request.AddParameter("nojsoncallback", 1);

            var albumQueryResult = await ExecuteAsync(albumClient, request);
            var content = albumQueryResult.Content;
            if (albumQueryResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var photoClient = new RestClient("https://api.flickr.com/services/rest/?method=flickr.photos.getSizes");

                JObject obj = JObject.Parse(albumQueryResult.Content);
                var images = obj["photoset"]["photo"].ToList();
                var pRequest = new RestRequest();
                pRequest.AddParameter("nojsoncallback", 1);
                pRequest.AddParameter("format", "json");

                pRequest.AddParameter("api_key", "key");

                foreach (var image in images)
                {
                    var flickrImage = JsonConvert.DeserializeObject<FlickrImage>(image.ToString());
                    pRequest.AddParameter("photo_id", flickrImage.Id);
                    var photoQueryResult = await ExecuteAsync(photoClient, pRequest);
                    var photoContent = photoQueryResult.Content;
                    JObject pObj = JObject.Parse(photoContent);
                    var sizes = pObj["sizes"]["size"].ToList();
                    var tumbnailSize = sizes.FirstOrDefault(j => j["label"].ToString() == "Small")["source"].ToString();
                    var originalSize = sizes.FirstOrDefault(j => j["label"].ToString() == "Original")["source"].ToString();
                    var newImageDTO = new ImageDTO() { Name = flickrImage.Title, Id = flickrImage.Id, TemplateUri = tumbnailSize, URI = originalSize };
                    ImageDtos.Add(newImageDTO);
                }
            }
            return ImageDtos;
        }

        public async Task<string> DownloadByIdAsync(string Id, string name, string filePath = null)
        {
            var photoClient = new RestClient("https://api.flickr.com/services/rest/?method=flickr.photos.getSizes");
            var pRequest = new RestRequest();

            pRequest.AddParameter("nojsoncallback", 1);
            pRequest.AddParameter("format", "json");
            pRequest.AddParameter("photo_id", Id);
            pRequest.AddParameter("api_key", "key");

            var photoQueryResult = await ExecuteAsync(photoClient, pRequest);

            if (photoQueryResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                JObject image = JObject.Parse(photoQueryResult.Content);
                var sizes = image["sizes"]["size"].ToList();
                var originalSizeUri = sizes.FirstOrDefault(j => j["label"].ToString() == "Original")["source"].ToString();

                using (WebClient client = new WebClient())
                {
                    var _filePath = filePath ?? IOManager.ResultPathGenerator(originalSizeUri, IOManager.DownloadPath, name);
                    if (!File.Exists(_filePath))
                    {
                        await client.DownloadFileTaskAsync(new Uri(originalSizeUri), _filePath);
                    }
                    return _filePath;
                }
            }
            return null;
        }

        public async Task<string> DownLoadAsync(Uri uri, string downloadPath)
        {
            var name = Path.GetFileNameWithoutExtension(uri.ToString()).Replace('?', '_');
            string illegal = "\"M\"\\a/ry/ h**ad:>> a\\/:*?\"| li*tt|le|| la\"mb.?";
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            name = r.Replace(illegal, "");
            using (WebClient client = new WebClient())
            {
                var filePath = IOManager.ResultPathGenerator(uri.ToString(), downloadPath, name);
                filePath = filePath.Replace("?", "");
                if (!File.Exists(filePath))
                {
                    try
                    {
                        await client.DownloadFileTaskAsync(uri, filePath);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                return filePath;
            }
        }

        public int GetCount()
        {
            var countClient = new RestClient("https://api.flickr.com/services/rest/?method=flickr.photosets.getInfo");
            var countRequest = new RestRequest();
            countRequest.AddParameter("api_key", "key");
            countRequest.AddParameter("photoset_id", "72157698748876834");
            countRequest.AddParameter("user_id", "93113931%40N08", ParameterType.QueryStringWithoutEncode);
            countRequest.AddParameter("format", "json");
            countRequest.AddParameter("nojsoncallback", 1);

            IRestResponse countResult = countClient.Execute(countRequest);
            if (countResult.StatusCode == HttpStatusCode.OK)
            {
                JObject obj = JObject.Parse(countResult.Content);
                var countToken = obj["photoset"]["count_photos"].ToString();
                return Convert.ToInt32(countToken);
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
