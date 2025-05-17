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
        
        public News GetNewsById(int id)
        {
            return _context.News.Find(id);
        }
        
        public void CreateNews(News newsItem)
        {
            // Generate a slug if not provided
            if (string.IsNullOrEmpty(newsItem.Slug))
            {
                newsItem.Slug = GenerateSlug(newsItem.Title);
            }
            
            // Set the published date if not provided
            if (newsItem.PublishedDate == default)
            {
                newsItem.PublishedDate = DateTime.Now;
            }
            
            _context.News.Add(newsItem);
            _context.SaveChanges();
        }
        
        public void UpdateNews(News newsItem)
        {
            var existingNews = _context.News.Find(newsItem.Id);
            if (existingNews != null)
            {
                // Update properties
                existingNews.Title = newsItem.Title;
                existingNews.Summary = newsItem.Summary;
                existingNews.Content = newsItem.Content;
                existingNews.ImageUrl = newsItem.ImageUrl;
                existingNews.Source = newsItem.Source;
                existingNews.SourceUrl = newsItem.SourceUrl;
                existingNews.Category = newsItem.Category;
                existingNews.CategoryBadgeColor = newsItem.CategoryBadgeColor;
                
                // Only update slug if it's provided and different
                if (!string.IsNullOrEmpty(newsItem.Slug) && existingNews.Slug != newsItem.Slug)
                {
                    existingNews.Slug = newsItem.Slug;
                }
                
                // Only update IsFeatured if needed
                if (newsItem.IsFeatured && !existingNews.IsFeatured)
                {
                    // Unset any currently featured news
                    var currentFeatured = _context.News.FirstOrDefault(n => n.IsFeatured);
                    if (currentFeatured != null)
                    {
                        currentFeatured.IsFeatured = false;
                    }
                    
                    existingNews.IsFeatured = true;
                }
                
                _context.SaveChanges();
            }
        }
        
        public void DeleteNews(int id)
        {
            var newsItem = _context.News.Find(id);
            if (newsItem != null)
            {
                _context.News.Remove(newsItem);
                _context.SaveChanges();
            }
        }
        
        public void ToggleNewsFeatured(int id)
        {
            var newsItem = _context.News.Find(id);
            if (newsItem != null)
            {
                if (!newsItem.IsFeatured)
                {
                    // Unset any currently featured news
                    var currentFeatured = _context.News.FirstOrDefault(n => n.IsFeatured);
                    if (currentFeatured != null)
                    {
                        currentFeatured.IsFeatured = false;
                    }
                    
                    newsItem.IsFeatured = true;
                }
                else
                {
                    // Unfeature this news item
                    newsItem.IsFeatured = false;
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