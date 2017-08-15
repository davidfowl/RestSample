using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Refit;

namespace WebApplication34
{
    public class RestClient<TClient>
    {
        public TClient Client { get; set; }

        public RestClient(IOptions<RestClientOptions<TClient>> options)
        {
            if (options.Value.HttpClient != null)
            {
                Client = RestService.For<TClient>(options.Value.HttpClient, options.Value.Settings);
            }
            else
            {
                Client = RestService.For<TClient>(options.Value.Url, options.Value.Settings);
            }
        }
    }
}
