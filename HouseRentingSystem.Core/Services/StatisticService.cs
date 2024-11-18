using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Models.Statistics;
using HouseRentingSystem.Infrastructure.Data.Comman;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IRepository repository;
        public StatisticService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<StatisticsServiceModel> TotalAsync()
        {
            int totalHouses = await repository.AllReadOnly<House>().CountAsync();
            int totalRents = await repository.AllReadOnly<House>()
                .Where(h=>h.RenterId !=null)
                .CountAsync();
            return new StatisticsServiceModel()
            {
                TotalHouses = totalHouses,
                TotalRents = totalRents
            };
        }
        
    }
}
