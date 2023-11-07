using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace portfolio.Pages;

public class biographyModel : PageModel
{
    private readonly ILogger<biographyModel> _logger;

    public biographyModel(ILogger<biographyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}