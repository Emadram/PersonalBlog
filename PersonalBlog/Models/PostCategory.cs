namespace PersonalBlog.Models
{
    /// <summary>
    /// Represents the many-to-many relationship between blog posts and categories.
    /// </summary>
    /// <remarks>
    /// This is a join entity that enables a blog post to have multiple categories
    /// and a category to be associated with multiple blog posts.
    /// </remarks>
    public class PostCategory
    {
        /// <summary>
        /// Gets or sets the ID of the associated blog post.
        /// </summary>
        public int BlogPostId { get; set; }

        /// <summary>
        /// Gets or sets the associated blog post.
        /// </summary>
        public BlogPost BlogPost { get; set; } = null!;

        /// <summary>
        /// Gets or sets the ID of the associated category.
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the associated category.
        /// </summary>
        public Category Category { get; set; } = null!;
    }
}
