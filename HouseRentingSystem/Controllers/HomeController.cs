using System.Diagnostics;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHouseService service;

        public HomeController(ILogger<HomeController> logger, IHouseService _service)
        {
            _logger = logger;
            service = _service;
        }
        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var houses = await service.LastThreeHouses();
            return View(houses);
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}