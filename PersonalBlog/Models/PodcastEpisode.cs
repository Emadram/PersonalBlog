using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class PodcastEpisode
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Summary { get; set; }
        
        public string EpisodeNumber { get; set; }
        public string AudioUrl { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }
        public int DurationMinutes { get; set; }
        public string Guests { get; set; }
        public bool IsFeatured { get; set; }
        public string Category { get; set; }
        public string CategoryBadgeColor { get; set; }
        public string Slug { get; set; }
    }
} 