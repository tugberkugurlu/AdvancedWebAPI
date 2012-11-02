using _09_PerRouteMHOwnershipSample.Config;
using _09_PerRouteMHOwnershipSample.Dispatcher;
using _09_PerRouteMHOwnershipSample.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace _09_PerRouteMHOwnershipSample {

    public class Global : HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {

            var config = GlobalConfiguration.Configuration;

            AutofacWebAPI.Initialize(config);

            config.Routes.MapHttpRoute(
                "CustomerOrdersHttpRoute",
                "api/customers/{customerKey}/orders/{key}",
                new { controller = "CustomerOrders", key = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "CustomerOrdersHttpRoute",
            //    routeTemplate: "api/customers/{customerKey}/orders/{key}",
            //    defaults: new { controller = "CustomerOrders", key = RouteParameter.Optional },
            //    constraints: null,
            //    handler: new CustomerOrdersDispatcher(config)
            //);

            config.Routes.MapHttpRoute(
                "DefaultHttpRoute",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new MyShopAuthHandler());
        }
    }
}