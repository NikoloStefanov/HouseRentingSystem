using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HouseRentingSystem.Core.Constans;
using static HouseRentingSystem.Infrastructure.Constans.DataConstans;

namespace HouseRentingSystem.Core.Models.Agent
{
	public class BecomeAgentFormModel
	{
		[Required(ErrorMessage =MessageConstans.RequiredMessage)]
		[StringLength(PhonenMaxLenght,MinimumLength =PhoneMinLenght, ErrorMessage = MessageConstans.LenghtMessage)]
		[Display(Name ="Phone Number")]
		[Phone]
		public string PhoneNumber { get; set; } = null!;
	}
}
