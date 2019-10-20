using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.ResponseModels
{
    public class Sizes
    {
        [JsonProperty("canblog")]
        public long Canblog { get; set; }

        [JsonProperty("canprint")]
        public long Canprint { get; set; }

        [JsonProperty("candownload")]
        public long Candownload { get; set; }

        [JsonProperty("size")]
        public List<Size> Size { get; set; }
    }
}