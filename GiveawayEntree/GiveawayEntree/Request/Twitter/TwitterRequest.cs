using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace GiveawayEntree.Request.Twitter
{
    public abstract class TwitterRequest
    {
        protected List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();
        protected string ExtensionUrl;

        protected virtual HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
    }
        protected string GetAuthorisationHeader()
        {
            var oauthTimestamp = DateTime.Now.Subtract(DateTime.MinValue.AddYears(1969)).TotalMilliseconds;
            var oauthNonce = Guid.NewGuid().ToString().Replace("-", "");
            var oauthSignature = GetSignature(oauthNonce, oauthTimestamp.ToString());
            var authorisationHeader = new StringBuilder();
            authorisationHeader.Append($"OAuth oauth_consumer_key=\"{TwitterRequestFactory.OauthConsumerKey}\",");
            authorisationHeader.Append($"oauth_nonce=\"{oauthNonce}\",");
            authorisationHeader.Append($"oauth_signature=\"{oauthSignature}\",");
            authorisationHeader.Append($"oauth_signature_method=\"{TwitterRequestFactory.OauthSignatureMethod}\",");
            authorisationHeader.Append($"oauth_timestamp=\"{oauthTimestamp}\",");
            authorisationHeader.Append($"oauth_token=\"{TwitterRequestFactory.OauthToken}\",");
            authorisationHeader.Append($"oauth_version=\"{TwitterRequestFactory.OauthVersion}\"");
            return authorisationHeader.ToString();
        }

        private string GetSignature(string oAuthNonce, string oAuthTimestamp)
        {
            SetAndOrderParameters(oAuthNonce, oAuthTimestamp);
            var parameterString = "";
            foreach (var keyValuePair in Parameters)
            {
                if (parameterString != "")
                {
                    parameterString += "&";
                }
                parameterString += keyValuePair.Key;
                parameterString += "=";
                parameterString += keyValuePair.Value;
            }
            var signatureString = GetHttpMethod().Method.ToUpper() + "&";
            signatureString += Uri.EscapeDataString(TwitterRequestFactory.BaseUrl + ExtensionUrl) + "&";
            signatureString += Uri.EscapeDataString(parameterString);
            var signingKey = Uri.EscapeDataString(TwitterRequestFactory.ConsumerSecret) + "&";
            signingKey += Uri.EscapeDataString(TwitterRequestFactory.TokenSecret);

            var encoding = new ASCIIEncoding();
            var keyBytes = encoding.GetBytes(signingKey);
            var messageBytes = encoding.GetBytes(signatureString);
            string sha1Result;
            using (var sha1 = new HMACSHA1(keyBytes))
            {
                var hashed = sha1.ComputeHash(messageBytes);
                sha1Result = Convert.ToBase64String(hashed);
            }
            return sha1Result;
        }

        private void SetAndOrderParameters(string oAuthNonce, string oAuthTimestamp)
        {
            Parameters.Add(new KeyValuePair<string, string>(Uri.EscapeDataString("oauth_consumer_key"),
                Uri.EscapeDataString(TwitterRequestFactory.OauthConsumerKey)));
            Parameters.Add(new KeyValuePair<string, string>(Uri.EscapeDataString("oauth_nonce"),
                Uri.EscapeDataString(oAuthNonce)));
            Parameters.Add(new KeyValuePair<string, string>(Uri.EscapeDataString("oauth_signature_method"),
                Uri.EscapeDataString(TwitterRequestFactory.OauthSignatureMethod)));
            Parameters.Add(new KeyValuePair<string, string>(Uri.EscapeDataString("oauth_timestamp"),
                Uri.EscapeDataString(oAuthTimestamp)));
            Parameters.Add(new KeyValuePair<string, string>(Uri.EscapeDataString("oauth_token"),
                Uri.EscapeDataString(TwitterRequestFactory.OauthToken)));
            Parameters.Add(new KeyValuePair<string, string>(Uri.EscapeDataString("oauth_version"),
                Uri.EscapeDataString(TwitterRequestFactory.OauthToken)));

            Parameters = Parameters.OrderBy(x => x.Key).ToList();
        }
    }
}
