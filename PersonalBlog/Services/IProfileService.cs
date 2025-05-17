using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public interface IProfileService
    {
        Person GetProfile();
        IEnumerable<Skill> GetSkills();
        IEnumerable<Experience> GetExperiences();
        IEnumerable<Education> GetEducations();
        void UpdateProfile(Person profile);
        void UpdateSkill(Skill skill);
        void AddSkill(Skill skill);
        void DeleteSkill(int skillId);
    }
} 