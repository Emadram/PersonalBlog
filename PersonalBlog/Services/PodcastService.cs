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
        
        public PodcastEpisode GetEpisodeById(int id)
        {
            return _context.PodcastEpisodes.Find(id);
        }
        
        public void CreateEpisode(PodcastEpisode episode)
        {
            // Generate a slug if not provided
            if (string.IsNullOrEmpty(episode.Slug))
            {
                episode.Slug = GenerateSlug(episode.Title);
            }
            
            // Set the published date if not provided
            if (episode.PublishedDate == default)
            {
                episode.PublishedDate = DateTime.Now;
            }
            
            _context.PodcastEpisodes.Add(episode);
            _context.SaveChanges();
        }
        
        public void UpdateEpisode(PodcastEpisode episode)
        {
            var existingEpisode = _context.PodcastEpisodes.Find(episode.Id);
            if (existingEpisode != null)
            {
                // Update properties
                existingEpisode.Title = episode.Title;
                existingEpisode.Summary = episode.Summary;
                existingEpisode.EpisodeNumber = episode.EpisodeNumber;
                existingEpisode.AudioUrl = episode.AudioUrl;
                existingEpisode.ImageUrl = episode.ImageUrl;
                existingEpisode.DurationMinutes = episode.DurationMinutes;
                existingEpisode.Guests = episode.Guests;
                existingEpisode.Category = episode.Category;
                existingEpisode.CategoryBadgeColor = episode.CategoryBadgeColor;
                
                // Only update slug if it's provided and different
                if (!string.IsNullOrEmpty(episode.Slug) && existingEpisode.Slug != episode.Slug)
                {
                    existingEpisode.Slug = episode.Slug;
                }
                
                // Only update IsFeatured if needed
                if (episode.IsFeatured && !existingEpisode.IsFeatured)
                {
                    // Unset any currently featured episode
                    var currentFeatured = _context.PodcastEpisodes.FirstOrDefault(e => e.IsFeatured);
                    if (currentFeatured != null)
                    {
                        currentFeatured.IsFeatured = false;
                    }
                    
                    existingEpisode.IsFeatured = true;
                }
                
                _context.SaveChanges();
            }
        }
        
        public void DeleteEpisode(int id)
        {
            var episode = _context.PodcastEpisodes.Find(id);
            if (episode != null)
            {
                _context.PodcastEpisodes.Remove(episode);
                _context.SaveChanges();
            }
        }
        
        public void ToggleEpisodeFeatured(int id)
        {
            var episode = _context.PodcastEpisodes.Find(id);
            if (episode != null)
            {
                if (!episode.IsFeatured)
                {
                    // Unset any currently featured episode
                    var currentFeatured = _context.PodcastEpisodes.FirstOrDefault(e => e.IsFeatured);
                    if (currentFeatured != null)
                    {
                        currentFeatured.IsFeatured = false;
                    }
                    
                    episode.IsFeatured = true;
                }
                else
                {
                    // Unfeature this episode
                    episode.IsFeatured = false;
                }
                
                _context.SaveChanges();
            }
        }
        
        private string GenerateSlug(string title)
        {
            // Simple slug generation - replace spaces with dashes and make lowercase
            var slug = title.ToLower().Replace(" ", "-");
            
            // Remove any special characters
            slug = new string(slug.Where(c => char.IsLetterOrDigit(c) || c == '-').ToArray());
            
            return slug;
        }
    }
} 