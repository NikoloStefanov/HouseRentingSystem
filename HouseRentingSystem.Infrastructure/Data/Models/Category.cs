using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    public class Category
    {
        /*•	Id – a unique integer, Primary Key
•	Name – a string with max length 50 (required)
•	Houses – a collection of House

*/
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(Constans.DataConstans.NameMaxLenght)]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<House> Houses { get; set; } = new List<House>();
    }
}
