using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace api
{
    public static class enrol
    {
        [FunctionName("enrol")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string mobile = string.Empty;
            if (req.Body == null) 
            {
                return new BadRequestObjectResult("{'message':'mobile missing'}");
            }
            string requestBody = string.Empty; requestBody=await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            mobile = data?.mobile;//mobile = mobile ?? data?.mobile;

            string responseMessage = string.IsNullOrEmpty(mobile)
                ? $"This HTTP triggered function executed successfully. requestbody.mobile -{data?.mobile}- Pass a name in the query string or in the request body for a personalized response."
                : $"Hello mobile -requestbody.mobile -{data?.mobile}- mobile -{mobile}-. This HTTP triggered function executed successfully.";
            OkObjectResult responseResult = new OkObjectResult(responseMessage);

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(2);
            option.Domain = "coffeeturn.com";
            option.Path = "/";
            option.Secure = true;
            //// Make the cookie available for the browser
            option.HttpOnly = true;

            //// A little non logical way to actually get the HttpResponse (from the HttpRequest and its HttpContext)
            req.HttpContext.Response.Cookies.Append("CoffeeTurnMobile", "021413963", option);
            return responseResult;
        }
    }
}
