namespace GiveawayEntree.Model.Twitter
{
    public class Tweet : Post
    {
        public int Likes { get; set; }
        public int Retweets { get; set; }
        public bool IsLiked { get; set; }
        public bool IsRetweeted { get; set; }
        public bool IsRepliedTo { get; set; }
    }
}
