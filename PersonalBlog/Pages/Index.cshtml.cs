using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages;

public class IndexModel : PageModel
{
    private readonly IProfileService _profileService;
    
    public Person Profile { get; set; } = new Person();
    public IEnumerable<Skill> Skills { get; set; } = new List<Skill>();
    public IEnumerable<Experience> Experiences { get; set; } = new List<Experience>();
    public IEnumerable<Education> Educations { get; set; } = new List<Education>();

    public IndexModel(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public void OnGet()
    {
        // Handle possible null from GetProfile() method
        Profile = _profileService.GetProfile() ?? new Person();
        Skills = _profileService.GetSkills();
        Experiences = _profileService.GetExperiences();
        Educations = _profileService.GetEducations();
    }
}
