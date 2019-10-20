using System.Threading.Tasks;

namespace SpotLightUWP.Services
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message);
    }
}
