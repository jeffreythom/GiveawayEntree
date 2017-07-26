using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiveawayEntree.Request
{
    public abstract class BaseRequest<T>
    {
        protected HttpWebResponse RequestResponse;
        protected T ReturnValue;
        protected string ErrorMessage;

        protected BaseRequest()
        {
        }

        protected virtual HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }

        public T GetResult()
        {
            return ReturnValue;
        }

        public string GetErrorMessage()
        {
            return ErrorMessage;
        }

        public async Task<bool> MakeRequest()
        {
            var request = WebRequest.Create(GetUrl());
            request.Method = GetHttpMethod().Method;
            request.Headers = GetHeaders();
            RequestResponse = (HttpWebResponse) await Task.Factory
                .FromAsync(request.BeginGetResponse,
                    request.EndGetResponse, null);
            if (RequestResponse.StatusCode != HttpStatusCode.OK)
            {
                OnError();
                return false;
            }
            OnSuccess();
            return true;
        }

        protected virtual void OnError()
        {
           // ReturnAction(false, );
        }

        protected virtual void OnSuccess()
        {
           // ReturnAction(true, RequestResponse);
        }

        protected virtual WebHeaderCollection GetHeaders()
        {
            return null;
        }

        protected virtual string GetUrl()
        {
            return "";
        }
    }
}
