using System;
using System.Threading.Tasks;

using Microsoft.Toolkit.Uwp.Helpers;

using SpotLightUWP.Views;

namespace SpotLightUWP.Services
{
    public static class FirstRunDisplayService
    {
        private static bool shown = false;

        internal static async Task ShowIfAppropriateAsync()
        {
            if (SystemInformation.IsFirstRun && !shown)
            {
                shown = true;
                var dialog = new FirstRunDialog();
                await dialog.ShowAsync();
            }
        }
    }
}
