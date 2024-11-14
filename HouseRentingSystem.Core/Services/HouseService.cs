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

            if (category != null)
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
                HouseSorting.Price => housesToShow.OrderBy(h => h.PricePerMonth),
                HouseSorting.NotRentetFirst => housesToShow.OrderBy(h => h.RenterId != null)
                .ThenByDescending(h => h.Id),
                _ => housesToShow.OrderByDescending(h => h.Id)
            };
            var houses = await housesToShow.Skip((currentPage - 1) * housesPerPage).Take(housesPerPage).Select(h => new HouseServiceModel()
            {
                Id = h.Id,
                Address = h.Address,
                ImageUrl = h.ImageUrl,
                IsRentet = h.RenterId != null,
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

        public async Task<int> CreateAsync(HouseFormModel model, int agentId)
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

        public async Task Delete(int id)
        {
            var house = await repository.All<House>().FirstOrDefaultAsync(h => h.Id == id);

            if (house != null)
            {
                repository.Remove(house);
                await repository.SaveChangesAsync();
            }
        }

        public async Task Edit(int houseId, HouseFormModel model)
        {
            var house = await repository.GetByIdAsync<House>(houseId);

            if (house != null)
            {
                house.Address = model.Address;
                house.CategoryId = model.CategoryId;
                house.Description = model.Description;
                house.ImageUrl = model.Imagane;
                house.PricePerMonth = model.PricePerMonth;
                house.Title = model.Title;
            }
            await repository.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await repository.AllReadOnly<House>().AnyAsync(h => h.Id == id);
        }

        public async Task<HouseFormModel?> GetHouseFormModelByIdAsync(int id)
        {
            var house = await repository.AllReadOnly<House>().Where(h => h.Id == id).Select(h => new HouseFormModel
            {
                Address = h.Address,
                CategoryId = h.CategoryId,
                Description = h.Description,
                Imagane = h.ImageUrl,
                Title = h.Title,
                PricePerMonth = h.PricePerMonth
            }).FirstOrDefaultAsync();
            if (house != null)
            {
                house.Categories = await AllCategories();
            }


            return house;
        }

        public async Task<bool> HasAgentWithId(int houseId, string userId)
        {
            return await repository.AllReadOnly<House>().AnyAsync(h => h.Id == houseId && h.Agent.User.Id == userId);
        }

        public async Task<HouseDetailsServiceModel> HouseDetailsById(int id)
        {
            return await repository.AllReadOnly<House>().Where(h => h.Id == id).Select(h => new HouseDetailsServiceModel()
            {
                Id = h.Id,
                Address = h.Address,
                Agent = new Models.Agent.AgentServiceModel()
                {
                    Email = h.Agent.User.Email,
                    PhoneNumber = h.Agent.PhoneNumber
                },
                Category = h.Category.Name,
                Description = h.Description,
                ImageUrl = h.ImageUrl,
                IsRentet = h.RenterId != null,
                PricePerMonth = h.PricePerMonth,
                Title = h.Title


            }).FirstAsync();
        }

        public async Task<bool> IsRented(int id)
        {
            var house = await repository.AllReadOnly<House>().FirstOrDefaultAsync(h => h.Id == id);


            return house != null && house.RenterId != null;
        }

        public async Task<bool> IsRentedByUserWithId(int houseId, string userId)
        {
            var houses = await repository.AllReadOnly<House>().FirstOrDefaultAsync(h => h.Id == houseId);
            if (houses == null)
            {
                return false;
            }
            if (houses.RenterId != userId)
            {
                return false;
            }
            return true;
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

        public async void Rent(int houseId, string userId)
        {
           
                var house = await repository.All<House>().FirstOrDefaultAsync(h=>h.Id == houseId);
                if (house == null)
                {
                    throw new InvalidOperationException($"House with ID {houseId} not found.");
                }

                if (house.RenterId != null)
                {
                    throw new InvalidOperationException("This house is already rented.");
                }

                house.RenterId = userId;

                // Логиране на актуализацията на къщата
                Console.WriteLine($"Renting house {houseId} to user {userId}");

                await repository.SaveChangesAsync();
            

        }
    }
}
