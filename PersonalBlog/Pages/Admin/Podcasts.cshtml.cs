using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class PodcastsModel : PageModel
{
    private readonly IPodcastService _podcastService;
    
    public IEnumerable<PodcastEpisode> Episodes { get; set; } = new List<PodcastEpisode>();
    public IEnumerable<string> Categories { get; set; } = new List<string>();
    
    [TempData]
    public string? SuccessMessage { get; set; }

    public PodcastsModel(IPodcastService podcastService)
    {
        _podcastService = podcastService;
    }
    
    public void OnGet()
    {
        Episodes = _podcastService.GetAllEpisodes();
        Categories = _podcastService.GetCategories();
    }
    
    public IActionResult OnPostDelete(int id)
    {
        _podcastService.DeleteEpisode(id);
        
        SuccessMessage = "Episode deleted successfully.";
        return RedirectToPage();
    }
    
    public IActionResult OnPostToggleFeatured(int id)
    {
        _podcastService.ToggleEpisodeFeatured(id);
        
        SuccessMessage = "Featured status updated successfully.";
        return RedirectToPage();
    }
} 