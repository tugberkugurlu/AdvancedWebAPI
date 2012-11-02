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

    public class MyActionFilterAttribute : Attribute, IActionFilter {

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(
            HttpActionContext actionContext, 
            CancellationToken cancellationToken, 
            Func<Task<HttpResponseMessage>> continuation) {

            var response = await continuation();

            // As we are using await, this continuation code wouldn't run if the
            // continuation() method returned Faulted or Cancelled Task.
            Trace.TraceInformation("ExecuteActionFilterAsync is running...");
            return response;
        }

        public bool AllowMultiple {
            get { return false; }
        }
    }
}