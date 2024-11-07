using System.Security.Claims;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Models.Agent;


using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
	
	public class AgentController : BaseController
	{
		private readonly IAgentService agentService;
		public AgentController(IAgentService agentService)
		{
			this.agentService = agentService;
		}

		[HttpGet]
		public async Task<IActionResult> Become()
		{
			var model = new BecomeAgentFormModel();
			if (await agentService.ExistsById(User.Id()))
			{
				return BadRequest();
			}
			return View(model);
		}
		[HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel agent)
        {
            return RedirectToAction(nameof(HouseController.All),"House");
        }
    }
}
