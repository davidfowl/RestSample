using System.Collections.Generic;
using System.Net.Http;

namespace RestClientSample
{
    public class RestClientOptions<TClient> : IHttpClientBuilder
    {
        private List<DelegatingHandler> _handlers = new List<DelegatingHandler>();

        public string Url { get; set; }
        public HttpClient HttpClient { get; set; }

        public HttpMessageHandler Build()
        {
            HttpMessageHandler current = new HttpClientHandler();

            for (int i = _handlers.Count - 1; i >= 0; i--)
            {
                var handler = _handlers[i];
                handler.InnerHandler = current;
                current = handler;
            }

            return current;
        }

        public IHttpClientBuilder Use(DelegatingHandler handler)
        {
            _handlers.Add(handler);
            return this;
        }
    }
}
