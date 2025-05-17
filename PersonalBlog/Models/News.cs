using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class News
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Summary { get; set; }
        
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Source { get; set; }
        public string SourceUrl { get; set; }
        public bool IsFeatured { get; set; }
        public string Category { get; set; }
        public string CategoryBadgeColor { get; set; }
        public string Slug { get; set; }
    }
} 