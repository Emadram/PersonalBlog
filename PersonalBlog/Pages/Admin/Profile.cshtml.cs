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
    
    [TempData]
    public string? SuccessMessage { get; set; }

    public ProfileModel(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public void OnGet()
    {
        Profile = _profileService.GetProfile();
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        // In a real application, you would save to a database
        // For this demo, we're using the in-memory approach
        // Update profile information in the database here
        _profileService.UpdateProfile(Profile);
        
        SuccessMessage = "Profile updated successfully!";
        return RedirectToPage();
    }
} 