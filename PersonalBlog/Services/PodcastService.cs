using PersonalBlog.Data;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Services
{
    public class PodcastService : IPodcastService
    {
        private readonly ApplicationDbContext _context;

        public PodcastService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PodcastEpisode> GetAllEpisodes()
        {
            return _context.PodcastEpisodes.OrderByDescending(e => e.PublishedDate).ToList();
        }

        public IEnumerable<PodcastEpisode> GetRecentEpisodes(int count)
        {
            return _context.PodcastEpisodes.OrderByDescending(e => e.PublishedDate).Take(count).ToList();
        }

        public PodcastEpisode GetFeaturedEpisode()
        {
            return _context.PodcastEpisodes.FirstOrDefault(e => e.IsFeatured);
        }

        public PodcastEpisode GetEpisodeBySlug(string slug)
        {
            return _context.PodcastEpisodes.FirstOrDefault(e => e.Slug == slug);
        }

        public IEnumerable<string> GetCategories()
        {
            return _context.PodcastEpisodes.Select(e => e.Category).Distinct().ToList();
        }
    }
} 