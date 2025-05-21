using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    /// <summary>
    /// Represents a user comment on a blog post.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets the unique identifier for the comment.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the commenter.
        /// </summary>
        /// <remarks>
        /// The name must not exceed 100 characters in length.
        /// </remarks>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the email address of the commenter.
        /// </summary>
        /// <remarks>
        /// Must be a valid email address and not exceed 100 characters in length.
        /// </remarks>
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the content of the comment.
        /// </summary>
        /// <remarks>
        /// The content must not exceed 1000 characters in length.
        /// </remarks>
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the date and time when the comment was created.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Gets or sets whether the comment has been approved by a moderator.
        /// </summary>
        /// <remarks>
        /// Comments must be approved before they are publicly visible.
        /// </remarks>
        public bool IsApproved { get; set; } = false;
        
        /// <summary>
        /// Gets or sets the ID of the blog post this comment belongs to.
        /// </summary>
        public int BlogPostId { get; set; }
        
        /// <summary>
        /// Gets or sets the associated blog post.
        /// </summary>
        /// <remarks>
        /// This is a navigation property for the one-to-many relationship between posts and comments.
        /// </remarks>
        public BlogPost? BlogPost { get; set; }
    }
}
