using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages;

public class BlogModel : PageModel
{
    private readonly IBlogService _blogService;

    public BlogPost FeaturedPost { get; set; }
    public IEnumerable<BlogPost> RecentPosts { get; set; }
    public IEnumerable<string> Categories { get; set; }

    public BlogModel(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public void OnGet()
    {
        FeaturedPost = _blogService.GetFeaturedPost();
        RecentPosts = _blogService.GetRecentPosts(4);
        Categories = _blogService.GetCategories();
    }
} 