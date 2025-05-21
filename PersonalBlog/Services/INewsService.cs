using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    /// <summary>
    /// Provides functionality for managing news articles and announcements.
    /// </summary>
    public interface INewsService
    {
        /// <summary>
        /// Retrieves all news articles ordered by publish date.
        /// </summary>
        /// <returns>A collection of all news articles.</returns>
        IEnumerable<News> GetAllNews();

        /// <summary>
        /// Retrieves the most recent news articles.
        /// </summary>
        /// <param name="count">The number of articles to retrieve.</param>
        /// <returns>A collection of the most recent news articles.</returns>
        IEnumerable<News> GetRecentNews(int count);

        /// <summary>
        /// Retrieves the currently featured news article.
        /// </summary>
        /// <returns>The featured news article, or null if no article is featured.</returns>
        News? GetFeaturedNews();

        /// <summary>
        /// Retrieves a news article by its URL slug.
        /// </summary>
        /// <param name="slug">The URL-friendly slug of the news article.</param>
        /// <returns>The matching news article, or null if not found.</returns>
        News? GetNewsBySlug(string slug);

        /// <summary>
        /// Retrieves all news categories.
        /// </summary>
        /// <returns>A collection of distinct category names.</returns>
        IEnumerable<string> GetCategories();

        /// <summary>
        /// Retrieves all news articles in a specific category.
        /// </summary>
        /// <param name="category">The category name to filter by.</param>
        /// <returns>A collection of news articles in the specified category.</returns>
        IEnumerable<News> GetNewsByCategory(string category);
        
        /// <summary>
        /// Retrieves a news article by its ID.
        /// </summary>
        /// <param name="id">The ID of the news article to retrieve.</param>
        /// <returns>The matching news article, or null if not found.</returns>
        News? GetNewsById(int id);

        /// <summary>
        /// Creates a new news article.
        /// </summary>
        /// <param name="newsItem">The news article to create.</param>
        /// <remarks>
        /// If no slug is provided, one will be generated from the title.
        /// If no publish date is provided, the current date will be used.
        /// </remarks>
        void CreateNews(News newsItem);

        /// <summary>
        /// Updates an existing news article.
        /// </summary>
        /// <param name="newsItem">The updated news article information.</param>
        void UpdateNews(News newsItem);

        /// <summary>
        /// Deletes a news article.
        /// </summary>
        /// <param name="id">The ID of the news article to delete.</param>
        void DeleteNews(int id);

        /// <summary>
        /// Toggles the featured status of a news article.
        /// </summary>
        /// <param name="id">The ID of the news article to toggle.</param>
        /// <remarks>
        /// When an article is featured, any previously featured article is automatically unfeatured.
        /// </remarks>
        void ToggleNewsFeatured(int id);
    }
}