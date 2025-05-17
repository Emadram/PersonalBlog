using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public interface IPodcastService
    {
        IEnumerable<PodcastEpisode> GetAllEpisodes();
        IEnumerable<PodcastEpisode> GetRecentEpisodes(int count);
        PodcastEpisode GetFeaturedEpisode();
        PodcastEpisode GetEpisodeBySlug(string slug);
        IEnumerable<string> GetCategories();
        
        // CRUD operations
        PodcastEpisode GetEpisodeById(int id);
        void CreateEpisode(PodcastEpisode episode);
        void UpdateEpisode(PodcastEpisode episode);
        void DeleteEpisode(int id);
        void ToggleEpisodeFeatured(int id);
    }
} 