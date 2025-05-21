using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    /// <summary>
    /// Provides functionality for managing blog posts and their associated comments.
    /// </summary>
    public interface IBlogService
    {
        /// <summary>
        /// Retrieves all blog posts ordered by publish date.
        /// </summary>
        /// <returns>A collection of all blog posts with their associated categories.</returns>
        IEnumerable<BlogPost> GetAllPosts();

        /// <summary>
        /// Retrieves the most recent blog posts.
        /// </summary>
        /// <param name="count">The number of posts to retrieve.</param>
        /// <returns>A collection of the most recent blog posts with their associated categories.</returns>
        IEnumerable<BlogPost> GetRecentPosts(int count);

        /// <summary>
        /// Retrieves the currently featured blog post.
        /// </summary>
        /// <returns>The featured blog post, or null if no post is featured.</returns>
        BlogPost? GetFeaturedPost();

        /// <summary>
        /// Retrieves a blog post by its URL slug.
        /// </summary>
        /// <param name="slug">The URL-friendly slug of the blog post.</param>
        /// <returns>The matching blog post, or null if not found.</returns>
        BlogPost? GetPostBySlug(string slug);

        /// <summary>
        /// Retrieves all blog categories.
        /// </summary>
        /// <returns>A collection of all blog categories ordered by name.</returns>
        IEnumerable<Category> GetCategories();

        /// <summary>
        /// Retrieves all blog posts in a specific category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to filter by.</param>
        /// <returns>A collection of blog posts in the specified category.</returns>
        IEnumerable<BlogPost> GetPostsByCategory(int categoryId);
        
        /// <summary>
        /// Retrieves a blog post by its ID.
        /// </summary>
        /// <param name="id">The ID of the blog post to retrieve.</param>
        /// <returns>The matching blog post, or null if not found.</returns>
        BlogPost? GetPostById(int id);
        
        /// <summary>
        /// Creates a new blog post with the specified categories.
        /// </summary>
        /// <param name="post">The blog post to create.</param>
        /// <param name="selectedCategoryIds">The IDs of the categories to associate with the post.</param>
        void CreatePost(BlogPost post, List<int> selectedCategoryIds);
        
        /// <summary>
        /// Updates an existing blog post and its associated categories.
        /// </summary>
        /// <param name="post">The updated blog post information.</param>
        /// <param name="selectedCategoryIds">The IDs of the categories to associate with the post.</param>
        void UpdatePost(BlogPost post, List<int> selectedCategoryIds);
        
        /// <summary>
        /// Deletes a blog post and all its associated data (comments, category associations).
        /// </summary>
        /// <param name="id">The ID of the blog post to delete.</param>
        void DeletePost(int id);
        
        /// <summary>
        /// Toggles the featured status of a blog post.
        /// </summary>
        /// <param name="id">The ID of the blog post to toggle.</param>
        /// <remarks>
        /// When a post is featured, any previously featured post is automatically unfeatured.
        /// </remarks>
        void TogglePostFeatured(int id);
        
        /// <summary>
        /// Retrieves all approved comments for a specific blog post.
        /// </summary>
        /// <param name="postId">The ID of the blog post.</param>
        /// <returns>A collection of approved comments for the specified post.</returns>
        IEnumerable<Comment> GetCommentsByPostId(int postId);
        
        /// <summary>
        /// Adds a new comment to a blog post.
        /// </summary>
        /// <param name="comment">The comment to add.</param>
        /// <remarks>
        /// The comment count on the associated blog post is automatically updated
        /// if the comment is approved.
        /// </remarks>
        void AddComment(Comment comment);
        
        /// <summary>
        /// Approves a comment and updates the associated blog post's comment count.
        /// </summary>
        /// <param name="id">The ID of the comment to approve.</param>
        void ApproveComment(int id);
        
        /// <summary>
        /// Deletes a comment and updates the associated blog post's comment count if necessary.
        /// </summary>
        /// <param name="id">The ID of the comment to delete.</param>
        void DeleteComment(int id);
    }
}