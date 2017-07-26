using GiveawayEntree.Repository;

namespace GiveawayEntree.Application
{
    public static class BaseApplication
    {
        public static TweetRepository TweetRepository = new TweetRepository();
        public static OwnerRepository OwnerRepository = new OwnerRepository();
    }
}
