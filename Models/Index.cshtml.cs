using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace portfolio.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    
    // public string variable. get is used to allow retrieving the message outside of the class
    // private set means that we can only modify this string message within this class. 
    public string Message { get; private set; } = "";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        // once we are loaded into the biography page. 
        Message += $" Server time is { DateTime.Now }";
    }
}
