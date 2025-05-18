using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string GitHubUrl { get; set; } = string.Empty;
        public string LinkedInUrl { get; set; } = string.Empty;
        public string TwitterUrl { get; set; } = string.Empty;
        public string ResumeUrl { get; set; } = string.Empty;

        // Dual Persona Theme Colors
        public string LightModeColor { get; set; } = "#3498db"; // Default Project Manager Color (Light Blue)
        public string DarkModeColor { get; set; } = "#00bfff"; // Default Developer Color (Neon Blue)
        public string LightModeSecondaryColor { get; set; } = "#2980b9"; // Darker shade for gradients
        public string DarkModeSecondaryColor { get; set; } = "#0099cc"; // Darker shade for gradients
    }
}