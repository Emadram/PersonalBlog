using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Education
    {
        public int Id { get; set; }
        
        [Required]
        public string Degree { get; set; }
        
        [Required]
        public string Institution { get; set; }
        
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Order { get; set; } // For custom ordering
    }
} 