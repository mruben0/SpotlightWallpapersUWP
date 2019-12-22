using System.Threading.Tasks;

namespace SpotLightUWP.Services
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string title, string message = "");

        void ShowNotification(string title, string message);

        void ShowNotification(string title, string message, string imagePath);
    }
}
