using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.Pages.Admin
{
    public class CommentsModel : PageModel
    {
        private readonly IBlogService _blogService;
        
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
        public IEnumerable<Comment> PendingComments { get; set; } = new List<Comment>();
        public IEnumerable<Comment> ApprovedComments { get; set; } = new List<Comment>();
        
        [TempData]
        public string SuccessMessage { get; set; }
        
        [TempData]
        public string ErrorMessage { get; set; }
        
        public CommentsModel(IBlogService blogService)
        {
            _blogService = blogService;
        }
        
        public void OnGet(string filter = "all")
        {
            // Get all comments
            Comments = GetAllComments();
                
            // Filter comments
            PendingComments = Comments.Where(c => !c.IsApproved).ToList();
            ApprovedComments = Comments.Where(c => c.IsApproved).ToList();
        }
        
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
        
        public IActionResult OnPostApprove(int id)
        {
            _blogService.ApproveComment(id);
            SuccessMessage = "Comment approved successfully!";
            return RedirectToPage();
        }
        
        public IActionResult OnPostDelete(int id)
        {
            _blogService.DeleteComment(id);
            SuccessMessage = "Comment deleted successfully!";
            return RedirectToPage();
        }
    }
}
