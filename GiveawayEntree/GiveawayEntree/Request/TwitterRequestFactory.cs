using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GiveawayEntree.Model.Twitter;
using GiveawayEntree.Request.Twitter;

namespace GiveawayEntree.Request
{
    public class TwitterRequestFactory : IRequestFactory<Tweet>
    {
        public static readonly string BaseUrl = "https://api.twitter.com/1.1";
        public static readonly string OauthConsumerKey = "DSSa1XYFKSaGgqVXPka8FDoYv";
        public static readonly string OauthSignatureMethod = "HMAC-SHA1";
        public static readonly string OauthToken = "263798552-FhBBUFkc4pooeoL8RB79cDjwZ5lqdKBa2r9l3GJF";
        public static readonly string OauthVersion = "1.0";
        public static readonly string ConsumerSecret = "TIKNQU10FViEmwRRyAkZBriYazIRs4MspQRWJZ3ro6KEyrmbRI";
        public static readonly string TokenSecret = "hUPLc1VJQOnyXvC32mqVB3FqdjUuCwlBdy6NaasYx5GDp";

        public async Task<IEnumerable<Tweet>> GetPosts()
        {
            var getPostRequest = new GetPosts();
            var result = await getPostRequest.MakeRequest();
            if (result)
            {
                return getPostRequest.GetResult();
            }
            //deal with issue
            Debugger.Log(1, "Debug", getPostRequest.GetErrorMessage());
            return null;
        }

        public bool LikePost(string postId)
        {
            throw new System.NotImplementedException();
        }

        public bool ReplyToPost(string postId, string content)
        {
            throw new System.NotImplementedException();
        }

        public bool SharePost(string postId)
        {
            throw new System.NotImplementedException();
        }
    }
}
