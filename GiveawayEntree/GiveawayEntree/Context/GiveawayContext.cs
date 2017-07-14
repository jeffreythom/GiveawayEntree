using System.Data.Entity;
using GiveawayEntree.Model;

namespace GiveawayEntree.Context
{
    public class GiveawayContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
    }
}
