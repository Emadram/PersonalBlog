using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [StringLength(50, ErrorMessage = "Category name cannot be longer than 50 characters")]
        public string Name { get; set; } = string.Empty;

        // Optional: You might want to keep a badge color per category
        [Display(Name = "Badge Color")]
        [StringLength(20, ErrorMessage = "Badge color cannot be longer than 20 characters")]
        public string BadgeColor { get; set; } = "primary"; // Default color

        // Navigation property for the join table
        public ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
    }
}
