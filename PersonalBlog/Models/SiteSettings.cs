using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class SiteSettings
    {
        public int Id { get; set; } = 1;
        
        [Required(ErrorMessage = "Site title is required")]
        [StringLength(100, ErrorMessage = "Site title cannot be longer than 100 characters")]
        [Display(Name = "Site Title")]
        public string SiteTitle { get; set; } = "My Personal Blog";
        
        [StringLength(200, ErrorMessage = "Site tagline cannot be longer than 200 characters")]
        [Display(Name = "Site Tagline")]
        public string SiteTagline { get; set; } = "Thoughts, stories and ideas";
        
        [Display(Name = "Favicon URL")]
        public string FaviconUrl { get; set; } = string.Empty;
        
        [Display(Name = "Twitter URL")]
        public string TwitterUrl { get; set; } = string.Empty;
        
        [Display(Name = "LinkedIn URL")]
        public string LinkedInUrl { get; set; } = string.Empty;
        
        [Display(Name = "GitHub URL")]
        public string GitHubUrl { get; set; } = string.Empty;
        
        [Range(1, 50, ErrorMessage = "Posts per page must be between 1 and 50")]
        [Display(Name = "Posts Per Page")]
        public int PostsPerPage { get; set; } = 10;
        
        [Display(Name = "Enable Comments")]
        public bool EnableComments { get; set; } = true;
        
        [Display(Name = "Default Category Color")]
        public string DefaultCategoryColor { get; set; } = "primary";
        
        [Display(Name = "Google Analytics ID")]
        public string GoogleAnalyticsId { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "Meta description cannot be longer than 500 characters")]
        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; } = string.Empty;
        
        [StringLength(200, ErrorMessage = "Meta keywords cannot be longer than 200 characters")]
        [Display(Name = "Meta Keywords")]
        public string MetaKeywords { get; set; } = string.Empty;
    }
} 