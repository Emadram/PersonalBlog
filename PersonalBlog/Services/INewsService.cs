using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public interface INewsService
    {
        IEnumerable<News> GetAllNews();
        IEnumerable<News> GetRecentNews(int count);
        News GetFeaturedNews();
        News GetNewsBySlug(string slug);
        IEnumerable<string> GetCategories();
        IEnumerable<News> GetNewsByCategory(string category);
    }
} 