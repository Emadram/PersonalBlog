using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class IndexModel : PageModel
{
    public string WelcomeMessage { get; set; } = string.Empty;
    
    public void OnGet()
    {
        WelcomeMessage = $"Welcome, {User.Identity?.Name}! Use the cards below to manage your website content.";
    }
} 