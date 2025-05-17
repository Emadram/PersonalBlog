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

        public Person GetProfile()
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
    }
} 