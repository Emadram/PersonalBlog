using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    /// <summary>
    /// Represents a news article or announcement.
    /// </summary>
    public class News
    {
        /// <summary>
        /// Gets or sets the unique identifier for the news article.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the headline or title of the news article.
        /// </summary>
        [Required]
        public string Title { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets a brief summary of the news article.
        /// </summary>
        [Required]
        public string Summary { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the full content of the news article.
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the URL of the featured image for the news article.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date when the news article was published.
        /// </summary>
        public DateTime PublishedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the name of the news source.
        /// </summary>
        public string Source { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the URL of the original news source.
        /// </summary>
        public string SourceUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets whether this news article is featured.
        /// </summary>
        public bool IsFeatured { get; set; }

        /// <summary>
        /// Gets or sets the category of the news article.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Bootstrap color class for the category badge.
        /// </summary>
        /// <remarks>
        /// Uses Bootstrap color classes (e.g., "primary", "success", "warning", etc.).
        /// </remarks>
        public string CategoryBadgeColor { get; set; } = "primary";

        /// <summary>
        /// Gets or sets the URL-friendly slug for the news article.
        /// </summary>
        public string Slug { get; set; } = string.Empty;
    }
}