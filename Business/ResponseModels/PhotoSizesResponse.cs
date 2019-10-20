using Newtonsoft.Json;

namespace Core.ResponseModels
{
    public class PhotoSizesResponse
    {
        [JsonProperty("sizes")]
        public Sizes Sizes { get; set; }

        [JsonProperty("stat")]
        public string Stat { get; set; }
    }
}