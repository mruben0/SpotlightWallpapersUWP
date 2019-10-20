using SpotLightUWP.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotLightUWP.Core.Base
{
    public interface IHTTPService
    {
        Task<string> DownLoadAsync(Uri uri, string downloadPath);
        Task<string> DownloadByIdAsync(string Id, string name, string filePath, string downloadPath);
        int GetCount();
        Task<List<ImageDTO>> GetPhotosByPageAsync(int page);
    }
}
