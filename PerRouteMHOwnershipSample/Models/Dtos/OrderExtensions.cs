using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _09_PerRouteMHOwnershipSample.Models.Dtos {
    
    public static class OrderExtensions {

        public static OrderDto ToOrderDto(this Order order) {

            return new OrderDto { 
                Key = order.Key,
                CustomerKey = order.CustomerKey,
                ProductName = order.ProductName,
                Price = order.Price,
                PurchasedOn = order.PurchasedOn
            };
        }
    }
}