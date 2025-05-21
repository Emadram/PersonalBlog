using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    /// <summary>
    /// Represents a professional work experience entry.
    /// </summary>
    public class Experience
    {
        /// <summary>
        /// Gets or sets the unique identifier for the experience record.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the job title or position held.
        /// </summary>
        [Required]
        public string Title { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the name of the company or organization.
        /// </summary>
        [Required]
        public string Company { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the detailed description of responsibilities and achievements.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the start date of the employment period.
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the end date of the employment period.
        /// </summary>
        /// <remarks>
        /// Nullable to accommodate current positions.
        /// </remarks>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the comma-separated list of technologies used in this role.
        /// </summary>
        /// <remarks>
        /// Example: "C#, ASP.NET Core, Azure, React"
        /// </remarks>
        public string Technologies { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the display order of this experience record.
        /// </summary>
        /// <remarks>
        /// Used to customize the order in which experience records are displayed,
        /// typically showing most recent experience first.
        /// </remarks>
        public int Order { get; set; } = 0;
    }
}