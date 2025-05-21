using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PersonalBlog.Models
{
    /// <summary>
    /// Represents a blog post in the personal blog system.
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// Gets or sets the unique identifier for the blog post.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the title of the blog post.
        /// </summary>
        /// <remarks>
        /// The title must not exceed 100 characters in length.
        /// </remarks>
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets a brief summary of the blog post content.
        /// </summary>
        /// <remarks>
        /// The summary must not exceed 500 characters in length and is used for preview purposes.
        /// </remarks>
        [Required(ErrorMessage = "Summary is required")]
        [StringLength(500, ErrorMessage = "Summary cannot be longer than 500 characters")]
        public string Summary { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the main content of the blog post.
        /// </summary>
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the URL of the featured image for the blog post.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the date when the blog post was published.
        /// </summary>
        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Gets or sets the estimated reading time in minutes.
        /// </summary>
        /// <remarks>
        /// Must be between 1 and 60 minutes.
        /// </remarks>
        [Display(Name = "Read Time")]
        [Range(1, 60, ErrorMessage = "Read time must be between 1 and 60 minutes")]
        public int ReadMinutes { get; set; } = 5;
        
        /// <summary>
        /// Gets or sets the total number of comments on the blog post.
        /// </summary>
        [Display(Name = "Comment Count")]
        public int CommentCount { get; set; } = 0;
        
        /// <summary>
        /// Gets or sets whether this post is featured on the blog.
        /// </summary>
        [Display(Name = "Featured")]
        public bool IsFeatured { get; set; }
        
        /// <summary>
        /// Gets or sets the URL-friendly slug for the blog post.
        /// </summary>
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the categories associated with this blog post.
        /// </summary>
        /// <remarks>
        /// This is a many-to-many relationship implemented through the PostCategory join entity.
        /// </remarks>
        public ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
        
        /// <summary>
        /// Gets or sets the comments associated with this blog post.
        /// </summary>
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}