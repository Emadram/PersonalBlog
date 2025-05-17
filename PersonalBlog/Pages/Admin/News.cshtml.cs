using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class NewsModel : PageModel
{
    private readonly INewsService _newsService;
    
    public IEnumerable<News> NewsItems { get; set; } = new List<News>();
    public IEnumerable<string> Categories { get; set; } = new List<string>();
    
    [TempData]
    public string? SuccessMessage { get; set; }

    public NewsModel(INewsService newsService)
    {
        _newsService = newsService;
    }
    
    public void OnGet()
    {
        NewsItems = _newsService.GetAllNews();
        Categories = _newsService.GetCategories();
    }
    
    public IActionResult OnPostDelete(int id)
    {
        _newsService.DeleteNews(id);
        
        SuccessMessage = "News item deleted successfully.";
        return RedirectToPage();
    }
    
    public IActionResult OnPostToggleFeatured(int id)
    {
        _newsService.ToggleNewsFeatured(id);
        
        SuccessMessage = "Featured status updated successfully.";
        return RedirectToPage();
    }
} 