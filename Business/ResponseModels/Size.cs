using Newtonsoft.Json;
using System;

namespace Core.ResponseModels
{
    public class Size
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("source")]
        public Uri Source { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("media")]
        public Media Media { get; set; }
    }
}