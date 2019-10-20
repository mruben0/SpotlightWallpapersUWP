using System.Threading.Tasks;
using Windows.Storage;

namespace SpotLightUWP.Services.Base
{
    public interface IWallpaperService
    {
        Task PickAndSetWallpaper();

        Task<bool> SetAsAsync(string Uri = null, StorageFile image = null, SetAs setAs = SetAs.Wallpaper);
    }
}
