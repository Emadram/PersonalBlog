using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public interface IBlogService
    {
        IEnumerable<BlogPost> GetAllPosts();
        IEnumerable<BlogPost> GetRecentPosts(int count);
        BlogPost GetFeaturedPost();
        BlogPost GetPostBySlug(string slug);
        IEnumerable<string> GetCategories();
        IEnumerable<BlogPost> GetPostsByCategory(string category);
        
        // CRUD operations
        BlogPost GetPostById(int id);
        void CreatePost(BlogPost post);
        void UpdatePost(BlogPost post);
        void DeletePost(int id);
        void TogglePostFeatured(int id);
    }
} 