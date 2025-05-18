using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Collections.Generic;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class IndexModel : PageModel
{
    private readonly IBlogService _blogService;
    private readonly IPodcastService _podcastService;
    private readonly INewsService _newsService;
    
    public string WelcomeMessage { get; set; } = string.Empty;
    public int BlogPostCount { get; set; }
    public int PodcastCount { get; set; }
    public int NewsCount { get; set; }
    public int CommentCount { get; set; } = 0; // Placeholder until comments are implemented
    
    public List<BlogPost> RecentBlogPosts { get; set; } = new();
    public List<PodcastEpisode> RecentPodcasts { get; set; } = new();
    public List<News> RecentNews { get; set; } = new();
    
    // Stats for progress bars
    public int BlogPostsThisMonth { get; set; }
    public int PodcastsThisMonth { get; set; }
    public int NewsThisMonth { get; set; }
    
    // Progress percentages for progress bars
    public int BlogProgress { get; set; }
    public int PodcastProgress { get; set; }
    public int NewsProgress { get; set; }
    
    public IndexModel(IBlogService blogService, IPodcastService podcastService, INewsService newsService)
    {
        _blogService = blogService;
        _podcastService = podcastService;
        _newsService = newsService;
    }
    
    public void OnGet()
    {
        WelcomeMessage = $"Welcome, {User.Identity?.Name}! Use the cards below to manage your website content.";
        
        // Get counts of content
        var allPosts = _blogService.GetAllPosts().ToList();
        var allPodcasts = _podcastService.GetAllEpisodes().ToList();
        var allNews = _newsService.GetAllNews().ToList();
        
        BlogPostCount = allPosts.Count;
        PodcastCount = allPodcasts.Count;
        NewsCount = allNews.Count;
        
        // Get recent content
        RecentBlogPosts = allPosts.OrderByDescending(p => p.PublishedDate).Take(5).ToList();
        RecentPodcasts = allPodcasts.OrderByDescending(p => p.PublishedDate).Take(5).ToList();
        RecentNews = allNews.OrderByDescending(n => n.PublishedDate).Take(5).ToList();
        
        // Calculate this month's content (for progress bars)
        var currentMonth = DateTime.Now.Month;
        var currentYear = DateTime.Now.Year;
        
        BlogPostsThisMonth = allPosts.Count(p => p.PublishedDate.Month == currentMonth && p.PublishedDate.Year == currentYear);
        PodcastsThisMonth = allPodcasts.Count(p => p.PublishedDate.Month == currentMonth && p.PublishedDate.Year == currentYear);
        NewsThisMonth = allNews.Count(n => n.PublishedDate.Month == currentMonth && n.PublishedDate.Year == currentYear);
        
        // Calculate progress percentages
        int blogProgress = BlogPostCount > 0 ? (int)(BlogPostsThisMonth / (double)BlogPostCount * 100) : 0;
        int podcastProgress = PodcastCount > 0 ? (int)(PodcastsThisMonth / (double)PodcastCount * 100) : 0;
        int newsProgress = NewsCount > 0 ? (int)(NewsThisMonth / (double)NewsCount * 100) : 0;
        
        // Ensure progress is capped at 100%
        BlogProgress = Math.Min(blogProgress, 100);
        PodcastProgress = Math.Min(podcastProgress, 100);
        NewsProgress = Math.Min(newsProgress, 100);
        
        BlogPostsThisMonth = allPosts.Count(p => p.PublishedDate.Month == currentMonth && p.PublishedDate.Year == currentYear);
        PodcastsThisMonth = allPodcasts.Count(p => p.PublishedDate.Month == currentMonth && p.PublishedDate.Year == currentYear);
        NewsThisMonth = allNews.Count(n => n.PublishedDate.Month == currentMonth && n.PublishedDate.Year == currentYear);
    }
} 