using System.Data.Entity;
using GiveawayEntree.Context;

namespace GiveawayEntree.Repository
{
    public class BaseRepository
    {
        protected GiveawayContext Context;

        protected BaseRepository()
        {
            Context = new GiveawayContext();
        }
    }
}
