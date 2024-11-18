using HouseRentingSystem.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    [Route("api/statistic")]
    [ApiController]
    public class StatisticApiController : ControllerBase
    {
        private readonly IStatisticService statisticServece;
        public StatisticApiController(IStatisticService _statisticServece)
        {
            statisticServece=_statisticServece; 
        }
        [HttpGet]
        public async Task<IActionResult> GetStatistic()
        {
            var result = await statisticServece.TotalAsync();
            return Ok(result);
        }

    }
}
