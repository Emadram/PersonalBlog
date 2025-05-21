using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    /// <summary>
    /// Represents global configuration settings for the blog site.
    /// </summary>
    public class SiteSettings
    {
        /// <summary>
        /// Gets or sets the unique identifier for the site settings.
        /// </summary>
        /// <remarks>
        /// Typically only one record exists with Id = 1.
        /// </remarks>
        public int Id { get; set; } = 1;
        
        /// <summary>
        /// Gets or sets the main title of the blog site.
        /// </summary>
        [Required(ErrorMessage = "Site title is required")]
        [StringLength(100, ErrorMessage = "Site title cannot be longer than 100 characters")]
        [Display(Name = "Site Title")]
        public string SiteTitle { get; set; } = "My Personal Blog";
        
        /// <summary>
        /// Gets or sets the tagline or subtitle of the blog site.
        /// </summary>
        [StringLength(200, ErrorMessage = "Site tagline cannot be longer than 200 characters")]
        [Display(Name = "Site Tagline")]
        public string SiteTagline { get; set; } = "Thoughts, stories and ideas";
        
        /// <summary>
        /// Gets or sets the URL of the site's favicon.
        /// </summary>
        [Display(Name = "Favicon URL")]
        public string FaviconUrl { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the URL of the site's Twitter profile.
        /// </summary>
        [Display(Name = "Twitter URL")]
        public string TwitterUrl { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the URL of the site's LinkedIn profile.
        /// </summary>
        [Display(Name = "LinkedIn URL")]
        public string LinkedInUrl { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the URL of the site's GitHub profile.
        /// </summary>
        [Display(Name = "GitHub URL")]
        public string GitHubUrl { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the number of blog posts to display per page.
        /// </summary>
        [Range(1, 50, ErrorMessage = "Posts per page must be between 1 and 50")]
        [Display(Name = "Posts Per Page")]
        public int PostsPerPage { get; set; } = 10;
        
        /// <summary>
        /// Gets or sets whether commenting is enabled on blog posts.
        /// </summary>
        [Display(Name = "Enable Comments")]
        public bool EnableComments { get; set; } = true;
        
        /// <summary>
        /// Gets or sets the default Bootstrap color class for category badges.
        /// </summary>
        [Display(Name = "Default Category Color")]
        public string DefaultCategoryColor { get; set; } = "primary";
        
        /// <summary>
        /// Gets or sets the Google Analytics tracking ID.
        /// </summary>
        [Display(Name = "Google Analytics ID")]
        public string GoogleAnalyticsId { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the meta description for SEO purposes.
        /// </summary>
        [StringLength(500, ErrorMessage = "Meta description cannot be longer than 500 characters")]
        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the meta keywords for SEO purposes.
        /// </summary>
        [StringLength(200, ErrorMessage = "Meta keywords cannot be longer than 200 characters")]
        [Display(Name = "Meta Keywords")]
        public string MetaKeywords { get; set; } = string.Empty;
    }
}