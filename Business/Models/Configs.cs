using Newtonsoft.Json;
using System;

namespace Core.Models
{
    public class Configs
    {
        public int AlertShown { get; set; }
        public DateTime LastNotificationDate { get; set; }

        public DateTime LastPicChangeDate { get; set; }

        [JsonIgnore]
        public bool IsNotifShowed => LastNotificationDate == DateTime.Today;

        [JsonIgnore]
        public bool IsPictureChanged => LastPicChangeDate == DateTime.Today;
    }
}