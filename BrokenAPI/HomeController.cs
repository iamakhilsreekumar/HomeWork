using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BrokenAPI.common;
using System.Linq;
using Microsoft.Extensions.Configuration;
using BrokenAPI.Services;

namespace BrokenAPI
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        public readonly HttpHandlers _httpHandlers;
        public HomeController(HttpHandlers httpHandlers)
        {
            _httpHandlers = httpHandlers;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetPeopleAsync(string input)
        {
            ApiParser peoples = await _httpHandlers.CallAPIAsync<ApiParser>();
            return Content(string.Join(", ", peoples?.results?.
                Where(x => x.name?.ToLower().Contains(input?.ToLower()) == true).Select(x => x.name).ToArray()));
        }
    }
}
