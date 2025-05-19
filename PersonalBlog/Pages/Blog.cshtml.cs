using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;
using System.Collections.Generic; 
using System.Linq; 

namespace PersonalBlog.Pages;

public class BlogModel : PageModel
{
    private readonly IBlogService _blogService;

    public BlogPost? FeaturedPost { get; set; }
    public IEnumerable<BlogPost> PostsToDisplay { get; set; } = new List<BlogPost>(); 
    public IEnumerable<Category> AllCategories { get; set; } = new List<Category>(); 
    public Category? CurrentCategory { get; set; } 

    public BlogModel(IBlogService blogService)
    {
        _blogService = blogService;
    }

    public void OnGet([FromQuery] int? categoryId) 
    {
        FeaturedPost = _blogService.GetFeaturedPost();
        AllCategories = _blogService.GetCategories(); 

        if (categoryId.HasValue && categoryId.Value > 0)
        {
            PostsToDisplay = _blogService.GetPostsByCategory(categoryId.Value);
            CurrentCategory = AllCategories.FirstOrDefault(c => c.Id == categoryId.Value);
        }
        else
        {
            PostsToDisplay = _blogService.GetRecentPosts(6);
            CurrentCategory = null;
        }
    }
} 