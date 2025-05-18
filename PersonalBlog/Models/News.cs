using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class News
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Summary { get; set; } = string.Empty;
        
        public string Content { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public string Source { get; set; } = string.Empty;
        public string SourceUrl { get; set; } = string.Empty;
        public bool IsFeatured { get; set; }
        public string Category { get; set; } = string.Empty;
        public string CategoryBadgeColor { get; set; } = "primary";
        public string Slug { get; set; } = string.Empty;
    }
} 