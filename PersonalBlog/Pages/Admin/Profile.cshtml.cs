using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class ProfileModel : PageModel
{
    private readonly IProfileService _profileService;
    
    [BindProperty]
    public Person Profile { get; set; } = new Person();
    
    public IEnumerable<Skill> Skills { get; set; } = new List<Skill>();
    public IEnumerable<SkillCategory> SkillCategories { get; set; } = new List<SkillCategory>();
    public IEnumerable<Experience> Experiences { get; set; } = new List<Experience>();
    public IEnumerable<Education> Educations { get; set; } = new List<Education>();
    
    [TempData]
    public string? SuccessMessage { get; set; }

    public ProfileModel(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public void OnGet()
    {
        LoadAllData();
    }
    
    private void LoadAllData()
    {
        Profile = _profileService.GetProfile() ?? new Person();
        Skills = _profileService.GetSkills();
        SkillCategories = _profileService.GetSkillCategories();
        Experiences = _profileService.GetExperiences();
        Educations = _profileService.GetEducations();
    }
    
    public IActionResult OnPostUpdateProfile()
    {
        if (!ModelState.IsValid)
        {
            LoadAllData();
            return Page();
        }
        
        _profileService.UpdateProfile(Profile);
        
        SuccessMessage = "Profile updated successfully!";
        return RedirectToPage();
    }
    
    // Skill Category Handlers
    public IActionResult OnPostAddSkillCategory(SkillCategory newCategory)
    {
        if (string.IsNullOrWhiteSpace(newCategory.Name))
        {
            SuccessMessage = "Category name is required.";
            LoadAllData();
            return Page();
        }
        
        _profileService.AddSkillCategory(newCategory);
        
        SuccessMessage = $"Skill category '{newCategory.Name}' added successfully!";
        return RedirectToPage();
    }
    
    public IActionResult OnPostUpdateSkillCategory(SkillCategory category)
    {
        if (category.Id == 0 || string.IsNullOrWhiteSpace(category.Name))
        {
            SuccessMessage = "Invalid category data.";
            LoadAllData();
            return Page();
        }
        
        _profileService.UpdateSkillCategory(category);
        
        SuccessMessage = $"Skill category '{category.Name}' updated successfully!";
        return RedirectToPage();
    }
    
    public IActionResult OnPostDeleteSkillCategory(int id)
    {
        _profileService.DeleteSkillCategory(id);
        
        SuccessMessage = "Skill category deleted successfully!";
        return RedirectToPage();
    }
    
    // Skill Handlers
    public IActionResult OnPostAddSkill(Skill newSkill)
    {
        if (string.IsNullOrWhiteSpace(newSkill.Name))
        {
            SuccessMessage = "Skill name is required.";
            LoadAllData();
            return Page();
        }
        
        _profileService.AddSkill(newSkill);
        
        SuccessMessage = $"Skill '{newSkill.Name}' added successfully!";
        return RedirectToPage();
    }
    
    public IActionResult OnPostUpdateSkill(Skill skill)
    {
        if (skill.Id == 0 || string.IsNullOrWhiteSpace(skill.Name))
        {
            SuccessMessage = "Invalid skill data.";
            LoadAllData();
            return Page();
        }
        
        _profileService.UpdateSkill(skill);
        
        SuccessMessage = $"Skill '{skill.Name}' updated successfully!";
        return RedirectToPage();
    }
    
    public IActionResult OnPostDeleteSkill(int id)
    {
        _profileService.DeleteSkill(id);
        
        SuccessMessage = "Skill deleted successfully!";
        return RedirectToPage();
    }

    // Education Handlers
    public IActionResult OnPostAddEducation(Education education)
    {
        if (string.IsNullOrWhiteSpace(education.Degree) || string.IsNullOrWhiteSpace(education.Institution))
        {
            SuccessMessage = "Degree and Institution are required.";
            LoadAllData();
            return Page();
        }
        
        _profileService.AddEducation(education);
        
        SuccessMessage = $"Education '{education.Degree}' added successfully!";
        return RedirectToPage();
    }

    public IActionResult OnPostUpdateEducation(Education education)
    {
        if (education.Id == 0 || string.IsNullOrWhiteSpace(education.Degree) || string.IsNullOrWhiteSpace(education.Institution))
        {
            SuccessMessage = "Invalid education data.";
            LoadAllData();
            return Page();
        }
        
        _profileService.UpdateEducation(education);
        
        SuccessMessage = $"Education '{education.Degree}' updated successfully!";
        return RedirectToPage();
    }

    public IActionResult OnPostDeleteEducation(int id)
    {
        _profileService.DeleteEducation(id);
        
        SuccessMessage = "Education entry deleted successfully!";
        return RedirectToPage();
    }

    // Experience Handlers
    public IActionResult OnPostAddExperience(Experience experience)
    {
        if (string.IsNullOrWhiteSpace(experience.Title) || string.IsNullOrWhiteSpace(experience.Company))
        {
            SuccessMessage = "Title and Company are required.";
            LoadAllData();
            return Page();
        }
        
        _profileService.AddExperience(experience);
        
        SuccessMessage = $"Experience '{experience.Title}' added successfully!";
        return RedirectToPage();
    }

    public IActionResult OnPostUpdateExperience(Experience experience)
    {
        if (experience.Id == 0 || string.IsNullOrWhiteSpace(experience.Title) || string.IsNullOrWhiteSpace(experience.Company))
        {
            SuccessMessage = "Invalid experience data.";
            LoadAllData();
            return Page();
        }
        
        _profileService.UpdateExperience(experience);
        
        SuccessMessage = $"Experience '{experience.Title}' updated successfully!";
        return RedirectToPage();
    }

    public IActionResult OnPostDeleteExperience(int id)
    {
        _profileService.DeleteExperience(id);
        
        SuccessMessage = "Experience entry deleted successfully!";
        return RedirectToPage();
    }
} 