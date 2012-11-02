using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace RequireHttpsMessageHandlerSample.MessageHandlers {

    public class RemoveServerHeaderMessageHandler : DelegatingHandler {

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken) {

            var response = await base.SendAsync(request, cancellationToken);

            var httpContext = request.Properties["MS_HttpContext"] as HttpContextWrapper;
            if (httpContext != null)
                httpContext.Response.Headers.Remove("Server");

            return response;
        }
    }
}