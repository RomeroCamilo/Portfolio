using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace portfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public string Message { get; private set; } = "";

        // will store the response of the azure function api
        public string FunctionResponse { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            // Make an HTTP request to the Azure Function here
            var client = _httpClientFactory.CreateClient();
            var functionUrl = "https://camiloapi.azurewebsites.net/api/helloWorld?";

            // making an api call and storing the response. 
            HttpResponseMessage response = await client.GetAsync(functionUrl);

            /* if sucessful response, store the response */
            if (response.IsSuccessStatusCode)
            {
                FunctionResponse = await response.Content.ReadAsStringAsync();
            }
            else
            {
                FunctionResponse = "Error: Unable to fetch data from the Azure Function.";
            }

            // Once the response is fetched, you can perform additional actions or display it as needed.
            
            // Example: Appending the current server time to the Message
            Message += $"Server time is {DateTime.Now}";
        }
    }
}

