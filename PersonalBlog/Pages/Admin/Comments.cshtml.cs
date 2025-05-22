using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.Pages.Admin
{
    /// <summary>
    /// Represents the model for the Comments admin page.
    /// </summary>
    public class CommentsModel : PageModel
    {
        private readonly IBlogService _blogService;
        
        /// <summary>
        /// Gets or sets the collection of all comments.
        /// </summary>
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

        /// <summary>
        /// Gets or sets the collection of pending comments.
        /// </summary>
        public IEnumerable<Comment> PendingComments { get; set; } = new List<Comment>();

        /// <summary>
        /// Gets or sets the collection of approved comments.
        /// </summary>
        public IEnumerable<Comment> ApprovedComments { get; set; } = new List<Comment>();
        
        /// <summary>
        /// Gets or sets the success message to be displayed to the user.
        /// </summary>
        [TempData]
        public string SuccessMessage { get; set; }
        
        /// <summary>
        /// Gets or sets the error message to be displayed to the user.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentsModel"/> class.
        /// </summary>
        /// <param name="blogService">The blog service used to manage comments.</param>
        public CommentsModel(IBlogService blogService)
        {
            _blogService = blogService;
        }
        
        /// <summary>
        /// Handles the GET request for the Comments admin page.
        /// </summary>
        /// <param name="filter">Optional filter to apply to the comments list. Defaults to "all".</param>
        /// <remarks>
        /// This method retrieves all comments and then filters them into pending and approved lists.
        /// </remarks>
        public void OnGet(string filter = "all")
        {
            // Get all comments
            Comments = GetAllComments();
                
            // Filter comments
            PendingComments = Comments.Where(c => !c.IsApproved).ToList();
            ApprovedComments = Comments.Where(c => c.IsApproved).ToList();
        }
        
        /// <summary>
        /// Retrieves all comments from all blog posts.
        /// </summary>
        /// <returns>A collection of all comments, ordered by creation date descending.</returns>
        private IEnumerable<Comment> GetAllComments()
        {
            // We need to add a GetAllComments method to IBlogService and implement it
            // For now, let's use GetCommentsByPostId for each post
            var posts = _blogService.GetAllPosts();
            var comments = new List<Comment>();
            
            foreach (var post in posts)
            {
                var postComments = _blogService.GetCommentsByPostId(post.Id);
                comments.AddRange(postComments);
            }
            
            return comments.OrderByDescending(c => c.CreatedAt);
        }
        
        /// <summary>
        /// Handles the POST request to approve a comment.
        /// </summary>
        /// <param name="id">The ID of the comment to approve.</param>
        /// <returns>A redirect to the Comments page.</returns>
        public IActionResult OnPostApprove(int id)
        {
            _blogService.ApproveComment(id);
            SuccessMessage = "Comment approved successfully!";
            return RedirectToPage();
        }
        
        /// <summary>
        /// Handles the POST request to delete a comment.
        /// </summary>
        /// <param name="id">The ID of the comment to delete.</param>
        /// <returns>A redirect to the Comments page.</returns>
        public IActionResult OnPostDelete(int id)
        {
            _blogService.DeleteComment(id);
            SuccessMessage = "Comment deleted successfully!";
            return RedirectToPage();
        }
    }
}