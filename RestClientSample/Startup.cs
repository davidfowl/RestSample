using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Refit;

namespace RestClientSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRestClient<IConferencePlannerApi>(o =>
            {
                o.Url = "https://conferenceplanner-api.azurewebsites.net/";
                o.UseMyMessageHandler();
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }

    public interface IConferencePlannerApi
    {
        [Get("/api/sessions")]
        Task<IEnumerable<JObject>> GetSessionsAsync();
    }
}
