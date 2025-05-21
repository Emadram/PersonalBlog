using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    /// <summary>
    /// Provides functionality for managing global site settings.
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Retrieves the current site settings.
        /// </summary>
        /// <returns>
        /// The current site settings. If no settings exist, creates and returns default settings.
        /// </returns>
        /// <remarks>
        /// Default settings include:
        /// - Site title: "My Personal Blog"
        /// - Site tagline: "Thoughts, stories and ideas"
        /// - Posts per page: 10
        /// - Comments enabled: true
        /// - Default category color: "primary"
        /// </remarks>
        SiteSettings GetSettings();

        /// <summary>
        /// Updates the site settings.
        /// </summary>
        /// <param name="settings">The updated site settings information.</param>
        /// <remarks>
        /// If no settings exist, creates new settings with the provided values.
        /// Otherwise, updates the existing settings.
        /// </remarks>
        void UpdateSettings(SiteSettings settings);
    }
}