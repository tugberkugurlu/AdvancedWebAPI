using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _09_PerRouteMHOwnershipSample.Models.Dtos {
    
    public static class CustomerExtensions {

        public static CustomerDto ToCustomerDto(this Customer customer) {

            return new CustomerDto { 
                Key = customer.Key,
                Name = customer.Name,
                Surname = customer.Surname,
                Email = customer.Email
            };
        }
    }
}