using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    public class House
    {
        /*•	
•	
•	
•	PricePerMonth – a decimal with min value 0 and max value 2000 (required)
•	
•	AgentId – an integer (required)
•	Agent – an Agent object
•	RenterId – a string
*/
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(Constans.DataConstans.TitleMaxLenght)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(Constans.DataConstans.AddressMaxLenght)]
        public string Address { get; set; } = string.Empty;
        [Required]
        [MaxLength(Constans.DataConstans.DescriptionManLenght)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        // [Range(typeof(decimal),Constans.DataConstans.HouseRentingPriceMin, Constans.DataConstans.HouseRentingPriceMax,ConvertValueInInvariantCulture =true)]
        [Column(TypeName ="decimal(18,2)")]
        public decimal PricePerMonth { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
        public int AgentId { get; set; }
        public Agent Agent { get; set; } = null!;
        public string? RenterId { get; set; }

    }
}
