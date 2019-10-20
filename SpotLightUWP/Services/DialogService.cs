using System;
using System.Threading.Tasks;

namespace SpotLightUWP.Services
{
    public class DialogService : IDialogService
    {
        public async Task ShowAlertAsync(string message)
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message);
            await dialog.ShowAsync();
        }
    }
}
