using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace WebApplication34
{
    public class RestClientOptions<TClient>
    {
        public string Url { get; set; }
        public RefitSettings Settings { get; set; }
        public HttpClient HttpClient { get; set; }
    }
}
