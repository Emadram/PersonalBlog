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
    }
} 