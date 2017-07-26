using System;
using System.Collections.Generic;
using GiveawayEntree.Application;
using GiveawayEntree.Enum;
using GiveawayEntree.Model;
using GiveawayEntree.Model.Twitter;

namespace GiveawayEntree.Utility
{
    public static class ConvertObject
    {
        public static IEnumerable<Tweet> GetTweetsFromTwitterObjects(IEnumerable<TwitterTweet> twitterTweets)
        {
            var tweets = new List<Tweet>();
            foreach (var tt in twitterTweets)
            {
                var tweet = BaseApplication.TweetRepository.GetSingleTweetFromTwitterTweetId(tt.IdString);
                if (tweet == null)
                {
                    tweet = BaseApplication.TweetRepository.CreateTweet(new Tweet()
                    {
                        Id = Guid.NewGuid(),
                        OriginId = tt.IdString,
                        Content = tt.Content,
                        Created = Convert.ToDateTime(tt.CreatedAt),
                        IsLiked = tt.IsFavourited,
                        IsRepliedTo = tt.StatusRepliedTo != null,
                        IsRetweeted = tt.IsRetweeted,
                        Likes = tt.Favourites ?? 0,
                        Retweets = tt.Retweets,
                        Owner = GetOwnerFromTwitterUser(tt.User),
                        OwnerId = BaseApplication.OwnerRepository.GetOwnerIdFromTwitterUserId(tt.User.IdString)
                    });

                }
                tweets.Add(tweet);
            }
            return tweets;
        }

        public static Owner GetOwnerFromTwitterUser(TwitterUser user)
        {
            var owner = BaseApplication.OwnerRepository.GetSingleFromTwitterUserId(user.IdString);
            if (owner == null)
            {
                owner = BaseApplication.OwnerRepository.CreateOwner(new Owner()
                {
                    Id = Guid.NewGuid(),
                    IsFollowed = user.FollowRequestSent,
                    OriginId = user.IdString,
                    Type = TypeEnum.Twitter
                });
            }
            return owner;
        }
    }
}
