using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PersonalBlog.Pages;

public class PodcastModel : PageModel
{
    private readonly ILogger<PodcastModel> _logger;

    public PodcastModel(ILogger<PodcastModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
} 