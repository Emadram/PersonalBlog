using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public enum ProficiencyLevel
    {
        Learning,
        Beginner,
        Elementary,
        Intermediate,
        Advanced,
        Expert,
        Master
    }
    
    public class SkillCategory
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        public int Order { get; set; } = 0;
    }
    
    public class Skill
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public int Proficiency { get; set; } = 0; // 0-100
        public ProficiencyLevel ProficiencyLevel { get; set; } = ProficiencyLevel.Intermediate;
        public string Category { get; set; } = string.Empty; // Legacy field - will be migrated
        public int? CategoryId { get; set; } // New relationship to SkillCategory
        public string IconClass { get; set; } = string.Empty; // For FontAwesome icons
        public string IconColor { get; set; } = string.Empty; // Custom color for the icon (hex code or CSS color name)
    }
} 