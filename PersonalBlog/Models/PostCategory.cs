namespace PersonalBlog.Models
{
    // Join entity for the many-to-many relationship between BlogPost and Category
    public class PostCategory
    {
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
