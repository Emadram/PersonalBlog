using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class EditPodcastModel : PageModel
{
    private readonly IPodcastService _podcastService;
    
    [BindProperty]
    public PodcastEpisode Episode { get; set; } = new PodcastEpisode();
    
    public bool IsNew => Episode.Id == 0;
    
    public IEnumerable<string> Categories { get; set; } = new List<string>();
    
    [TempData]
    public string? SuccessMessage { get; set; }

    public EditPodcastModel(IPodcastService podcastService)
    {
        _podcastService = podcastService;
    }
    
    public IActionResult OnGet(int? id)
    {
        Categories = _podcastService.GetCategories();
        
        if (id.HasValue)
        {
            // Edit existing episode
            var existingEpisode = _podcastService.GetEpisodeById(id.Value);
            if (existingEpisode == null)
            {
                return NotFound();
            }
            
            Episode = existingEpisode;
        }
        else
        {
            // New episode
            Episode = new PodcastEpisode
            {
                PublishedDate = DateTime.Now,
                CategoryBadgeColor = "primary",
                DurationMinutes = 30,
                EpisodeNumber = 1
            };
        }
        
        return Page();
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            Categories = _podcastService.GetCategories();
            return Page();
        }
        
        if (IsNew)
        {
            _podcastService.CreateEpisode(Episode);
            SuccessMessage = "Podcast episode created successfully.";
        }
        else
        {
            _podcastService.UpdateEpisode(Episode);
            SuccessMessage = "Podcast episode updated successfully.";
        }
        
        return RedirectToPage("/Admin/Podcasts");
    }
} 