using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public interface ISettingsService
    {
        SiteSettings GetSettings();
        void UpdateSettings(SiteSettings settings);
    }
} 