using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OldEF6Library;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace CoreFunction
{
    public static class UserCountFunction
    {
        [FunctionName("UserCount")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "UserCount")] HttpRequest req,
            ILogger log)
        {
            
            var oldEFClass = new OldEF6Class();
            OldEF6Class.ConnectionString = Environment.GetEnvironmentVariable("UserEntitiesConnectionString");
            var userCount = oldEFClass.GetUserCount();

            string responseMessage = $"User Count from DB via EF: {userCount}";
            return new OkObjectResult(responseMessage);
        }
    }
}
