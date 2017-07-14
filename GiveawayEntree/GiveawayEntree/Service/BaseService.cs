using GiveawayEntree.Repository;

namespace GiveawayEntree.Service
{
    public static class BaseService
    {
        public static TweetRepository TweetRepository = new TweetRepository();
    }
}
