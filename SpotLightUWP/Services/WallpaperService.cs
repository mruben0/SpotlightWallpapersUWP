using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.System.UserProfile;


namespace SpotLightUWP.Services
{
    public class WallpaperService
    {
        public async Task PickAndSetWallpaper()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {               
                await SetAsAsync(image:file);
            }
        }

        public async Task<bool> SetAsAsync(Uri Uri = null,StorageFile image = null , SetAs setAs = SetAs.Wallpaper)
        {
            bool success = false;
            StorageFile file;
            if (UserProfilePersonalizationSettings.IsSupported())
            {
                file = image ??  await StorageFile.GetFileFromApplicationUriAsync(Uri) ?? throw new ArgumentNullException(nameof(image));
                var appdata = ApplicationData.Current.LocalFolder;
                var copiedFile = await image.CopyAsync(appdata,image.Name,NameCollisionOption.ReplaceExisting);
                UserProfilePersonalizationSettings profileSettings = UserProfilePersonalizationSettings.Current;
                if (setAs == SetAs.Wallpaper)
                {
                    success = await profileSettings.TrySetWallpaperImageAsync(copiedFile);
                }
                else
                {
                    success = await profileSettings.TrySetLockScreenImageAsync(copiedFile);
                }
            }
            return success;
        }
    }

    public enum SetAs
    {
        Wallpaper,
        Lockscreen
    }
}
