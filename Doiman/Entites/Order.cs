﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doiman.Entites
{
    public class Order : BaseEntity<int>
    {
      
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
    }
}
