using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class PodcastEpisode
    {
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Summary { get; set; } = string.Empty;
        
        public string EpisodeNumber { get; set; } = string.Empty;
        public string AudioUrl { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public int DurationMinutes { get; set; }
        public string Guests { get; set; } = string.Empty;
        public bool IsFeatured { get; set; }
        public string Category { get; set; } = string.Empty;
        public string CategoryBadgeColor { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }
} 