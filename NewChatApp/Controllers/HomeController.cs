using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NewChatApp.Hubs;
using System.Diagnostics;
namespace NewChatApp.Controllers
{
    //[Route("Home")]
    //[ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<DeathlyHallowsHub> _deathlyHub;

        public HomeController(ILogger<HomeController> logger, IHubContext<DeathlyHallowsHub> hubContext)
        {
            _logger = logger;
            _deathlyHub = hubContext;   
        }
        public async Task<IActionResult> DeathlyHallows(string type)
        {
            if (SD.DealthyHallowRace.ContainsKey(type))
            {

                SD.DealthyHallowRace[type]++;
            }
            await _deathlyHub.Clients.All.SendAsync("updateDeathlyHollowCount",
                SD.DealthyHallowRace[SD.Cloak],
                SD.DealthyHallowRace[SD.Wand],
                SD.DealthyHallowRace[SD.Stone]);
            return Accepted();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Notification() {
            return View();
        }
        public IActionResult DeathlyHallowRace() {
            return View();
        }
        public IActionResult HarryPotterRace() {
            return View();
        }

    }
}
