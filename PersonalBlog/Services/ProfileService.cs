using PersonalBlog.Data;
using PersonalBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonalBlog.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;

        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Person? GetProfile()
        {
            return _context.People.FirstOrDefault();
        }

        public IEnumerable<Skill> GetSkills()
        {
            return _context.Skills.OrderBy(s => s.Category).ThenByDescending(s => s.Proficiency).ToList();
        }

        public IEnumerable<Experience> GetExperiences()
        {
            return _context.Experiences.OrderBy(e => e.Order).ToList();
        }

        public IEnumerable<Education> GetEducations()
        {
            return _context.Educations.OrderBy(e => e.Order).ToList();
        }
        
        public void UpdateProfile(Person profile)
        {
            var existingProfile = _context.People.FirstOrDefault();
            if (existingProfile == null)
            {
                // No profile yet, create new
                _context.People.Add(profile);
            }
            else
            {
                // Update properties
                existingProfile.Name = profile.Name;
                existingProfile.Title = profile.Title;
                existingProfile.Bio = profile.Bio;
                existingProfile.Location = profile.Location;
                existingProfile.Email = profile.Email;
                existingProfile.Phone = profile.Phone;
                existingProfile.ImageUrl = profile.ImageUrl;
                existingProfile.GitHubUrl = profile.GitHubUrl;
                existingProfile.LinkedInUrl = profile.LinkedInUrl;
                existingProfile.TwitterUrl = profile.TwitterUrl;
                existingProfile.ResumeUrl = profile.ResumeUrl;
            }
            _context.SaveChanges();
        }
        
        public void UpdateSkill(Skill skill)
        {
            var existingSkill = _context.Skills.FirstOrDefault(s => s.Id == skill.Id);
            if (existingSkill != null)
            {
                existingSkill.Name = skill.Name;
                existingSkill.Proficiency = skill.Proficiency;
                existingSkill.Category = skill.Category;
                existingSkill.IconClass = skill.IconClass;
                
                _context.SaveChanges();
            }
        }
        
        public void AddSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
        }
        
        public void DeleteSkill(int skillId)
        {
            var skill = _context.Skills.Find(skillId);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                _context.SaveChanges();
            }
        }

        // Implement Experience methods
        public Experience? GetExperienceById(int id)
        {
            return _context.Experiences.Find(id);
        }

        public void AddExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();
        }

        public void UpdateExperience(Experience experience)
        {
            var existingExperience = _context.Experiences.Find(experience.Id);
            if (existingExperience != null)
            {
                existingExperience.Title = experience.Title;
                existingExperience.Company = experience.Company;
                existingExperience.Description = experience.Description;
                existingExperience.StartDate = experience.StartDate;
                existingExperience.EndDate = experience.EndDate;
                existingExperience.Technologies = experience.Technologies;
                existingExperience.Order = experience.Order;
                
                _context.SaveChanges();
            }
        }

        public void DeleteExperience(int experienceId)
        {
            var experience = _context.Experiences.Find(experienceId);
            if (experience != null)
            {
                _context.Experiences.Remove(experience);
                _context.SaveChanges();
            }
        }

        // Implement Education methods
        public Education? GetEducationById(int id)
        {
            return _context.Educations.Find(id);
        }

        public void AddEducation(Education education)
        {
            _context.Educations.Add(education);
            _context.SaveChanges();
        }

        public void UpdateEducation(Education education)
        {
            var existingEducation = _context.Educations.Find(education.Id);
            if (existingEducation != null)
            {
                existingEducation.Degree = education.Degree;
                existingEducation.Institution = education.Institution;
                existingEducation.Description = education.Description;
                existingEducation.StartDate = education.StartDate;
                existingEducation.EndDate = education.EndDate;
                existingEducation.Order = education.Order;
                
                _context.SaveChanges();
            }
        }

        public void DeleteEducation(int educationId)
        {
            var education = _context.Educations.Find(educationId);
            if (education != null)
            {
                _context.Educations.Remove(education);
                _context.SaveChanges();
            }
        }
    }
} 