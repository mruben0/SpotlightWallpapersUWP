using Core.Models;
using Newtonsoft.Json;
using SpotLightUWP.Services.Base;
using System;

namespace SpotLightUWP.Services
{
    public class ConfigsService : IConfigsService
    {
        private readonly IIOManager _iOManager;

        public ConfigsService(IIOManager iOManager)
        {
            _iOManager = iOManager ?? throw new ArgumentNullException(nameof(iOManager));
        }

        public Configs GetConfigs()
        {
            _iOManager.Initialize();
            var text = _iOManager.GetSavedConfigs();
            if (string.IsNullOrEmpty(text))
            {
                var configs = new Configs()
                {
                    AlertShown = 0,
                    LastNotificationDate = DateTime.MinValue,
                    LastPicChangeDate = DateTime.MinValue
                };
                SaveConfigs(configs);
                return configs;
            }
            else
            {
                var configs = JsonConvert.DeserializeObject<Configs>(text);
                return configs;
            }
        }

        public void SaveConfigs(Configs configs)
        {
            var text = JsonConvert.SerializeObject(configs);
            _iOManager.SaveConfigsToFile(text);
        }
    }
}
