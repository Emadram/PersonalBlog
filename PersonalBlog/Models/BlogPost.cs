using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Summary { get; set; }
        
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public int ReadMinutes { get; set; }
        public int CommentCount { get; set; }
        public bool IsFeatured { get; set; }
        public string Category { get; set; }
        public string CategoryBadgeColor { get; set; } // Bootstrap color class (primary, success, etc.)
        public string Slug { get; set; } // URL-friendly version of the title
    }
} 