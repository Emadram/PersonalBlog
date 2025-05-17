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
    }
} 