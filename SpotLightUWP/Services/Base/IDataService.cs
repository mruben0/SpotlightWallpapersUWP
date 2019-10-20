using SpotLightUWP.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Storage;

namespace SpotLightUWP.Services.Base
{
    public interface IDataService
    {
        StorageFolder AppdataFolder { get; }
        ObservableCollection<ImageDTO> Source { get; set; }
        int UpdateDate { get; set; }

        Task DownloadById(string ID);

        Task<bool> GetAllDataFromServerAsync(int page, bool IsTemplate = true);

        Task<ObservableCollection<ImageDTO>> GetGalleryDataAsync(int page, bool IsTemplate = true);

        Task InitializeAsync(int page, IOManagerParams @params);

        List<ImageDTO> ImageDTOList { get; set; }
    }
}
