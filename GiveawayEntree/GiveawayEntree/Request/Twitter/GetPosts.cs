using System.Net.Http;
using GiveawayEntree.Model.Twitter;

namespace GiveawayEntree.Request.Twitter
{
    public class GetPosts : TwitterRequest<TwitterTweet[]>
    {
        public GetPosts()
        {
            ExtensionUrl = "/search/tweets.json?lang=en&include_entities=false&q=competition%20OR%20giveaway";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }
    }
}
