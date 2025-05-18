using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public interface INewsService
    {
        IEnumerable<News> GetAllNews();
        IEnumerable<News> GetRecentNews(int count);
        News? GetFeaturedNews();
        News? GetNewsBySlug(string slug);
        IEnumerable<string> GetCategories();
        IEnumerable<News> GetNewsByCategory(string category);
        
        // CRUD operations
        News? GetNewsById(int id);
        void CreateNews(News newsItem);
        void UpdateNews(News newsItem);
        void DeleteNews(int id);
        void ToggleNewsFeatured(int id);
    }
} 