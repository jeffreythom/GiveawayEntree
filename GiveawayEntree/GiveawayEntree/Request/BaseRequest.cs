using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GiveawayEntree.Request
{
    public abstract class BaseRequest<T>
    {
        protected BaseRequest(Action) 
        {
            
        } 
        protected virtual HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }

        public async void MakeRequest()
        {
            var request = WebRequest.Create(GetUrl());
            request.Method = GetHttpMethod().Method;
            var response = (HttpWebResponse) await Task.Factory
                .FromAsync(request.BeginGetResponse,
                    request.EndGetResponse, null);
            
        }

        public virtual void OnError()
        {
            
        }

        public virtual void OnSuccess()
        {
            
        }

        protected virtual void GetHeaders()
        {
            
        }

        protected virtual string GetUrl()
        {
            return "";
        }
}
