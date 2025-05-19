using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        public bool IsApproved { get; set; } = false;
        
        // Foreign key for BlogPost
        public int BlogPostId { get; set; }
        
        // Navigation property
        public BlogPost? BlogPost { get; set; }
    }
}
