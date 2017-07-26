using System;
using System.Data.Entity;
using System.Linq;
using GiveawayEntree.Model.Twitter;

namespace GiveawayEntree.Repository
{
    public class TweetRepository : BaseRepository
    {
        public Tweet GetSingle(Guid id)
        {
            Context.Tweets.Load();
            return Context.Tweets.First(tw => tw.Id == id);
        }

        public Tweet GetSingleTweetFromTwitterTweetId(string twitterId)
        {
            Context.Tweets.Load();
            return Context.Tweets.First(tw => tw.OriginId == twitterId);
        }

        public Tweet CreateTweet(Tweet tweet)
        {
            Context.Tweets.Load();
            Context.Tweets.Add(tweet);
            Context.SaveChanges();
            return GetSingle(tweet.Id);
        }
    }
}
