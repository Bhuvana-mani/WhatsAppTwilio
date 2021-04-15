using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace FunctionAppbhu
{
    class JokeHelper
    {
      public static async Task<string> GetJokeAsync()
        {
            var joke = "No joke for you, error occured";
            using (var httpClient=new HttpClient())
            {
                var apiEndPoint = "https://api.chucknorris.io/jokes/random";
                httpClient.BaseAddress = new Uri(apiEndPoint);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseMessage = await httpClient.GetAsync(apiEndPoint);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonContent = await responseMessage.Content.ReadAsStringAsync();
                    dynamic data = JsonConvert.DeserializeObject(jsonContent);
                    joke = data.value;
                }
            }


            return joke;
        }
    }
}
