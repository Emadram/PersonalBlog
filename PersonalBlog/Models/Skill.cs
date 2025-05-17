using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Skill
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public int Proficiency { get; set; } // 0-100
        public string Category { get; set; } // e.g., "Programming Languages", "Frameworks & Tools"
        public string IconClass { get; set; } // For FontAwesome icons
    }
} 