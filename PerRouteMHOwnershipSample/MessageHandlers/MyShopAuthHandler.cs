using _09_PerRouteMHOwnershipSample.Models;
using _09_PerRouteMHOwnershipSample.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using WebAPIDoodle.Http;

namespace _09_PerRouteMHOwnershipSample.MessageHandlers {

    public class MyShopAuthHandler : BasicAuthenticationHandler {

        protected override IPrincipal AuthenticateUser(
            HttpRequestMessage request,
            string username,
            string password,
            CancellationToken cancellationToken) {

            var dependecyScope = request.GetDependencyScope();
            var customerRepo = (IEntityRepository<Customer>)dependecyScope.GetService(typeof(IEntityRepository<Customer>));
            var customer = customerRepo.GetSingleByName(username);

            if (customer != null && isUserValid(customer, password)) { 

                var identity = new GenericIdentity(customer.Name);
                var principal = new GenericPrincipal(identity, null);

                return principal;
            }

            return null;
        }

        private bool isUserValid(Customer customer, string password) {

            var realPassword = CryptoUtil.EncryptPassword(password, customer.Salt);

            return string.Equals(
                    realPassword, customer.HashedPassword);
        }
    }
}