using System;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace SpotLightUWP.Services
{
    public class DialogService : IDialogService
    {
        public async Task ShowAlertAsync(string title, string message = "")
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message, title);

            await dialog.ShowAsync();
        }

        public void ShowNotification(string title, string message)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList textElements = toastXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toastXml.CreateTextNode(title));
            textElements[1].AppendChild(toastXml.CreateTextNode(message));
            var notif = new ToastNotification(toastXml);
            notif.ExpirationTime = DateTime.Now.AddSeconds(5);
            ToastNotificationManager.CreateToastNotifier().Show(notif);
        }
    }
}
