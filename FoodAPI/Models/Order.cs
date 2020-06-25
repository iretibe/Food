﻿using System;
using System.Collections.Generic;

namespace FoodAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool IsOrderCompleted { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
