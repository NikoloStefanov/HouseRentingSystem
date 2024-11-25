using System.Security.Claims;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Exceptions;
using HouseRentingSystem.Core.Extensions;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Comman;
using HouseRentingSystem.Models.Atributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;

namespace HouseRentingSystem.Controllers
{
    public class HouseController : BaseController
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;
        private readonly ILogger logger;
        public HouseController(IHouseService _houseService, IAgentService _agentService, ILogger<HouseController> _logger)
        {
            houseService = _houseService;
            agentService = _agentService;
            logger = _logger;
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
        public async Task<IActionResult> Details(int id, string information)
        {

            if (await houseService.Exists(id) == false)
            {
                return BadRequest();
            }
           
            var model = await houseService.HouseDetailsById(id);
            if (information!=model.GetInformation())
            {
                return BadRequest();
            }
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
            return RedirectToAction(nameof(Details), new { id = newHouseId, information = model.GetInformation() });
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (await houseService.Exists(id) == false)
            {
                return BadRequest();
            }
            if (await houseService.HasAgentWithId(id,User.Id()) == false && User.IsAdmin() == false)
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
            if (await houseService.HasAgentWithId(id, User.Id()) == false && User.IsAdmin()==false)
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
            return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() }) ;
        }
        public async Task<IActionResult> Delete(int id)
        {
            
            if (await houseService.Exists(id) == false)
            {
                return BadRequest();
            }

            if (await houseService.HasAgentWithId(id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var house = await houseService.HouseDetailsById(id);
            var model = new HouseDetailsViewModel()
            {
                id = house.Id,  // Добавете ID в модела, за да го предадете в POST метода
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

            if (await houseService.HasAgentWithId(model.id, User.Id()) == false && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await houseService.Delete(model.id); // Извършване на изтриването
            return RedirectToAction(nameof(All)); // Пренасочване към списъка с имоти

        }
        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            if (await houseService.Exists(id) == false)
            {
                return BadRequest();
            }
            if (await agentService.ExistsByIdAsync(User.Id()) && User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            if (await houseService.IsRented(id))
            {
                return BadRequest();
            }
           await houseService.Rent(id, User.Id());
            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            if (await houseService.Exists(id) == false)
            {
                return BadRequest();
            }
            try
            {
                await houseService.Leave(id, User.Id());
            }
            catch (UnautorizedActionException ex)
            {
                logger.LogError(ex,"HouseController/Leave");
                return Unauthorized();
            }
          
            return RedirectToAction(nameof(All));

        }
    }
}
