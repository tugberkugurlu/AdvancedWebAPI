using InvalidModelStateFilterSample.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace InvalidModelStateFilterSample {

    public class Global : HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {

            var config = GlobalConfiguration.Configuration;
            config.Routes.MapHttpRoute(
                "DefaultHttpRoute",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            //// Remove only the InvalidModelValidatorProvider
            //config.Services.RemoveAll(
            //    typeof(System.Web.Http.Validation.ModelValidatorProvider),
            //    validator => (validator
            //        is System.Web.Http.Validation.Providers.InvalidModelValidatorProvider));

            //// Suppressing the IRequiredMemberSelector for all formatters
            //foreach (var formatter in config.Formatters) {

            //    formatter.RequiredMemberSelector =
            //        new SuppressedRequiredMemberSelector();
            //}
        }
    }
}