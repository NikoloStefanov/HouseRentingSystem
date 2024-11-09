using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;

namespace HouseRentingSystem.Core.Contracts.House
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();

        Task<IEnumerable<HouseCategoryServiceModel>> AllCategories();
        Task<bool>CategoryExistAsync(int categoryId);
        Task<int> CreateAsync(HouseFormModel model, int agentId);
    }
}
