using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WebApplication34
{
    public static class RestClientServiceCollectionExtensions
    {
        public static IServiceCollection AddRestClient<TClient>(this IServiceCollection services, Action<RestClientOptions<TClient>> action)
        {
            services.TryAddSingleton(typeof(RestClient<>));
            services.Configure(action);
            return services;
        }
    }
}
