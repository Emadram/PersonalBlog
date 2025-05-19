using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;
using System.Collections.Generic; 
using System.Linq; 

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class EditBlogPostModel : PageModel
{
    private readonly IBlogService _blogService;
    
    [BindProperty]
    public BlogPost Post { get; set; } = new BlogPost();
    
    [BindProperty] 
    public List<int> SelectedCategoryIds { get; set; } = new List<int>();

    public bool IsNew => Post.Id == 0;
    
    public IEnumerable<Category> AllCategories { get; set; } = new List<Category>(); 
    
    [TempData]
    public string? SuccessMessage { get; set; }

    public EditBlogPostModel(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    public IActionResult OnGet(int? id)
    {
        AllCategories = _blogService.GetCategories(); 
        
        if (id.HasValue)
        {
            var existingPost = _blogService.GetPostById(id.Value);
            if (existingPost == null)
            {
                return NotFound();
            }
            Post = existingPost;
            if (Post.PostCategories != null)
            {
                SelectedCategoryIds = Post.PostCategories.Select(pc => pc.CategoryId).ToList();
            }
        }
        else
        {
            Post = new BlogPost
            {
                PublishedDate = DateTime.Now
            };
        }
        
        return Page();
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            AllCategories = _blogService.GetCategories(); 
            return Page();
        }
        
        if (IsNew)
        {
            _blogService.CreatePost(Post, SelectedCategoryIds);
            SuccessMessage = "Blog post created successfully.";
        }
        else
        {
            _blogService.UpdatePost(Post, SelectedCategoryIds);
            SuccessMessage = "Blog post updated successfully.";
        }
        
        return RedirectToPage("/Admin/BlogPosts");
    }
} 