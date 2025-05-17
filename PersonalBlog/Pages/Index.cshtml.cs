using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages;

public class IndexModel : PageModel
{
    private readonly IProfileService _profileService;
    
    public Person Profile { get; set; }
    public IEnumerable<Skill> Skills { get; set; }
    public IEnumerable<Experience> Experiences { get; set; }
    public IEnumerable<Education> Educations { get; set; }

    public IndexModel(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public void OnGet()
    {
        Profile = _profileService.GetProfile();
        Skills = _profileService.GetSkills();
        Experiences = _profileService.GetExperiences();
        Educations = _profileService.GetEducations();
    }
}
