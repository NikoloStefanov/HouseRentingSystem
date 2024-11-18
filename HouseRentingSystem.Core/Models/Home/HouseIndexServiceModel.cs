using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRentingSystem.Core.Contracts;

namespace HouseRentingSystem.Core.Models.Home
{
	public class HouseIndexServiceModel : IHouseModel
	{
		public int id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
	}
}
