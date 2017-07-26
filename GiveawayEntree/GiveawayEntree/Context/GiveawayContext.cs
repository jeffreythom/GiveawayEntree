using System.Data.Entity;
using GiveawayEntree.Model;
using GiveawayEntree.Model.Twitter;

namespace GiveawayEntree.Context
{
    public class GiveawayContext : DbContext
    {
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
