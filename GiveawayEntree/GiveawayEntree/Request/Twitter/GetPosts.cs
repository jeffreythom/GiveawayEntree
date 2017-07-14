using System.Net.Http;

namespace GiveawayEntree.Request.Twitter
{
    public class GetPosts : TwitterRequest
    {
        public GetPosts()
        {
            ExtensionUrl = "/search/tweets.json?lang=en&q=competition%20OR%20giveaway";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }
    }
}
