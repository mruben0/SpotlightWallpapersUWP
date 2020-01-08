using System;

namespace Core.Models
{
    public class Configs
    {
        public int AlertShown { get; set; }
        public string LastNotifiedImageUri { get; set; }
        public string LastChangedImageUri { get; set; }
        public DateTimeOffset LastBackgroundJobDate { get; set; }
    }
}