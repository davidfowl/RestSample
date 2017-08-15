using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RestClientSample
{
    public interface IHttpClientBuilder
    {
        IHttpClientBuilder Use(DelegatingHandler handler);

        HttpMessageHandler Build();
    }
}
