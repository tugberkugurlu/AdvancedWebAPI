using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FilterLogic.Filters {

    public class MySecondActionFilterAttribute : ActionFilterAttribute {

        public override void OnActionExecuting(HttpActionContext actionContext) {

            Trace.TraceInformation("OnActionExecuting is running...");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext) {

            // Regardless of the controller action's or other filter's situation
            // this method always be run if this.OnActionExecuting method has been invoked.
            Trace.TraceInformation("OnActionExecuted is running...");
        }
    }
}