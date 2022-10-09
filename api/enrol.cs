using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CoffeeTurn.Identity
{
    public static class enrol
    {
        [FunctionName("enrol")]
        public static async Task<IActionResult> Run(
            [HttpTrigger( AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string mobile = string.Empty;
            if (req.Query.Count>0) 
            {
                mobile = req.Query["mobile"]; 
            }

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            //mobile = mobile ?? data?.mobile;

            string responseMessage = string.IsNullOrEmpty(mobile)
                ? $"This HTTP triggered function executed successfully. requestbody.mobile -{data?.mobile}- Pass a name in the query string or in the request body for a personalized response."
                : $"Hello mobile -requestbody.mobile -{data?.mobile}- mobile -{mobile}-. This HTTP triggered function executed successfully.";
            resultObject = new OkObjectResult(responseMessage);
            resultObject

            var response = Request.CreateResponse<string>(
                HttpStatusCode.OK,responseMessage
            );

            var cookie = new CookieHeaderValue("IEM", "Success");
            cookie.Expires = DateTimeOffset.Now.AddMinutes(60);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });

            return response;

 //           return new OkObjectResult(responseMessage);
        }
    }
}
