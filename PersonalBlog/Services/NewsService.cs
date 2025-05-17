using PersonalBlog.Data;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Services
{
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext _context;

        public NewsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<News> GetAllNews()
        {
            return _context.News.OrderByDescending(n => n.PublishedDate).ToList();
        }

        public IEnumerable<News> GetRecentNews(int count)
        {
            return _context.News.OrderByDescending(n => n.PublishedDate).Take(count).ToList();
        }

        public News GetFeaturedNews()
        {
            return _context.News.FirstOrDefault(n => n.IsFeatured);
        }

        public News GetNewsBySlug(string slug)
        {
            return _context.News.FirstOrDefault(n => n.Slug == slug);
        }

        public IEnumerable<string> GetCategories()
        {
            return _context.News.Select(n => n.Category).Distinct().ToList();
        }

        public IEnumerable<News> GetNewsByCategory(string category)
        {
            return _context.News.Where(n => n.Category == category).OrderByDescending(n => n.PublishedDate).ToList();
        }
    }
} 