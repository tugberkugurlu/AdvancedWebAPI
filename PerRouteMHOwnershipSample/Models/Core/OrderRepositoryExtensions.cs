using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _09_PerRouteMHOwnershipSample.Models.Core {
    
    public static class OrderRepositoryExtensions {

        public static IEnumerable<Order> GetAll(this IEntityRepository<Order> orderRepository, int customerKey) {

            return orderRepository.GetAll().Where(x => x.CustomerKey == customerKey);
        }
    }
}