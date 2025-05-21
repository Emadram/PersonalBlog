using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    /// <summary>
    /// Represents a category for classifying blog posts.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        /// <remarks>
        /// The name must not exceed 50 characters in length.
        /// </remarks>
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(50, ErrorMessage = "Category name cannot be longer than 50 characters")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Bootstrap color class for the category badge.
        /// </summary>
        /// <remarks>
        /// Uses Bootstrap color classes (e.g., "primary", "success", "warning", etc.).
        /// Defaults to "primary" if not specified.
        /// </remarks>
        [Display(Name = "Badge Color")]
        [StringLength(20, ErrorMessage = "Badge color cannot be longer than 20 characters")]
        public string BadgeColor { get; set; } = "primary";

        /// <summary>
        /// Gets or sets the collection of post categories associations.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the many-to-many relationship between posts and categories.
        /// </remarks>
        public ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
    }
}
