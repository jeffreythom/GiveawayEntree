namespace GiveawayEntree.Model
{
    public class Tweet : Post
    {
        public int Favourites { get; set; }
        public int Retweets { get; set; }
        public bool IsFavourited { get; set; }
        public bool IsRetweeted { get; set; }
        public bool IsRepliedTo { get; set; }
    }
}
