using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class EditBlogPostModel : PageModel
{
    private readonly IBlogService _blogService;
    
    [BindProperty]
    public BlogPost Post { get; set; } = new BlogPost();
    
    public bool IsNew => Post.Id == 0;
    
    public IEnumerable<string> Categories { get; set; } = new List<string>();
    
    [TempData]
    public string? SuccessMessage { get; set; }

    public EditBlogPostModel(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    public IActionResult OnGet(int? id)
    {
        Categories = _blogService.GetCategories();
        
        if (id.HasValue)
        {
            // Edit existing post
            var existingPost = _blogService.GetPostById(id.Value);
            if (existingPost == null)
            {
                return NotFound();
            }
            
            Post = existingPost;
        }
        else
        {
            // New post
            Post = new BlogPost
            {
                PublishedDate = DateTime.Now,
                CategoryBadgeColor = "primary",
                ReadMinutes = 5
            };
        }
        
        return Page();
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            Categories = _blogService.GetCategories();
            return Page();
        }
        
        if (IsNew)
        {
            _blogService.CreatePost(Post);
            SuccessMessage = "Blog post created successfully.";
        }
        else
        {
            _blogService.UpdatePost(Post);
            SuccessMessage = "Blog post updated successfully.";
        }
        
        return RedirectToPage("/Admin/BlogPosts");
    }
} 