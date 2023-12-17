using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

// razor page index page.

namespace portfolio.Pages
{
    public class ContactModel : PageModel
    {
        private readonly ILogger<ContactModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;


        public string Message { get; private set; } = "";

        public ContactModel(ILogger<ContactModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync(string email, string name)
        {
            // This method is executed when the form is submitted with a POST request

            // Assuming you have an HTTP endpoint link from Azure
            string azureEndpoint = "https://pythonapiservices.azurewebsites.net/api/Upsert";

            // Prepare the data to be sent in the request body
            var data = new
            {
                Email = email,
                Name = name
            };

            // Convert the data to a JSON string using System.Text.Json
            string jsonData = System.Text.Json.JsonSerializer.Serialize(data);

            // Create a HttpClient instance
            using (HttpClient client = new HttpClient())
            {
                // Create the HttpContent with JSON data
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send the POST request to the Azure endpoint
                HttpResponseMessage response = await client.PostAsync(azureEndpoint, content);

            // Check if the request was successful (status code 2xx)
                if (response.IsSuccessStatusCode)
                {
                    // Set a message to be displayed in the view
                    return RedirectToPage("/Contact");
                }
                else
                {
                    // Set an error message if needed
                    return RedirectToPage("/Contact");
                }

            }
        }
    }
}