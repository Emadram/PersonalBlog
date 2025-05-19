using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalBlog.Pages;

public class PostModel : PageModel
{
    private readonly IBlogService _blogService;

    public BlogPost? Post { get; set; }
    public IEnumerable<Category> AllCategories { get; set; } = new List<Category>();
    public IEnumerable<Comment> ApprovedComments { get; set; } = new List<Comment>();
    
    [BindProperty]
    public Comment NewComment { get; set; } = new Comment();
    
    public string SuccessMessage { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    
    public PostModel(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    public IActionResult OnGet(string slug, bool success = false)
    {
        if (string.IsNullOrEmpty(slug))
        {
            return RedirectToPage("/Blog");
        }
        
        try
        {
            Post = _blogService.GetPostBySlug(slug);
            
            if (Post == null)
            {
                return NotFound();
            }
            
            AllCategories = _blogService.GetCategories();
            
            // Get approved comments for this post
            if (Post.Id > 0)
            {
                ApprovedComments = _blogService.GetCommentsByPostId(Post.Id);
            }
            
            // Check if we're coming back after successful comment submission
            if (success)
            {
                SuccessMessage = "Your comment has been submitted successfully!";
            }
            
            return Page();
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine($"Error in OnGet: {ex.Message}");
            ErrorMessage = "An error occurred while loading the post. Please try again.";
            return RedirectToPage("/Blog");
        }
    }
    
    public IActionResult OnPost(string slug)
    {
        try
        {
            if (string.IsNullOrEmpty(slug))
            {
                return RedirectToPage("/Blog");
            }
            
            Post = _blogService.GetPostBySlug(slug);
            
            if (Post == null)
            {
                return NotFound();
            }
            
            // Get categories and comments regardless of model state
            AllCategories = _blogService.GetCategories();
            ApprovedComments = _blogService.GetCommentsByPostId(Post.Id);
            
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please fix the errors in the form before submitting.";
                return Page();
            }
            
            // Set properties not provided in the form
            NewComment.BlogPostId = Post.Id;
            NewComment.CreatedAt = DateTime.Now;
            NewComment.IsApproved = true; // Auto-approve for testing purposes
            
            // Add the comment
            _blogService.AddComment(NewComment);
            
            // Redirect with success parameter
            return RedirectToPage("/Post", new { slug = slug, success = true });
        }
        catch (Exception ex)
        {
            // Log the error
            Console.WriteLine($"Error in OnPost: {ex.Message}");
            ErrorMessage = "There was an error submitting your comment. Please try again.";
            
            // Ensure we have data for the page
            if (Post != null)
            {
                AllCategories = _blogService.GetCategories();
                ApprovedComments = _blogService.GetCommentsByPostId(Post.Id);
            }
            
            return Page();
        }
    }
}
