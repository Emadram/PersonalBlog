using PersonalBlog.Data;
using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ApplicationDbContext _context;

        public SettingsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public SiteSettings GetSettings()
        {
            // Since we only have one settings record, always get the first one or create new
            var settings = _context.SiteSettings.FirstOrDefault();
            
            if (settings == null)
            {
                // Create default settings
                settings = new SiteSettings 
                { 
                    Id = 1,
                    SiteTitle = "My Personal Blog",
                    SiteTagline = "Thoughts, stories and ideas",
                    PostsPerPage = 10,
                    EnableComments = true,
                    DefaultCategoryColor = "primary"
                };
                
                _context.SiteSettings.Add(settings);
                _context.SaveChanges();
            }
            
            return settings;
        }

        public void UpdateSettings(SiteSettings settings)
        {
            var existingSettings = _context.SiteSettings.FirstOrDefault();
            
            if (existingSettings == null)
            {
                // If no settings exist yet, add them
                _context.SiteSettings.Add(settings);
            }
            else
            {
                // Update existing settings
                existingSettings.SiteTitle = settings.SiteTitle;
                existingSettings.SiteTagline = settings.SiteTagline;
                existingSettings.FaviconUrl = settings.FaviconUrl;
                existingSettings.TwitterUrl = settings.TwitterUrl;
                existingSettings.LinkedInUrl = settings.LinkedInUrl;
                existingSettings.GitHubUrl = settings.GitHubUrl;
                existingSettings.PostsPerPage = settings.PostsPerPage;
                existingSettings.EnableComments = settings.EnableComments;
                existingSettings.DefaultCategoryColor = settings.DefaultCategoryColor;
                existingSettings.GoogleAnalyticsId = settings.GoogleAnalyticsId;
                existingSettings.MetaDescription = settings.MetaDescription;
                existingSettings.MetaKeywords = settings.MetaKeywords;
            }
            
            _context.SaveChanges();
        }
    }
} 