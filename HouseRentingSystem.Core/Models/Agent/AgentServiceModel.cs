﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Models.Agent
{
	public class AgentServiceModel
	{
		[Display(Name = "Full Name")]
		public string FullName { get; set; } = null!;
		[Display(Name ="Phone number")]
		public string PhoneNumber { get; set; } = null!;
		public string Email { get; set; } = null!;
	}
}
