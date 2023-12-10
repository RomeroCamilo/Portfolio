using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace portfolio.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public PrivacyModel(ILogger<PrivacyModel> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

