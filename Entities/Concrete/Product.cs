﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public Product()
        {
            Orders = new List<Order>();
        }


        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public List<Order> Orders { get; set; }
    }
}
