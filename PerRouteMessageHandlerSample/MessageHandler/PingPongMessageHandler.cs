using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PerRouteMessageHandlerSample.MessageHandler {
    
    public class PingPongMessageHandler : HttpMessageHandler {

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, 
            CancellationToken cancellationToken) {

            var response = request.CreateResponse(HttpStatusCode.OK, "Pong");
            return Task.FromResult(response);
        }
    }
}