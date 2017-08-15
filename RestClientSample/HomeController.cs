using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication34
{
    public class HomeController : Controller
    {
        private readonly IConferencePlannerApi _client;

        public HomeController(RestClient<IConferencePlannerApi> api)
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
