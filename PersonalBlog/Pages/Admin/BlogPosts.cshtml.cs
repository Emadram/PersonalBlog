using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; 
using PersonalBlog.Models;
using PersonalBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class BlogPostsModel : PageModel
{
    private readonly IBlogService _blogService;
    
    public IEnumerable<BlogPost> Posts { get; set; } = new List<BlogPost>();
    public IEnumerable<Category> Categories { get; set; } = new List<Category>(); 
    
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
    
    public IActionResult OnPostBulkDelete(string ids)
    {
        try
        {
            if (!string.IsNullOrEmpty(ids))
            {
                // Parse the JSON array of ids
                var postIds = JsonSerializer.Deserialize<List<int>>(ids);
                
                if (postIds != null && postIds.Any())
                {
                    int count = 0;
                    foreach (var id in postIds)
                    {
                        _blogService.DeletePost(id);
                        count++;
                    }
                    
                    SuccessMessage = $"{count} post{(count > 1 ? "s" : "")} deleted successfully.";
                }
            }
        }
        catch (Exception ex)
        {
            // Log the error - in a real app you'd use a logger
            Console.WriteLine($"Error in bulk delete: {ex.Message}");
            ModelState.AddModelError(string.Empty, "An error occurred while deleting posts.");
        }
        
        return RedirectToPage();
    }
} 