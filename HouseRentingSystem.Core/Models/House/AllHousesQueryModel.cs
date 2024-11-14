using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRentingSystem.Core.Enumeration;

namespace HouseRentingSystem.Core.Models.House
{
    public class AllHousesQueryModel
    {
        public int  HousesPerPages { get; } = 3;

        public string Category { get; init; } = null!;
        [Display(Name = "Search by text")]
        public string SearchItem { get; init; } = null!;

        public HouseSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;
        public int TotalHousesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;
        public IEnumerable<HouseServiceModel> Houses { get; set; } = new List<HouseServiceModel>();
    }
}
