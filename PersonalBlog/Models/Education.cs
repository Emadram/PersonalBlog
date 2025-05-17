using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Education
    {
        public int Id { get; set; }
        
        [Required]
        public string Degree { get; set; } = string.Empty;
        
        [Required]
        public string Institution { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public int Order { get; set; } = 0; // For custom ordering
    }
} 