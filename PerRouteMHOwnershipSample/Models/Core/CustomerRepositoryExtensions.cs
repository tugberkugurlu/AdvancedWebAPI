using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _09_PerRouteMHOwnershipSample.Models.Core {
    
    public static class CustomerRepositoryExtensions {

        public static Customer GetSingleByName(this IEntityRepository<Customer> customerRepository, string name) {

            return customerRepository.GetAll().FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}