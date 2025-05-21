using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    /// <summary>
    /// Provides functionality for managing user profiles, skills, education, and work experience.
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// Retrieves the user profile information.
        /// </summary>
        /// <returns>The profile information, or null if no profile exists.</returns>
        Person? GetProfile();

        /// <summary>
        /// Retrieves all skills ordered by category and proficiency.
        /// </summary>
        /// <returns>A collection of skills with their associated categories.</returns>
        IEnumerable<Skill> GetSkills();

        /// <summary>
        /// Retrieves all skill categories ordered by their display order.
        /// </summary>
        /// <returns>A collection of skill categories.</returns>
        IEnumerable<SkillCategory> GetSkillCategories();

        /// <summary>
        /// Retrieves a skill category by its ID.
        /// </summary>
        /// <param name="id">The ID of the skill category to retrieve.</param>
        /// <returns>The matching skill category, or null if not found.</returns>
        SkillCategory? GetSkillCategoryById(int id);

        /// <summary>
        /// Adds a new skill category.
        /// </summary>
        /// <param name="category">The skill category to add.</param>
        void AddSkillCategory(SkillCategory category);

        /// <summary>
        /// Updates an existing skill category.
        /// </summary>
        /// <param name="category">The updated skill category information.</param>
        void UpdateSkillCategory(SkillCategory category);

        /// <summary>
        /// Deletes a skill category and updates related skills.
        /// </summary>
        /// <param name="categoryId">The ID of the skill category to delete.</param>
        /// <remarks>
        /// When a category is deleted, all skills in that category will be marked as "Uncategorized".
        /// </remarks>
        void DeleteSkillCategory(int categoryId);

        /// <summary>
        /// Retrieves all work experiences ordered by display order.
        /// </summary>
        /// <returns>A collection of work experiences.</returns>
        IEnumerable<Experience> GetExperiences();

        /// <summary>
        /// Retrieves all educational records ordered by display order.
        /// </summary>
        /// <returns>A collection of education records.</returns>
        IEnumerable<Education> GetEducations();

        /// <summary>
        /// Updates the user profile information.
        /// </summary>
        /// <param name="profile">The updated profile information.</param>
        void UpdateProfile(Person profile);

        /// <summary>
        /// Updates an existing skill.
        /// </summary>
        /// <param name="skill">The updated skill information.</param>
        void UpdateSkill(Skill skill);

        /// <summary>
        /// Adds a new skill.
        /// </summary>
        /// <param name="skill">The skill to add.</param>
        void AddSkill(Skill skill);

        /// <summary>
        /// Deletes a skill.
        /// </summary>
        /// <param name="skillId">The ID of the skill to delete.</param>
        void DeleteSkill(int skillId);

        /// <summary>
        /// Updates an existing work experience record.
        /// </summary>
        /// <param name="experience">The updated experience information.</param>
        void UpdateExperience(Experience experience);

        /// <summary>
        /// Adds a new work experience record.
        /// </summary>
        /// <param name="experience">The experience record to add.</param>
        void AddExperience(Experience experience);

        /// <summary>
        /// Deletes a work experience record.
        /// </summary>
        /// <param name="experienceId">The ID of the experience record to delete.</param>
        void DeleteExperience(int experienceId);

        /// <summary>
        /// Retrieves a work experience record by its ID.
        /// </summary>
        /// <param name="id">The ID of the experience record to retrieve.</param>
        /// <returns>The matching experience record, or null if not found.</returns>
        Experience? GetExperienceById(int id);

        /// <summary>
        /// Updates an existing education record.
        /// </summary>
        /// <param name="education">The updated education information.</param>
        void UpdateEducation(Education education);

        /// <summary>
        /// Adds a new education record.
        /// </summary>
        /// <param name="education">The education record to add.</param>
        void AddEducation(Education education);

        /// <summary>
        /// Deletes an education record.
        /// </summary>
        /// <param name="educationId">The ID of the education record to delete.</param>
        void DeleteEducation(int educationId);

        /// <summary>
        /// Retrieves an education record by its ID.
        /// </summary>
        /// <param name="id">The ID of the education record to retrieve.</param>
        /// <returns>The matching education record, or null if not found.</returns>
        Education? GetEducationById(int id);
    }
}