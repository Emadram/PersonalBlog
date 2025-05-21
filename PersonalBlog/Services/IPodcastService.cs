using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    /// <summary>
    /// Provides functionality for managing podcast episodes.
    /// </summary>
    public interface IPodcastService
    {
        /// <summary>
        /// Retrieves all podcast episodes ordered by publish date.
        /// </summary>
        /// <returns>A collection of all podcast episodes.</returns>
        IEnumerable<PodcastEpisode> GetAllEpisodes();

        /// <summary>
        /// Retrieves the most recent podcast episodes.
        /// </summary>
        /// <param name="count">The number of episodes to retrieve.</param>
        /// <returns>A collection of the most recent podcast episodes.</returns>
        IEnumerable<PodcastEpisode> GetRecentEpisodes(int count);

        /// <summary>
        /// Retrieves the currently featured podcast episode.
        /// </summary>
        /// <returns>The featured podcast episode, or null if no episode is featured.</returns>
        PodcastEpisode? GetFeaturedEpisode();

        /// <summary>
        /// Retrieves a podcast episode by its URL slug.
        /// </summary>
        /// <param name="slug">The URL-friendly slug of the podcast episode.</param>
        /// <returns>The matching podcast episode, or null if not found.</returns>
        PodcastEpisode? GetEpisodeBySlug(string slug);

        /// <summary>
        /// Retrieves all podcast categories.
        /// </summary>
        /// <returns>A collection of distinct category names.</returns>
        IEnumerable<string> GetCategories();
        
        /// <summary>
        /// Retrieves a podcast episode by its ID.
        /// </summary>
        /// <param name="id">The ID of the podcast episode to retrieve.</param>
        /// <returns>The matching podcast episode, or null if not found.</returns>
        PodcastEpisode? GetEpisodeById(int id);

        /// <summary>
        /// Creates a new podcast episode.
        /// </summary>
        /// <param name="episode">The podcast episode to create.</param>
        void CreateEpisode(PodcastEpisode episode);

        /// <summary>
        /// Updates an existing podcast episode.
        /// </summary>
        /// <param name="episode">The updated podcast episode information.</param>
        void UpdateEpisode(PodcastEpisode episode);

        /// <summary>
        /// Deletes a podcast episode.
        /// </summary>
        /// <param name="id">The ID of the podcast episode to delete.</param>
        void DeleteEpisode(int id);

        /// <summary>
        /// Toggles the featured status of a podcast episode.
        /// </summary>
        /// <param name="id">The ID of the podcast episode to toggle.</param>
        /// <remarks>
        /// When an episode is featured, any previously featured episode is automatically unfeatured.
        /// </remarks>
        void ToggleEpisodeFeatured(int id);
    }
}