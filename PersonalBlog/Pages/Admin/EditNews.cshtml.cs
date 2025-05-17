using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class EditNewsModel : PageModel
{
    private readonly INewsService _newsService;
    
    [BindProperty]
    public News NewsItem { get; set; } = new News();
    
    public bool IsNew => NewsItem.Id == 0;
    
    public IEnumerable<string> Categories { get; set; } = new List<string>();
    
    [TempData]
    public string? SuccessMessage { get; set; }

    public EditNewsModel(INewsService newsService)
    {
        _newsService = newsService;
    }
    
    public IActionResult OnGet(int? id)
    {
        Categories = _newsService.GetCategories();
        
        if (id.HasValue)
        {
            // Edit existing news item
            var existingNews = _newsService.GetNewsById(id.Value);
            if (existingNews == null)
            {
                return NotFound();
            }
            
            NewsItem = existingNews;
        }
        else
        {
            // New news item
            NewsItem = new News
            {
                PublishedDate = DateTime.Now,
                CategoryBadgeColor = "primary",
                Source = "Personal Blog"
            };
        }
        
        return Page();
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            Categories = _newsService.GetCategories();
            return Page();
        }
        
        if (IsNew)
        {
            _newsService.CreateNews(NewsItem);
            SuccessMessage = "News item created successfully.";
        }
        else
        {
            _newsService.UpdateNews(NewsItem);
            SuccessMessage = "News item updated successfully.";
        }
        
        return RedirectToPage("/Admin/News");
    }
} 