using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Summary is required")]
        [StringLength(500, ErrorMessage = "Summary cannot be longer than 500 characters")]
        public string Summary { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; } = string.Empty;
        
        public string ImageUrl { get; set; } = string.Empty;
        
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        
        [Display(Name = "Read Time")]
        [Range(1, 60, ErrorMessage = "Read time must be between 1 and 60 minutes")]
        public int ReadMinutes { get; set; } = 5;
        
        [Display(Name = "Comment Count")]
        public int CommentCount { get; set; } = 0;
        
        [Display(Name = "Featured")]
        public bool IsFeatured { get; set; }
        
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; } = string.Empty;
        
        [Display(Name = "Badge Color")]
        public string CategoryBadgeColor { get; set; } = "primary";
        
        public string Slug { get; set; } = string.Empty;
    }
} 