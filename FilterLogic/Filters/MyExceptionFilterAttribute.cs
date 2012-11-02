using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FilterLogic.Filters {

    public class MyExceptionFilterAttribute : Attribute, IExceptionFilter {

        public Task ExecuteExceptionFilterAsync(
            HttpActionExecutedContext actionExecutedContext, 
            CancellationToken cancellationToken) {

            Trace.TraceInformation("ExecuteExceptionFilterAsync is running...");
            return Task.FromResult(0);
        }

        public bool AllowMultiple {
            get { return false; }
        }
    }
}