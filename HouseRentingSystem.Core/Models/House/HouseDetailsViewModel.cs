using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseDetailsViewModel
    {
        public int id { get; set; }
        public string Title { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ImagaUrl { get; set; } = null!;
    }
}
