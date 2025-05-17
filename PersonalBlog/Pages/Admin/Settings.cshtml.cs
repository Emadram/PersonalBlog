using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages.Admin;

[Authorize(Policy = "AdminOnly")]
public class SettingsModel : PageModel
{
    private readonly ISettingsService _settingsService;
    
    [BindProperty]
    public SiteSettings Settings { get; set; } = new SiteSettings();
    
    [TempData]
    public string? SuccessMessage { get; set; }

    public SettingsModel(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }
    
    public void OnGet()
    {
        Settings = _settingsService.GetSettings();
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        _settingsService.UpdateSettings(Settings);
        
        SuccessMessage = "Settings updated successfully.";
        return RedirectToPage();
    }
} 