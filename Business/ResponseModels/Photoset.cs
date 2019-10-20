using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.ResponseModels
{
    public class Photoset
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("primary")]
        public string Primary { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        [JsonProperty("server")]
        public long Server { get; set; }

        [JsonProperty("farm")]
        public long Farm { get; set; }

        [JsonProperty("count_views")]
        public long CountViews { get; set; }

        [JsonProperty("count_comments")]
        public long CountComments { get; set; }

        [JsonProperty("count_photos")]
        public int CountPhotos { get; set; }

        [JsonProperty("count_videos")]
        public long CountVideos { get; set; }

        [JsonProperty("can_comment")]
        public long CanComment { get; set; }

        [JsonProperty("date_create")]
        public long DateCreate { get; set; }

        [JsonProperty("date_update")]
        public long DateUpdate { get; set; }

        [JsonProperty("photos")]
        public long Photos { get; set; }

        [JsonProperty("visibility_can_see_set")]
        public long VisibilityCanSeeSet { get; set; }

        [JsonProperty("needs_interstitial")]
        public long NeedsInterstitial { get; set; }

        public string Ownername { get; set; }
        public List<Photo> Photo { get; set; }
        public int Page { get; set; }
        public string Per_page { get; set; }
        public string Perpage { get; set; }
        public int Pages { get; set; }
        public string Total { get; set; }
    }
}