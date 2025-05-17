using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages;

public class NewsModel : PageModel
{
    private readonly INewsService _newsService;

    public News? FeaturedNews { get; set; }
    public IEnumerable<News> RecentNews { get; set; } = new List<News>();
    public IEnumerable<string> Categories { get; set; } = new List<string>();

    public NewsModel(INewsService newsService)
    {
        _newsService = newsService;
    }

    public void OnGet()
    {
        FeaturedNews = _newsService.GetFeaturedNews();
        // Get all news items, we'll display them in numbered list
        RecentNews = _newsService.GetAllNews().Where(n => !n.IsFeatured).Take(30);
        Categories = _newsService.GetCategories();
    }
} 