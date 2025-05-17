using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages;

public class NewsModel : PageModel
{
    private readonly INewsService _newsService;

    public News FeaturedNews { get; set; }
    public IEnumerable<News> RecentNews { get; set; }
    public IEnumerable<string> Categories { get; set; }

    public NewsModel(INewsService newsService)
    {
        _newsService = newsService;
    }

    public void OnGet()
    {
        FeaturedNews = _newsService.GetFeaturedNews();
        RecentNews = _newsService.GetRecentNews(6);
        Categories = _newsService.GetCategories();
    }
} 