using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalBlog.Pages;

public class BlogModel : PageModel
{
    private readonly ILogger<BlogModel> _logger;

    public BlogModel(ILogger<BlogModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
} 