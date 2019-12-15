using Core.Base;
using Core.ResponseModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using SpotLightUWP.Core.Base;
using SpotLightUWP.Core.Helpers;
using SpotLightUWP.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpotLightUWP.Core.Services
{
    public class HTTPService : BaseHttpService, IHTTPService
    {
        private static IConfiguration _configuration;
        private readonly string _albumClientUri;
        private readonly string _photosetId;
        private readonly string _apiKey;
        private readonly string _userId;
        private readonly string _format;
        private readonly string _getSizedURI;
        private readonly string _getInfoUri;

        public HTTPService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.Json");
            _configuration = builder.Build();

            _albumClientUri = _configuration.GetSection("AlbumClientUri").Value;
            _photosetId = _configuration.GetSection("photoset_id").Value;
            _apiKey = _configuration.GetSection("api_key").Value;
            _userId = _configuration.GetSection("user_id").Value;
            _format = _configuration.GetSection("format").Value;
            _getSizedURI = _configuration.GetSection("GetSizedURI").Value;
            _getInfoUri = _configuration.GetSection("GetInfoUri").Value;
        }

        public async Task<List<ImageDTO>> GetPhotosByPageAsync(int page)
        {
            var ImageDtos = new List<ImageDTO>();

            var albumClient = new RestClient(_albumClientUri);
            var request = new RestRequest();
            request.AddParameter("api_key", _apiKey);
            request.AddParameter("photoset_id", _photosetId);
            request.AddParameter("user_id", _userId, ParameterType.QueryStringWithoutEncode);
            request.AddParameter("format", _format);
            request.AddParameter("page", page);
            request.AddParameter("per_page", 14);
            request.AddParameter("nojsoncallback", 1);

            var albumQueryResult = await ExecuteAsync(albumClient, request);
            if (albumQueryResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var album = JsonConvert.DeserializeObject<AlbumResponse>(albumQueryResult.Content);
                var photoClient = new RestClient(_getSizedURI);

                var images = album.Photoset.Photo;

                var photoRequest = new RestRequest();
                photoRequest.AddParameter("nojsoncallback", 1);
                photoRequest.AddParameter("format", _format);
                photoRequest.AddParameter("api_key", _apiKey);

                foreach (var image in images)
                {
                    photoRequest.AddParameter("photo_id",image.Id);
                    var photoQueryResult = await ExecuteAsync(photoClient, photoRequest);

                    var photoResponse = JsonConvert.DeserializeObject<PhotoSizesResponse>(photoQueryResult.Content);
                    var tumbnailSize = photoResponse.Sizes.Size.FirstOrDefault(s => s.Label == "Small").Source.ToString();
                    var originalSize = photoResponse.Sizes.Size.FirstOrDefault(s => s.Label == "Original").Source.ToString();
                    var newImageDTO = new ImageDTO() { Name = image.ToString(), Id = image.Id, TemplateUri = tumbnailSize, URI = originalSize };
                    ImageDtos.Add(newImageDTO);
                }
            }
            return ImageDtos;
        }

        public async Task<string> DownloadByIdAsync(string Id, string name, string filePath, string downloadPath)
        {
            var photoClient = new RestClient(_getSizedURI);
            var pRequest = new RestRequest();

            pRequest.AddParameter("nojsoncallback", 1);
            pRequest.AddParameter("format", _format);
            pRequest.AddParameter("photo_id", Id);
            pRequest.AddParameter("api_key", _apiKey);

            var photoQueryResult = await ExecuteAsync(photoClient, pRequest);

            if (photoQueryResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var photoResponse = JsonConvert.DeserializeObject<PhotoSizesResponse>(photoQueryResult.Content);
                var originalSizeUri = photoResponse.Sizes.Size.FirstOrDefault(s => s.Label == "Original").Source.ToString();

                using (WebClient client = new WebClient())
                {
                    if (string.IsNullOrEmpty(filePath))
                    {
                        filePath = ImageNameManager.ResultPathGenerator(originalSizeUri, downloadPath, name);
                    }
                    if (!File.Exists(filePath))
                    {
                        await client.DownloadFileTaskAsync(new Uri(originalSizeUri), filePath);
                    }
                    return filePath;
                }
            }
            return null;
        }

        public async Task<string> DownLoadAsync(Uri uri, string downloadPath)
        {
            var name = Path.GetFileNameWithoutExtension(uri.ToString()).Replace('?', '_');
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            name = r.Replace(name, "");
            name = name.Replace(',', ' ');
            downloadPath = Path.Combine(downloadPath,name);
            using (WebClient client = new WebClient())
            {
                downloadPath = downloadPath.Replace("?", "");
                
                if (!File.Exists(downloadPath))
                {
                    try
                    {
                        await client.DownloadFileTaskAsync(uri, downloadPath);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                return downloadPath;
            }
        }

        public int GetCount()
        {
            var countClient = new RestClient(_getInfoUri);
            var countRequest = new RestRequest();
            countRequest.AddParameter("api_key", _apiKey);
            countRequest.AddParameter("photoset_id", _photosetId);
            countRequest.AddParameter("user_id", _userId, ParameterType.QueryStringWithoutEncode);
            countRequest.AddParameter("format", _format);
            countRequest.AddParameter("nojsoncallback", 1);

            IRestResponse countResult = countClient.Execute(countRequest);
            if (countResult.StatusCode == HttpStatusCode.OK)
            {
                var photosetInfo = JsonConvert.DeserializeObject<PhotosetInfoResponse>(countResult.Content);
                return photosetInfo.Photoset.CountPhotos;
            }
            else return 0;
        }       
    }
}