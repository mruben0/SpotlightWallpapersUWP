using SpotLightUWP.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotLightUWP.Services.Base
{
    public interface IIOManager
    {
        string DownloadPath { get; set; }
        string TemplatePath { get; set; }

        Task DownloadImage(string Url, string id = null, string name = null, string Path = null);

        Task DownloadImages(List<ImageDTO> imageDTOs, int page, bool AsTemplate = true);

        void EraseDownloaded();

        void Initialize(IOManagerParams @params = IOManagerParams.SpotLight);

        Task SaveImageAs(string imageUri);

        string GetSavedDTOS();

        void SaveToFile(string content);
    }
}
