using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    /// <summary>
    /// Represents different levels of skill proficiency.
    /// </summary>
    public enum ProficiencyLevel
    {
        /// <summary>
        /// Currently learning or starting to learn the skill.
        /// </summary>
        Learning,

        /// <summary>
        /// Basic understanding with limited practical experience.
        /// </summary>
        Beginner,

        /// <summary>
        /// Fundamental understanding with some practical experience.
        /// </summary>
        Elementary,

        /// <summary>
        /// Good working knowledge with regular practical application.
        /// </summary>
        Intermediate,

        /// <summary>
        /// Strong knowledge with extensive practical experience.
        /// </summary>
        Advanced,

        /// <summary>
        /// Comprehensive knowledge with proven expertise.
        /// </summary>
        Expert,

        /// <summary>
        /// Complete mastery with the ability to teach others.
        /// </summary>
        Master
    }
    
    /// <summary>
    /// Represents a category for grouping related skills.
    /// </summary>
    public class SkillCategory
    {
        /// <summary>
        /// Gets or sets the unique identifier for the skill category.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the skill category.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the description of the skill category.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the display order of this category.
        /// </summary>
        public int Order { get; set; } = 0;
    }
    
    /// <summary>
    /// Represents a technical or professional skill.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Gets or sets the unique identifier for the skill.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the skill.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the proficiency level as a percentage (0-100).
        /// </summary>
        public int Proficiency { get; set; } = 0;

        /// <summary>
        /// Gets or sets the qualitative proficiency level.
        /// </summary>
        public ProficiencyLevel ProficiencyLevel { get; set; } = ProficiencyLevel.Intermediate;

        /// <summary>
        /// Gets or sets the category name (legacy field).
        /// </summary>
        /// <remarks>
        /// This field is maintained for backward compatibility and will be replaced by CategoryId.
        /// </remarks>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the associated skill category.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the Font Awesome icon class for visual representation.
        /// </summary>
        /// <example>
        /// "fab fa-react" for React, "fab fa-python" for Python
        /// </example>
        public string IconClass { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the custom color for the icon.
        /// </summary>
        /// <remarks>
        /// Can be a hex color code or CSS color name.
        /// </remarks>
        public string IconColor { get; set; } = string.Empty;
    }
}