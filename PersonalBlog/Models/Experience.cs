using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Experience
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Company { get; set; }
        
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // Nullable for current positions
        public string Technologies { get; set; } // Comma-separated list of technologies
        public int Order { get; set; } // For custom ordering
    }
} 