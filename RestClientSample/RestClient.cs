using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Refit;

namespace RestClientSample
{
    public class RestClient<TClient> : IRestClient<TClient>
    {
        private RefitSettings _settings;

        public TClient Client { get; set; }

        public RestClient(IOptions<RestClientOptions<TClient>> options)
        {
            _settings = new RefitSettings();
            var handler = options.Value.Build();
            _settings.HttpMessageHandlerFactory = () => handler;

            if (options.Value.HttpClient != null)
            {
                Client = RestService.For<TClient>(options.Value.HttpClient, _settings);
            }
            else
            {
                Client = RestService.For<TClient>(options.Value.Url, _settings);
            }
        }

        public TClient GetClient(string url)
        {
            return RestService.For<TClient>(url, _settings);
        }
    }
}
