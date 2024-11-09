using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Infrastructure.Data.Comman;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;
        public AgentService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(string usernId, string phoneNumber)
        {
            await repository.AddAsync(new Agent()
            {
                UserId = usernId,
                PhoneNumber = phoneNumber

            });
            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Agent>().AnyAsync(a => a.UserId == userId);
        }

        public async Task<int?> GetAgentIdAsync(string userId)
        {
            return (await repository.AllReadOnly<Agent>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id;
        }

        public async Task<bool> UserHasRentsAsync(string userId)
        {
            return await repository.AllReadOnly<House>()
                 .AnyAsync(h => h.RenterId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<Agent>().AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
