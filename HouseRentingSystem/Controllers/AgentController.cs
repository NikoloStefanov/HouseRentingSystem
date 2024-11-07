using System.Security.Claims;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Models.Agent;
using HouseRentingSystem.Models.Atributes;
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
        [NotAnAgent]
        public async Task<IActionResult> Become()
        {
            var userId = User.Id();

            // Проверка дали потребителят вече е агент
            if (await agentService.ExistsByIdAsync(userId))
            {
                return BadRequest("You are already an agent.");
            }

            // Проверка дали вече има телефонен номер
            if (await agentService.UserWithPhoneNumberExistsAsync(userId))
            {
                return BadRequest("You already have a phone number registered.");
            }

            var model = new BecomeAgentFormModel();
            return View(model);
        }

        [HttpPost]
        [NotAnAgent]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            var userId = User.Id();

            // Проверка дали потребителят вече е агент или има телефонен номер
            if (await agentService.ExistsByIdAsync(userId))
            {
                return BadRequest("You are already an agent.");
            }

            // Проверка дали телефонният номер вече съществува
            if (await agentService.UserWithPhoneNumberExistsAsync(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Phone number already exists. Enter another one.");
            }

            // Проверка дали потребителят има наем
            if (await agentService.UserHasRentsAsync(userId))
            {
                ModelState.AddModelError("Error", "You should have no rents to become an agent.");
            }

            // Ако има грешки в модела, върнете същата форма
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Създаване на агент
            await agentService.CreateAsync(userId, model.PhoneNumber);
            return RedirectToAction(nameof(HouseController.All), "House");
        }

    }
}
