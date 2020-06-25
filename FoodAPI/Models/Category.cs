using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
