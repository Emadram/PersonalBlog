using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public interface IBlogService
    {
        IEnumerable<BlogPost> GetAllPosts();
        IEnumerable<BlogPost> GetRecentPosts(int count);
        BlogPost? GetFeaturedPost();
        BlogPost? GetPostBySlug(string slug);
        IEnumerable<Category> GetCategories();
        IEnumerable<BlogPost> GetPostsByCategory(int categoryId);
        
        // CRUD operations
        BlogPost? GetPostById(int id);
        void CreatePost(BlogPost post, List<int> selectedCategoryIds);
        void UpdatePost(BlogPost post, List<int> selectedCategoryIds);
        void DeletePost(int id);
        void TogglePostFeatured(int id);
        
        // Comment operations
        IEnumerable<Comment> GetCommentsByPostId(int postId);
        void AddComment(Comment comment);
        void ApproveComment(int id);
        void DeleteComment(int id);
    }
} 