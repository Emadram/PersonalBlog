using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    /// <summary>
    /// Represents an educational qualification or academic achievement.
    /// </summary>
    public class Education
    {
        /// <summary>
        /// Gets or sets the unique identifier for the education record.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the degree or qualification obtained.
        /// </summary>
        [Required]
        public string Degree { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the name of the educational institution.
        /// </summary>
        [Required]
        public string Institution { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets additional details about the education, such as achievements or specializations.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the start date of the education period.
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the end date of the education period.
        /// </summary>
        /// <remarks>
        /// Nullable to accommodate ongoing education.
        /// </remarks>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the display order of this education record.
        /// </summary>
        /// <remarks>
        /// Used to customize the order in which education records are displayed,
        /// typically showing most recent education first.
        /// </remarks>
        public int Order { get; set; } = 0;
    }
}