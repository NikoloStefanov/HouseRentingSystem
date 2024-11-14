using System.Security.Claims;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Comman;
using HouseRentingSystem.Models.Atributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HouseRentingSystem.Controllers
{
    public class HouseController : BaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;
        public HouseController(IHouseService _houseService, IAgentService _agentService)
        {
            houseService = _houseService;
            agentService = _agentService;
        }
    
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllHousesQueryModel query)
        {
            var model = await houseService.AllAsync(query.Category, query.SearchItem, query.Sorting, query.CurrentPage, query.HousesPerPages);

            query.TotalHousesCount = model.TotalHousesCount;
            query.Houses = model.Houses;
            query.Categories = await houseService.AllCategoriesNamesAsync();
            return View(query);
        }
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<HouseServiceModel> model;

            if (await agentService.ExistsByIdAsync(userId))
            {
                int agentId = await agentService.GetAgentIdAsync(userId)??0;
                model = await houseService.AllHousesByAgentId(agentId);
            }
            else
            {
                model = await houseService.AllHousesByUserId(userId);
            }
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {

            if (await houseService.Exists(id) == false)
            {
                return BadRequest();
            }

            var model = await houseService.HouseDetailsById(id);
            return View(model);
        }
        [HttpGet]
        [MustBeAgent]
        public async Task<IActionResult> Add()
        {
           
            var model = new HouseFormModel()
            {
                Categories = await houseService.AllCategories()
            };

            return View(model);
        }
        [HttpPost]
        [MustBeAgent]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            if (await houseService.CategoryExistAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }
            if (ModelState.IsValid==false)
            {
                model.Categories = await houseService.AllCategories();
                return View(model);
            }
            int? agentId = await agentService.GetAgentIdAsync(User.Id());
            int newHouseId = await houseService.CreateAsync(model, agentId ?? 0);
            return RedirectToAction(nameof(Details), new { id = newHouseId });
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (await houseService.Exists(id) == false)
            {
                return BadRequest();
            }
            if (await houseService.HasAgentWithId(id,User.Id()) == false)
            {
                return Unauthorized();
            }
            var house = await houseService.HouseDetailsById(id);
            var model = await houseService.GetHouseFormModelByIdAsync(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,HouseFormModel model)
        {
            if (await houseService.Exists(id) == false)
            {
                return BadRequest();
            }
            if (await houseService.HasAgentWithId(id, User.Id()) == false)
            {
                return Unauthorized();
            }
            if (await houseService.CategoryExistAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }
            if (ModelState.IsValid == false)
            {
                model.Categories = await houseService.AllCategories();
                return View(model);
            }
            await houseService.Edit(id, model);
            return RedirectToAction(nameof(Details), new { id });
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (await houseService.Exists(id) == false)
            {
                return BadRequest();
            }
            if (await houseService.HasAgentWithId(id, User.Id()) == false)
            {
                return Unauthorized();
            }
            var house = await houseService.HouseDetailsById(id);
            var model = new HouseDetailsViewModel()
            {
                Title = house.Title,
                Address = house.Address,
                ImagaUrl = house.ImageUrl

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(HouseDetailsViewModel model)
        {
            if (await houseService.Exists(model.id) == false)
            {
                return BadRequest();
            }
            if (await houseService.HasAgentWithId(model.id, User.Id()) == false)
            {
                return Unauthorized();
            }
           await houseService.Delete(model.id);
            return RedirectToAction(nameof(All));

        }
        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            return RedirectToAction(nameof(Mine));

        }
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            return RedirectToAction(nameof(Mine));

        }
    }
}
