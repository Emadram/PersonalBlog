using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public interface IProfileService
    {
        Person GetProfile();
        IEnumerable<Skill> GetSkills();
        IEnumerable<Experience> GetExperiences();
        IEnumerable<Education> GetEducations();
    }
} 