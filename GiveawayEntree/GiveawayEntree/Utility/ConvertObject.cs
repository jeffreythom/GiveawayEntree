using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GiveawayEntree.Model;
using GiveawayEntree.Model.Twitter;

namespace GiveawayEntree.Utility
{
    public static class ConvertObject
    {
        public static IEnumerable<Tweet> GetTweetsFromTwitterObjects(IEnumerable<TwitterTweet> twitterTweets)
        {
            return twitterTweets.Select(tt => new Tweet()
            {
                Content = tt.Content,
                Created = Convert.ToDateTime(tt.CreatedAt),
                IsLiked = tt.IsFavourited,
                IsRepliedTo = tt.StatusRepliedTo != null,
                IsRetweeted = tt.IsRetweeted,
                Likes = tt.Favourites ?? 0,
                Retweets = tt.Retweets
            });
        } 
    }
}
