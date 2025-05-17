using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Title { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string ResumeUrl { get; set; }
    }
} 