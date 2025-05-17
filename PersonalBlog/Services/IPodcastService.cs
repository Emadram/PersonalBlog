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
    }
} 