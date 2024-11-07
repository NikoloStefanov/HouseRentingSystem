using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Contracts.House
{
    public interface IAgentService
    {
        Task<bool> ExistsById(string userId);
        Task<bool> UserWithPhoneNumberExistsAsync(string phoneNumber);
        Task<bool> UserHasRentsAsync(string userId);
        Task CreateAsync(string usernId, string phoneNumber);
    }
}
