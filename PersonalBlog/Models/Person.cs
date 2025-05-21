using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    /// <summary>
    /// Represents a person's profile information in the blog system.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the unique identifier for the person.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the person.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the professional title or role of the person.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the biographical information about the person.
        /// </summary>
        public string Bio { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the geographic location of the person.
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the contact email address.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the contact phone number.
        /// </summary>
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the URL of the profile image.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the GitHub profile URL.
        /// </summary>
        public string GitHubUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the LinkedIn profile URL.
        /// </summary>
        public string LinkedInUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Twitter profile URL.
        /// </summary>
        public string TwitterUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the URL to the person's resume/CV.
        /// </summary>
        public string ResumeUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the primary theme color for light mode.
        /// </summary>
        /// <remarks>
        /// Default color is light blue (#3498db) optimized for project manager persona.
        /// </remarks>
        public string LightModeColor { get; set; } = "#3498db";

        /// <summary>
        /// Gets or sets the primary theme color for dark mode.
        /// </summary>
        /// <remarks>
        /// Default color is neon blue (#00bfff) optimized for developer persona.
        /// </remarks>
        public string DarkModeColor { get; set; } = "#00bfff";

        /// <summary>
        /// Gets or sets the secondary theme color for light mode.
        /// </summary>
        /// <remarks>
        /// Used for gradients and complementary elements.
        /// </remarks>
        public string LightModeSecondaryColor { get; set; } = "#2980b9";

        /// <summary>
        /// Gets or sets the secondary theme color for dark mode.
        /// </summary>
        /// <remarks>
        /// Used for gradients and complementary elements.
        /// </remarks>
        public string DarkModeSecondaryColor { get; set; } = "#0099cc";
    }
}