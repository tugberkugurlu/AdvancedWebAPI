using _09_PerRouteMHOwnershipSample.Filters;
using _09_PerRouteMHOwnershipSample.Models;
using _09_PerRouteMHOwnershipSample.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace _09_PerRouteMHOwnershipSample.Dispatcher {

    public class CustomerOrdersDispatcher : HttpControllerDispatcher {

        public CustomerOrdersDispatcher(HttpConfiguration config) 
            : base(config) {
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken) {

            IHttpRouteData routeData = request.GetRouteData();
            int key;
            if(!int.TryParse(routeData.Values["customerkey"].ToString(), out key)) { 

                return Task.FromResult(
                    request.CreateResponse(HttpStatusCode.NotFound)
                );
            }

            var dependecyScope = request.GetDependencyScope();
            var customerRepo = (IEntityRepository<Customer>)dependecyScope.GetService(typeof(IEntityRepository<Customer>));
            var customer = customerRepo.GetSingle(key);
            if (customer == null) {

                return Task.FromResult(
                    request.CreateResponse(HttpStatusCode.NotFound)
                );
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}