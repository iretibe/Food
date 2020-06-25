using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public bool IsPopularProduct { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }

        [JsonIgnore]
        public ICollection<OrderDetail> OrderDetails { get; set; }

        [JsonIgnore]
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
