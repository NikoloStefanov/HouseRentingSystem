using HouseRentingSystem.Core.Enumeration;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using Microsoft.AspNetCore.Identity;

namespace HouseRentingSystem.Core.Contracts.House
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();

        Task<IEnumerable<HouseCategoryServiceModel>> AllCategories();
        Task<bool>CategoryExistAsync(int categoryId);
        Task<int> CreateAsync(HouseFormModel model, int agentId);
        Task<HouseQueryServiceModel> AllAsync(string? category = null,
            string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest,
            int currentPage = 1, int housesPerPage=1);
        Task<IEnumerable<string>> AllCategoriesNamesAsync();
        Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int agentId);
        Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId);
        Task<bool> Exists(int id);
        Task<HouseDetailsServiceModel> HouseDetailsById(int id);

        Task Edit(int houseId, HouseFormModel model);
        Task<bool> HasAgentWithId(int houseId, string userId);
        Task<HouseFormModel?> GetHouseFormModelByIdAsync(int id);
        Task Delete(int id);
        Task<bool> IsRented(int id);
        Task<bool> IsRentedByUserWithId(int houseId, string userId);
        Task Rent(int houseId, string userId);
        Task Leave(int houseId, string userId);
    }
}
