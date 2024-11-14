using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Enumeration;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Comman;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;
        public HouseService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<HouseQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 1)
        {
            var housesToShow = repository.AllReadOnly<House>();

            if (category !=null)
            {
                housesToShow = housesToShow.Where(h => h.Category.Name == category);
            }
            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                housesToShow = housesToShow.Where(h => (h.Title.ToLower().Contains(normalizedSearchTerm) ||
                h.Address.ToLower().Contains(normalizedSearchTerm) || h.Description.ToLower().Contains(normalizedSearchTerm)));
            }
            housesToShow = sorting switch
            {
                HouseSorting.Price => housesToShow.OrderBy(h=>h.PricePerMonth),
                HouseSorting.NotRentetFirst=>housesToShow.OrderBy(h=>h.RenterId!=null)
                .ThenByDescending(h=>h.Id),
                _ => housesToShow.OrderByDescending(h=>h.Id)
            };
            var houses = await housesToShow.Skip((currentPage-1)*housesPerPage).Take(housesPerPage).Select(h=> new HouseServiceModel()
            {
                Id = h.Id,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                IsRentet = h.RenterId !=null,
                PricePerMonth = h.PricePerMonth,
                Title = h.Title
            }).ToListAsync();

            int totalHouses = await housesToShow.CountAsync();

            return new HouseQueryServiceModel()
            {
                Houses = houses,
                TotalHousesCount = totalHouses
            };
        }

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategories()
        {
            return await repository.AllReadOnly<Category>().Select(c => new HouseCategoryServiceModel()
            {
                Id = c.Id,
                Name = c.Name,

            })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>().Select(c => c.Name).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentId(int agentId)
        {
            return await repository.AllReadOnly<House>().Where(h => h.AgentId == agentId).ProjectToHouseServiceModel().ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserId(string userId)
        {
            return await repository.AllReadOnly<House>().Where(h => h.RenterId == userId).ProjectToHouseServiceModel().ToListAsync();
        }

        public async Task<bool> CategoryExistAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>().AnyAsync(c => c.Id == categoryId);
        }

        public async  Task<int> CreateAsync(HouseFormModel model, int agentId)
        {
            House house = new House()
            {
                Address = model.Address,
                AgentId = agentId,
               CategoryId = model.CategoryId,
              ImageUrl = model.Imagane,
              PricePerMonth = model.PricePerMonth,
              Title = model.Title
            };
            await repository.AddAsync(house);
            await repository.SaveChangesAsync();
            return house.Id;
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
        {
            return await repository
                .AllReadOnly<House>().OrderByDescending(a => a.Id)
                .Take(3)
                .Select(h => new HouseIndexServiceModel
                {
                    id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title
                })
                .ToListAsync();
        }
    }
}
