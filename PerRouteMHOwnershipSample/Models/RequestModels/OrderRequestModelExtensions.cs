using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _09_PerRouteMHOwnershipSample.Models.RequestModels {
    
    public static class OrderRequestModelExtensions {

        public static Order ToOrder(this OrderRequestModel requestModel, int customerKey) {

            return new Order { 
                CustomerKey = customerKey,
                ProductName = requestModel.ProductName,
                Price = requestModel.Price,
                PurchasedOn = DateTime.Now
            };
        }
    }
}