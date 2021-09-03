using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ABIC.Function
{
    public static class RandInt
    {
        [Function("RandInt")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("RandInt");
            logger.LogInformation("Request Triggered");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            var currentTime = DateTime.UtcNow;
            var randomNumber = new Random().Next();

            response.WriteString($"The Current Time: {currentTime}. A random Number: {randomNumber}");

            return response;
        }
    }
}
