using Newtonsoft.Json;

namespace GiveawayEntree.Model.Twitter
{
    public class TwitterUser
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("follow_request_sent")]
        public bool FollowRequestSent { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("id_str")]
        public string IdString { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }

        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }

        [JsonProperty("verified")]
        public bool IsVerified { get; set; }
    }
}
