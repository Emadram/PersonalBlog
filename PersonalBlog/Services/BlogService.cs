using PersonalBlog.Data;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.BlogPosts.OrderByDescending(p => p.PublishedDate).ToList();
        }

        public IEnumerable<BlogPost> GetRecentPosts(int count)
        {
            return _context.BlogPosts.OrderByDescending(p => p.PublishedDate).Take(count).ToList();
        }

        public BlogPost GetFeaturedPost()
        {
            return _context.BlogPosts.FirstOrDefault(p => p.IsFeatured);
        }

        public BlogPost GetPostBySlug(string slug)
        {
            return _context.BlogPosts.FirstOrDefault(p => p.Slug == slug);
        }

        public IEnumerable<string> GetCategories()
        {
            return _context.BlogPosts.Select(p => p.Category).Distinct().ToList();
        }

        public IEnumerable<BlogPost> GetPostsByCategory(string category)
        {
            return _context.BlogPosts.Where(p => p.Category == category).OrderByDescending(p => p.PublishedDate).ToList();
        }
        
        public BlogPost GetPostById(int id)
        {
            return _context.BlogPosts.Find(id);
        }
        
        public void CreatePost(BlogPost post)
        {
            // Generate a slug if not provided
            if (string.IsNullOrEmpty(post.Slug))
            {
                post.Slug = GenerateSlug(post.Title);
            }
            
            // Set the published date if not provided
            if (post.PublishedDate == default)
            {
                post.PublishedDate = DateTime.Now;
            }
            
            _context.BlogPosts.Add(post);
            _context.SaveChanges();
        }
        
        public void UpdatePost(BlogPost post)
        {
            var existingPost = _context.BlogPosts.Find(post.Id);
            if (existingPost != null)
            {
                // Update properties
                existingPost.Title = post.Title;
                existingPost.Summary = post.Summary;
                existingPost.Content = post.Content;
                existingPost.ImageUrl = post.ImageUrl;
                existingPost.Category = post.Category;
                existingPost.CategoryBadgeColor = post.CategoryBadgeColor;
                
                // Only update slug if it's provided and different
                if (!string.IsNullOrEmpty(post.Slug) && existingPost.Slug != post.Slug)
                {
                    existingPost.Slug = post.Slug;
                }
                
                // Only update IsFeatured if needed
                if (post.IsFeatured && !existingPost.IsFeatured)
                {
                    // Unset any currently featured post
                    var currentFeatured = _context.BlogPosts.FirstOrDefault(p => p.IsFeatured);
                    if (currentFeatured != null)
                    {
                        currentFeatured.IsFeatured = false;
                    }
                    
                    existingPost.IsFeatured = true;
                }
                
                existingPost.ReadMinutes = post.ReadMinutes;
                existingPost.CommentCount = post.CommentCount;
                
                _context.SaveChanges();
            }
        }
        
        public void DeletePost(int id)
        {
            var post = _context.BlogPosts.Find(id);
            if (post != null)
            {
                _context.BlogPosts.Remove(post);
                _context.SaveChanges();
            }
        }
        
        public void TogglePostFeatured(int id)
        {
            var post = _context.BlogPosts.Find(id);
            if (post != null)
            {
                if (!post.IsFeatured)
                {
                    // Unset any currently featured post
                    var currentFeatured = _context.BlogPosts.FirstOrDefault(p => p.IsFeatured);
                    if (currentFeatured != null)
                    {
                        currentFeatured.IsFeatured = false;
                    }
                    
                    post.IsFeatured = true;
                }
                else
                {
                    // Unfeature this post
                    post.IsFeatured = false;
                }
                
                _context.SaveChanges();
            }
        }
        
        private string GenerateSlug(string title)
        {
            // Simple slug generation - replace spaces with dashes and make lowercase
            var slug = title.ToLower().Replace(" ", "-");
            
            // Remove any special characters
            slug = new string(slug.Where(c => char.IsLetterOrDigit(c) || c == '-').ToArray());
            
            return slug;
        }
    }
} 