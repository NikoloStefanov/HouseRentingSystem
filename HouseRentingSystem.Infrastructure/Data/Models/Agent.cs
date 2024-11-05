using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    public class Agent
    {
        /*The Agent class should have the following properties:
•	Id – a unique integer, Primary Key
•	PhoneNumber – a string with min length 7 and max length 15 (required)
•	UserId – a string (required)
•	User – an IdentityUser object
*/
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(Constans.DataConstans.PhonenMaxLenght)]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        
    }
}
