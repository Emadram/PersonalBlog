using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages;

public class PodcastModel : PageModel
{
    private readonly IPodcastService _podcastService;

    public PodcastEpisode FeaturedEpisode { get; set; }
    public IEnumerable<PodcastEpisode> RecentEpisodes { get; set; }
    public IEnumerable<string> Categories { get; set; }

    public PodcastModel(IPodcastService podcastService)
    {
        _podcastService = podcastService;
    }

    public void OnGet()
    {
        FeaturedEpisode = _podcastService.GetFeaturedEpisode();
        RecentEpisodes = _podcastService.GetRecentEpisodes(5);
        Categories = _podcastService.GetCategories();
    }
} 