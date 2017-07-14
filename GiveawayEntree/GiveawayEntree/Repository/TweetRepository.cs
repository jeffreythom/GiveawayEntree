using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GiveawayEntree.Model;

namespace GiveawayEntree.Repository
{
    public class TweetRepository : BaseRepository
    {
        public Tweet GetSingle(Guid id)
        {
            Context.Tweets.Load();
            return Context.Tweets.First(tw => tw.Id == id);
        } 
    }
}
