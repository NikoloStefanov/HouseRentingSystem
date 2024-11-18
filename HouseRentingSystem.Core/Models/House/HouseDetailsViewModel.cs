using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRentingSystem.Core.Contracts;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseDetailsViewModel : IHouseModel
    {
        public int id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ImagaUrl { get; set; } = string.Empty;
    }
}
