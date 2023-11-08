using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace portfolio.Pages;

public class biographyModel : PageModel
{
    private readonly ILogger<biographyModel> _logger;

    public string Message { get; private set; } = "PageModel in C#";

    public biographyModel(ILogger<biographyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        // once we are loaded into the biography page. 
        Message += $" Server time is { DateTime.Now }";
    }
}