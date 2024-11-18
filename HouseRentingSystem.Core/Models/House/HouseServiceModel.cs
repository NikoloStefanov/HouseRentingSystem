using System.ComponentModel;
using HouseRentingSystem.Infrastructure.Constans;
using System.ComponentModel.DataAnnotations;
using HouseRentingSystem.Core.Contracts;

namespace HouseRentingSystem.Core.Models.House
{
    public class HouseServiceModel : IHouseModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(DataConstans.TitleMaxLenght, MinimumLength = DataConstans.TitleMixLenght)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(DataConstans.AddressMaxLenght, MinimumLength = DataConstans.AddressMinLenght)]
        public string Address { get; set; } = string.Empty;
        [Required]
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
       
        [Required]
        [Range(typeof(decimal),
            DataConstans.HouseRentingPriceMin,
            DataConstans.HouseRentingPriceMax,

            ConvertValueInInvariantCulture = true
            , ErrorMessage =
            "Price Per Month must be a positive number and less than {2} leva")]
        [DisplayName("Price Per Month")]
        public decimal PricePerMonth { get; set; }
        [DisplayName("Is Rentet")]
        public bool IsRentet { get; set; }

    }
}