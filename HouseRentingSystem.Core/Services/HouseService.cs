﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Core.Models.House;
using HouseRentingSystem.Infrastructure.Data.Comman;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;
        public HouseService(IRepository _repository)
        {
            repository = _repository;
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
