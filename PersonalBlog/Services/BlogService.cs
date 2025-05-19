using PersonalBlog.Data;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PersonalBlog.Services
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BlogPost> GetAllPosts()
        {
            return _context.BlogPosts
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .OrderByDescending(p => p.PublishedDate)
                .ToList();
        }

        public IEnumerable<BlogPost> GetRecentPosts(int count)
        {
            return _context.BlogPosts
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .OrderByDescending(p => p.PublishedDate)
                .Take(count)
                .ToList();
        }

        public BlogPost? GetFeaturedPost()
        {
            return _context.BlogPosts
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .FirstOrDefault(p => p.IsFeatured);
        }

        public BlogPost? GetPostBySlug(string slug)
        {
            return _context.BlogPosts
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .FirstOrDefault(p => p.Slug == slug);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.Name).ToList();
        }

        public IEnumerable<BlogPost> GetPostsByCategory(int categoryId)
        {
            return _context.BlogPosts
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .Where(p => p.PostCategories.Any(pc => pc.CategoryId == categoryId))
                .OrderByDescending(p => p.PublishedDate)
                .ToList();
        }
        
        public BlogPost? GetPostById(int id)
        {
            return _context.BlogPosts
                .Include(p => p.PostCategories)
                    .ThenInclude(pc => pc.Category)
                .FirstOrDefault(p => p.Id == id);
        }
        
        public void CreatePost(BlogPost post, List<int> selectedCategoryIds)
        {
            if (string.IsNullOrEmpty(post.Slug))
            {
                post.Slug = GenerateSlug(post.Title);
            }
            
            if (post.PublishedDate == default)
            {
                post.PublishedDate = DateTime.Now;
            }
            
            _context.BlogPosts.Add(post);
            _context.SaveChanges();

            if (selectedCategoryIds != null && selectedCategoryIds.Any())
            {
                foreach (var categoryId in selectedCategoryIds)
                {
                    _context.PostCategories.Add(new PostCategory { BlogPostId = post.Id, CategoryId = categoryId });
                }
                _context.SaveChanges();
            }
        }
        
        public void UpdatePost(BlogPost post, List<int> selectedCategoryIds)
        {
            var existingPost = _context.BlogPosts
                                    .Include(p => p.PostCategories)
                                    .FirstOrDefault(p => p.Id == post.Id);

            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Summary = post.Summary;
                existingPost.Content = post.Content;
                existingPost.ImageUrl = post.ImageUrl;
                
                if (!string.IsNullOrEmpty(post.Slug) && existingPost.Slug != post.Slug)
                {
                    existingPost.Slug = post.Slug;
                }
                else if (string.IsNullOrEmpty(existingPost.Slug))
                {
                    existingPost.Slug = GenerateSlug(existingPost.Title);
                }
                
                if (post.IsFeatured && !existingPost.IsFeatured)
                {
                    var currentFeatured = _context.BlogPosts.FirstOrDefault(p => p.IsFeatured && p.Id != existingPost.Id);
                    if (currentFeatured != null)
                    {
                        currentFeatured.IsFeatured = false;
                    }
                    existingPost.IsFeatured = true;
                }
                else if (!post.IsFeatured && existingPost.IsFeatured)
                {
                    existingPost.IsFeatured = false;
                }
                
                existingPost.ReadMinutes = post.ReadMinutes;
                existingPost.PublishedDate = post.PublishedDate;

                existingPost.PostCategories.Clear();
                if (selectedCategoryIds != null && selectedCategoryIds.Any())
                {
                    foreach (var categoryId in selectedCategoryIds)
                    {
                        existingPost.PostCategories.Add(new PostCategory { CategoryId = categoryId });
                    }
                }
                
                _context.SaveChanges();
            }
        }
        
        public void DeletePost(int id)
        {
            try
            {
                // Get the post with its relationships
                var post = _context.BlogPosts
                    .Include(p => p.PostCategories)
                    .Include(p => p.Comments)
                    .FirstOrDefault(p => p.Id == id);

                if (post != null)
                {
                    // Start a transaction to ensure all operations complete or none do
                    using (var transaction = _context.Database.BeginTransaction())
                    {
                        try
                        {
                            // First, remove any comments associated with this post
                            if (post.Comments != null && post.Comments.Any())
                            {
                                _context.Comments.RemoveRange(post.Comments);
                                _context.SaveChanges();
                            }

                            // Then remove all related PostCategories
                            if (post.PostCategories != null && post.PostCategories.Any())
                            {
                                _context.PostCategories.RemoveRange(post.PostCategories);
                                _context.SaveChanges();
                            }

                            // Finally remove the post itself
                            _context.BlogPosts.Remove(post);
                            _context.SaveChanges();

                            // Commit the transaction
                            transaction.Commit();
                        }
                        catch
                        {
                            // If anything goes wrong, roll back all changes
                            transaction.Rollback();
                            throw; // Re-throw to handle at the caller level
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception - in a real app, you'd use proper logging
                Console.WriteLine($"Error deleting post {id}: {ex.Message}");
                throw; // Re-throw so the caller knows something went wrong
            }
        }
        
        public void TogglePostFeatured(int id)
        {
            var post = _context.BlogPosts.Find(id);
            if (post != null)
            {
                if (!post.IsFeatured)
                {
                    var currentFeatured = _context.BlogPosts.FirstOrDefault(p => p.IsFeatured);
                    if (currentFeatured != null)
                    {
                        currentFeatured.IsFeatured = false;
                    }
                    
                    post.IsFeatured = true;
                }
                else
                {
                    post.IsFeatured = false;
                }
                
                _context.SaveChanges();
            }
        }
        
        private string GenerateSlug(string title)
        {
            var slug = title.ToLower().Replace(" ", "-");
            
            slug = new string(slug.Where(c => char.IsLetterOrDigit(c) || c == '-').ToArray());
            
            return slug;
        }
        
        // Comment operations
        public IEnumerable<Comment> GetCommentsByPostId(int postId)
        {
            return _context.Comments
                .Where(c => c.BlogPostId == postId && c.IsApproved)
                .OrderByDescending(c => c.CreatedAt)
                .ToList();
        }
        
        public void AddComment(Comment comment)
        {
            // Save the comment
            _context.Comments.Add(comment);
            
            // Update the comment count on the post
            var post = _context.BlogPosts.Find(comment.BlogPostId);
            if (post != null)
            {
                // Only increment the count if the comment is auto-approved
                // Otherwise, it will be incremented when the comment is approved
                if (comment.IsApproved)
                {
                    post.CommentCount++;
                }
            }
            
            _context.SaveChanges();
        }
        
        public void ApproveComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment != null && !comment.IsApproved)
            {
                comment.IsApproved = true;
                
                // Increment the comment count on the post
                var post = _context.BlogPosts.Find(comment.BlogPostId);
                if (post != null)
                {
                    post.CommentCount++;
                }
                
                _context.SaveChanges();
            }
        }
        
        public void DeleteComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment != null)
            {
                // Decrement the comment count on the post if the comment was approved
                if (comment.IsApproved)
                {
                    var post = _context.BlogPosts.Find(comment.BlogPostId);
                    if (post != null && post.CommentCount > 0)
                    {
                        post.CommentCount--;
                    }
                }
                
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
        }
    }
}
