using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Twilio;
using Twilio.TwiML;
namespace FunctionAppbhu
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            var joke = await JokeHelper.GetJokeAsync();
            var response = new MessagingResponse().Message(joke);

            var twiml = response.ToString();

            return new ContentResult
            {
                Content = twiml,
                ContentType = "application/xml"
            };


            
        }
    }
}

