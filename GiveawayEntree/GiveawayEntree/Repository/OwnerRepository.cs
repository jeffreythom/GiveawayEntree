using System;
using System.Data.Entity;
using System.Linq;
using GiveawayEntree.Model;

namespace GiveawayEntree.Repository
{
    public class OwnerRepository : BaseRepository
    {
        public Owner GetSingle(Guid id)
        {
            Context.Owners.Load();
            return Context.Owners.First(ow => ow.Id == id);
        }

        public Owner GetSingleFromTwitterUserId(string userId)
        {
            Context.Owners.Load();
            return Context.Owners.First(ow => ow.OriginId == userId);
        }

        public Guid GetOwnerIdFromTwitterUserId(string userId)
        {
            Context.Owners.Load();
            var owner = Context.Owners.First(ow => ow.OriginId == userId);
            return owner?.Id ?? Guid.Empty;
        }

        public Owner CreateOwner(Owner owner)
        {
            Context.Owners.Load();
            Context.Owners.Add(owner);
            Context.SaveChanges();
            return GetSingle(owner.Id);
        }
    }
}
