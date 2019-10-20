using Newtonsoft.Json;

namespace Core.ResponseModels
{
    public partial class PhotosetInfoResponse
    {
        [JsonProperty("photoset")]
        public Photoset Photoset { get; set; }

        [JsonProperty("stat")]
        public string Stat { get; set; }
    }
}
