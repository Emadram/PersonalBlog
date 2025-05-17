using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Experience
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Company { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } // Nullable for current positions
        public string Technologies { get; set; } = string.Empty; // Comma-separated list of technologies
        public int Order { get; set; } = 0; // For custom ordering
    }
} 