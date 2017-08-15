using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RestClientSample
{
    public class MyMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }

    public static class MyMessageHandlerHttpClientBuilderExtensions
    {
        public static IHttpClientBuilder UseMyMessageHandler(this IHttpClientBuilder clientBuilder)
        {
            return clientBuilder.Use(new MyMessageHandler());
        }
    }
}
