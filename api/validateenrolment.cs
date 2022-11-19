using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace api
{
    public static class validateenrolment
    {
        [FunctionName("validateenrolment")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "email","validationcode" })]
        [OpenApiParameter(name: "email", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **email** parameter")]
        [OpenApiParameter(name: "validationcode", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **validationcode** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string email = req.Query["email"];
            string validationcode = req.Query["validationcode"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            email = email ?? data?.email;
            validationcode = validationcode ?? data?.validationcode;

            string responseMessage = (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(validationcode))
                ? "This HTTP triggered function executed successfully. Pass a email and validationcode in the query string or in the request body for a personalized response."
                : $"Hello, {email}-{validationcode}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}

