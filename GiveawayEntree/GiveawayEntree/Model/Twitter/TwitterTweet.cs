using Newtonsoft.Json;

namespace GiveawayEntree.Model.Twitter
{
    public class TwitterTweet
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("current_user_retweet")]
        public UserObject CurrentUserRetweet { get; set; }

        [JsonProperty("favorite_count")]
        public int? Favourites { get; set; }

        [JsonProperty("favorited")]
        public bool IsFavourited { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("id_str")]
        public string IdString { get; set; }

        [JsonProperty("in_reply_to_status_id")]
        public long? StatusRepliedTo { get; set; }

        [JsonProperty("retweet_count")]
        public int Retweets { get; set; }

        [JsonProperty("retweeted")]
        public bool IsRetweeted { get; set; }

        [JsonProperty("status")]
        public string Content { get; set; }

        [JsonProperty("user")]
        public TwitterUser User { get; set; }
    }

    
    public class UserObject
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("id_str")]
        public string IdString { get; set; }
    }
}
