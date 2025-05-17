using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IProfileService _profileService;
        
        public ApiController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        
        [HttpGet("experience/{id}")]
        public IActionResult GetExperience(int id)
        {
            var experience = _profileService.GetExperienceById(id);
            
            if (experience == null)
            {
                return NotFound();
            }
            
            return Ok(experience);
        }
        
        [HttpGet("education/{id}")]
        public IActionResult GetEducation(int id)
        {
            var education = _profileService.GetEducationById(id);
            
            if (education == null)
            {
                return NotFound();
            }
            
            return Ok(education);
        }
    }
} 