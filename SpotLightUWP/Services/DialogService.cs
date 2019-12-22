using Microsoft.Toolkit.Uwp.Notifications;
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
            ToastContent content = new ToastContent()
            {
                Launch = "app-defined-string",

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                              {
                                  new AdaptiveText()
                                  {
                                      Text = title,
                                      HintMaxLines = 1
                                  },

                                  new AdaptiveText()
                                  {
                                      Text =message
                                  }
                              }
                    }
                },
            };
            var notif = new ToastNotification(content.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(notif);
        }

        public void ShowNotification(string title, string message, string imagePath)
        {
            ToastContent content = new ToastContent()
            {
                Launch = "app-defined-string",

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                              {
                                  new AdaptiveText()
                                  {
                                      Text = title,
                                      HintMaxLines = 1
                                  },

                                  new AdaptiveText()
                                  {
                                      Text =message
                                  },
                                  new AdaptiveImage()
                                  {
                                      Source = imagePath
                                  }
                              }
                    }
                },
            };
            var notif = new ToastNotification(content.GetXml());
            notif.ExpirationTime = DateTimeOffset.Now.AddDays(1);
            ToastNotificationManager.CreateToastNotifier().Show(notif);
        }
    }
}
