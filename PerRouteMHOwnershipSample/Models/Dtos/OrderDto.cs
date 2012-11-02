using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _09_PerRouteMHOwnershipSample.Models.Dtos {

    public class OrderDto {

        public int Key { get; set; }
        public int CustomerKey { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchasedOn { get; set; }
    }
}