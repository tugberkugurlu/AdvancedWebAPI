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
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Routing;

namespace _09_PerRouteMHOwnershipSample.Filters {

    public class EnsureOrderOwnershipAttribute : Attribute, IAuthorizationFilter {

        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(
            HttpActionContext actionContext, 
            CancellationToken cancellationToken, 
            Func<Task<HttpResponseMessage>> continuation) {

            IHttpRouteData routeData = actionContext.Request.GetRouteData();
            Uri requestUri = actionContext.Request.RequestUri;

            var customerKey = GetCustomerKey(routeData);
            var orderKey = GetOrderKey(routeData, requestUri);

            var dependencyScope = actionContext.Request.GetDependencyScope();
            var orderRepo = (IEntityRepository<Order>)dependencyScope
                .GetService(typeof(IEntityRepository<Order>));

            var order = orderRepo.GetSingle(orderKey);
            if (order == null) {

                return Task.FromResult(
                    actionContext.Request.CreateResponse(HttpStatusCode.NotFound));
            }

            if (order.CustomerKey != customerKey) {

                return Task.FromResult(
                    actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized));
            }

            return continuation();
        }

        private static int GetCustomerKey(IHttpRouteData routeData) {

            var customerKey = routeData.Values["customerkey"].ToString();
            return int.Parse(customerKey);
        }

        private static int GetOrderKey(
            IHttpRouteData routeData, Uri requestUri) {

            object orderKeyString;
            if (routeData.Values.TryGetValue("key", out orderKeyString)) {

                return int.Parse(orderKeyString.ToString());
            }

            // It's now sure that query string has the shipmentKey value
            var quesryString = requestUri.ParseQueryString();
            return int.Parse(quesryString["key"]);
        }

        public bool AllowMultiple {
            get { return false; }
        }
    }
}