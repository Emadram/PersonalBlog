using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class BlogPostsModel : PageModel
{
    private readonly IBlogService _blogService;
    
    public IEnumerable<BlogPost> Posts { get; set; } = new List<BlogPost>();
    public IEnumerable<string> Categories { get; set; } = new List<string>();
    
    [TempData]
    public string? SuccessMessage { get; set; }

    public BlogPostsModel(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    public void OnGet()
    {
        Posts = _blogService.GetAllPosts();
        Categories = _blogService.GetCategories();
    }
    
    public IActionResult OnPostDelete(int id)
    {
        _blogService.DeletePost(id);
        
        SuccessMessage = "Post deleted successfully.";
        return RedirectToPage();
    }
    
    public IActionResult OnPostToggleFeatured(int id)
    {
        _blogService.TogglePostFeatured(id);
        
        SuccessMessage = "Featured status updated successfully.";
        return RedirectToPage();
    }
} 