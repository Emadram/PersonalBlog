using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Skill
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public int Proficiency { get; set; } = 0; // 0-100
        public string Category { get; set; } = string.Empty; // e.g., "Programming Languages", "Frameworks & Tools"
        public string IconClass { get; set; } = string.Empty; // For FontAwesome icons
        public string IconColor { get; set; } = string.Empty; // Custom color for the icon (hex code or CSS color name)
    }
} 