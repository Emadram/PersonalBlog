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
        void UpdateExperience(Experience experience);
        void AddExperience(Experience experience);
        void DeleteExperience(int experienceId);
        Experience GetExperienceById(int id);
        void UpdateEducation(Education education);
        void AddEducation(Education education);
        void DeleteEducation(int educationId);
        Education GetEducationById(int id);
    }
} 