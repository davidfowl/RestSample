using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestClientSample
{
    public class HomeController : Controller
    {
        private readonly IConferencePlannerApi _client;

        public HomeController(IRestClient<IConferencePlannerApi> api)
        {
            _client = api.Client;
        }

        [HttpGet("/")]
        public async Task<IActionResult> Get()
        {
            var sessions = await _client.GetSessionsAsync();

            return Ok(sessions);
        }
    }
}
