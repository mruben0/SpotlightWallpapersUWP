using GalaSoft.MvvmLight.Command;
using Microsoft.Toolkit.Uwp.Notifications;
using SpotLightUWP.ViewModels;
using System;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Popups;

namespace SpotLightUWP.Services
{
    public class DialogService : IDialogService
    {
       

        public async Task ShowAlertAsync(string title, string message = "")
        {
            var dialog = new Windows.UI.Popups.MessageDialog(message, title);

            await dialog.ShowAsync();
        }

        public async Task ShowDailyWallpaperAlertAsync(string title, string message = "")
        {
            var navigationService = CommonServiceLocator.ServiceLocator.Current.GetInstance<NavigationServiceEx>();
            var dialog = new Windows.UI.Popups.MessageDialog(message, title);
            var settingscommand = new UICommandInvokedHandler((command) =>
            {
                navigationService.Navigate(typeof(SettingsViewModel).FullName, null);

            });
            dialog.Commands.Add(new UICommand("Go", settingscommand));
            dialog.Commands.Add(new UICommand("Close", null));
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
