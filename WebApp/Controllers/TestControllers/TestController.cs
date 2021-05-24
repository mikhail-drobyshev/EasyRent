using System;
using System.Net.Http;
using System.Threading.Tasks;
using DAL.App.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.ViewModels.Test;

namespace WebApp.Controllers.TestControllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly AppDbContext _ctx;

        public TestController(ILogger<TestController> logger, AppDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        // GET
        public async Task<IActionResult> Test()
        {
            _logger.LogInformation("Test method starts");
            var vm = new TestViewModel
            {
                PropertyTypes = await _ctx
                    .PropertyTypes
                    //.Include(x => x.PropertyTypeValue)
                    .ToListAsync()
            };
            _logger.LogInformation("Test method pre-return");
            return View(vm);
        }

        [Authorize]
        public string TestAuth()
        {
            return "OK";
        }
    }

    public class HttpClientAdapter
    {
        public virtual int GetPageLength(string url)
        {
            var client = new HttpClient();
            if (client != null)
            {
                var response = client.GetAsync(url).Result;
                var body = response.Content.ReadAsStringAsync().Result;
                return body.Length;
            }

            return -1;
        }
    }
}
