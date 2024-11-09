using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using HouseRentingSystem.Core.Constans;
using HouseRentingSystem.Infrastructure.Constans;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseFormModel
    {
        [Required]
        [StringLength(DataConstans.TitleMaxLenght, MinimumLength = DataConstans.TitleMixLenght)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DataConstans.AddressMaxLenght, MinimumLength = DataConstans.AddressMinLenght)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [StringLength(DataConstans.DescriptionManLenght, MinimumLength = DataConstans.DescriptionMinLenght)]
        public string Description { get; set; } = string.Empty;

        [Required]
       [Display(Name ="Image URL")]
        public string Imagane { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal),
            DataConstans.HouseRentingPriceMin,
            DataConstans.HouseRentingPriceMax,

            ConvertValueInInvariantCulture =true
            ,ErrorMessage =
            "Price Per Month must be a positive number and less than {2} leva")]
       
        [Display(Name ="Price Per Month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<HouseCategoryServiceModel> Categories { get; set; } = new List<HouseCategoryServiceModel>();
    }
}
