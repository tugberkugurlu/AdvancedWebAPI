using _09_PerRouteMHOwnershipSample.Models;
using _09_PerRouteMHOwnershipSample.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace _09_PerRouteMHOwnershipSample.Filters {

    public class CustomerOrdersAuthorizeAttribute : AuthorizeAttribute {

        public override void OnAuthorization(HttpActionContext actionContext) {

            base.OnAuthorization(actionContext);

            // If not authorized at all, don't bother checking for the 
            // customer - order relation
            if (actionContext.Response == null) {

                var request = actionContext.Request;
                int customerKey = GetCustomerKey(request.GetRouteData());
                var principal = Thread.CurrentPrincipal;

                var dependencyScope = request.GetDependencyScope();
                var customerRepo = (IEntityRepository<Customer>)dependencyScope
                    .GetService(typeof(IEntityRepository<Customer>));

                var customer = customerRepo.GetSingle(customerKey);

                if (!customer.Name.Equals(principal.Identity.Name)) {

                    actionContext.Response = request.CreateResponse(
                        HttpStatusCode.Unauthorized);
                }
            }
        }

        private static int GetCustomerKey(IHttpRouteData routeData) {

            var customerKey = routeData.Values["customerkey"].ToString();
            return int.Parse(customerKey);
        }
    }
}