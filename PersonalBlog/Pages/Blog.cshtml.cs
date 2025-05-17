using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages;

public class BlogModel : PageModel
{
    private readonly IBlogService _blogService;

    public BlogPost? FeaturedPost { get; set; }
    public IEnumerable<BlogPost> RecentPosts { get; set; } = new List<BlogPost>();
    public IEnumerable<string> Categories { get; set; } = new List<string>();

    public BlogModel(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public void OnGet()
    {
        FeaturedPost = _blogService.GetFeaturedPost();
        RecentPosts = _blogService.GetRecentPosts(6);
        Categories = _blogService.GetCategories();
    }
} 