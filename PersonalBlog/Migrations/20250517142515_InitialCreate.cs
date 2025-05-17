using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalBlog.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReadMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryBadgeColor = table.Column<string>(type: "TEXT", nullable: false),
                    Slug = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Degree = table.Column<string>(type: "TEXT", nullable: false),
                    Institution = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Company = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Technologies = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Source = table.Column<string>(type: "TEXT", nullable: false),
                    SourceUrl = table.Column<string>(type: "TEXT", nullable: false),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryBadgeColor = table.Column<string>(type: "TEXT", nullable: false),
                    Slug = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    GitHubUrl = table.Column<string>(type: "TEXT", nullable: false),
                    LinkedInUrl = table.Column<string>(type: "TEXT", nullable: false),
                    TwitterUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ResumeUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PodcastEpisodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Summary = table.Column<string>(type: "TEXT", nullable: false),
                    EpisodeNumber = table.Column<string>(type: "TEXT", nullable: false),
                    AudioUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DurationMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    Guests = table.Column<string>(type: "TEXT", nullable: false),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryBadgeColor = table.Column<string>(type: "TEXT", nullable: false),
                    Slug = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PodcastEpisodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiteTitle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    SiteTagline = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    FaviconUrl = table.Column<string>(type: "TEXT", nullable: false),
                    TwitterUrl = table.Column<string>(type: "TEXT", nullable: false),
                    LinkedInUrl = table.Column<string>(type: "TEXT", nullable: false),
                    GitHubUrl = table.Column<string>(type: "TEXT", nullable: false),
                    PostsPerPage = table.Column<int>(type: "INTEGER", nullable: false),
                    EnableComments = table.Column<bool>(type: "INTEGER", nullable: false),
                    DefaultCategoryColor = table.Column<string>(type: "TEXT", nullable: false),
                    GoogleAnalyticsId = table.Column<string>(type: "TEXT", nullable: false),
                    MetaDescription = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    MetaKeywords = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Proficiency = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    IconClass = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Category", "CategoryBadgeColor", "CommentCount", "Content", "ImageUrl", "IsFeatured", "PublishedDate", "ReadMinutes", "Slug", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, "Architecture", "primary", 24, "Content goes here", "https://via.placeholder.com/600x400", true, new DateTime(2025, 5, 12, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(4170), 12, "building-scalable-microservices", "In this comprehensive guide, I share my experience architecting microservices-based systems using .NET Core, including best practices for service communication, data consistency, and deployment strategies.", "Building Scalable Microservices with .NET Core" },
                    { 2, "C# Development", "info", 18, "Content goes here", "https://via.placeholder.com/400x250", false, new DateTime(2025, 5, 7, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(4890), 8, "csharp-10-features", "Exploring how the latest C# features can help you write more elegant, concise, and maintainable code with practical examples.", "Leveraging C# 10 Features for Cleaner Code" },
                    { 3, "Project Management", "success", 12, "Content goes here", "https://via.placeholder.com/400x250", false, new DateTime(2025, 5, 2, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(4900), 10, "effective-sprint-planning", "A practical guide to planning and executing effective sprints, based on my experience leading development teams.", "Effective Sprint Planning for Software Teams" },
                    { 4, "Architecture", "warning", 32, "Content goes here", "https://via.placeholder.com/400x250", false, new DateTime(2025, 4, 27, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(4900), 15, "domain-driven-design", "How to apply Domain-Driven Design principles to real-world applications with practical C# examples.", "Domain-Driven Design in Practice" },
                    { 5, "DevOps", "danger", 15, "Content goes here", "https://via.placeholder.com/400x250", false, new DateTime(2025, 4, 19, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(4910), 12, "github-actions-cicd", "A step-by-step tutorial on creating efficient CI/CD pipelines for .NET applications using GitHub Actions.", "Setting Up CI/CD Pipelines with GitHub Actions" }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "Degree", "Description", "EndDate", "Institution", "Order", "StartDate" },
                values: new object[,]
                {
                    { 1, "Master of Computer Science", "Specialized in Software Engineering and Project Management", new DateTime(2015, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "University of Technology", 1, new DateTime(2013, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Bachelor of Science in Computer Science", "Dean's List, Computer Science Club President", new DateTime(2013, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "State University", 2, new DateTime(2009, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "Company", "Description", "EndDate", "Order", "StartDate", "Technologies", "Title" },
                values: new object[,]
                {
                    { 1, "Tech Innovations Inc.", "Led development teams of 5-8 members, managing project timelines, resource allocation, and stakeholder communication. Architected and implemented microservices architecture that improved system scalability by 40%.", null, 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#, ASP.NET Core, Azure, Microservices, Team Leadership", "Senior Developer & Project Manager" },
                    { 2, "WebSolutions Co.", "Developed and maintained multiple web applications using .NET Core and React. Implemented CI/CD pipelines that reduced deployment time by 60%.", new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#, JavaScript, React, SQL Server, CI/CD", "Full-Stack Developer" },
                    { 3, "StartUp Labs", "Worked on front-end development for various client projects. Collaborated closely with UX designers to implement responsive interfaces.", new DateTime(2017, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HTML/CSS, JavaScript, Bootstrap", "Junior Software Engineer" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Category", "CategoryBadgeColor", "Content", "ImageUrl", "IsFeatured", "PublishedDate", "Slug", "Source", "SourceUrl", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, ".NET", "primary", "Content goes here", "https://via.placeholder.com/600x400", true, new DateTime(2025, 5, 15, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(7290), "dotnet-8-announcement", "Microsoft", "https://dotnet.microsoft.com", "Microsoft has announced .NET 8 with significant performance improvements and new features for developers.", "Announcing .NET 8 - Performance Improvements and New Features" },
                    { 2, "Security", "danger", "Content goes here", "https://via.placeholder.com/400x250", false, new DateTime(2025, 5, 12, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(7980), "javascript-security-update", "Security Weekly", "#", "A critical security update has been released for a widely used JavaScript framework. All developers are urged to update immediately.", "Major Security Update for Popular JavaScript Framework" },
                    { 3, "Architecture", "info", "Content goes here", "https://via.placeholder.com/400x250", false, new DateTime(2025, 5, 9, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(7980), "microservices-adoption-study", "Tech Insights", "#", "A recent industry study reveals that 75% of enterprise organizations have adopted or are planning to adopt microservices architecture.", "New Study Shows Increased Adoption of Microservices Architecture" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Bio", "Email", "GitHubUrl", "ImageUrl", "LinkedInUrl", "Location", "Name", "Phone", "ResumeUrl", "Title", "TwitterUrl" },
                values: new object[] { 1, "I specialize in web development and project management with over 8 years of experience building scalable applications and leading development teams.", "emad@example.com", "https://github.com/emadram", "https://via.placeholder.com/300", "https://linkedin.com/in/emadram", "San Francisco, CA", "Emad Ramezani", "(123) 456-7890", "/files/resume.pdf", "Software Developer & Project Manager", "https://twitter.com/emadram" });

            migrationBuilder.InsertData(
                table: "PodcastEpisodes",
                columns: new[] { "Id", "AudioUrl", "Category", "CategoryBadgeColor", "DurationMinutes", "EpisodeNumber", "Guests", "ImageUrl", "IsFeatured", "PublishedDate", "Slug", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, "#", ".NET", "primary", 45, "E01", "Jane Smith, Microsoft", "https://via.placeholder.com/400x400", true, new DateTime(2025, 5, 10, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(5840), "future-of-dotnet", "In this episode, we discuss the future of .NET with special guest Jane Smith from Microsoft.", "The Future of .NET Development" },
                    { 2, "#", "Career", "success", 38, "E02", "John Johnson, Senior Developer at Google", "https://via.placeholder.com/400x400", false, new DateTime(2025, 5, 3, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(6600), "career-growth-developers", "Tips and strategies for growing your career as a software developer.", "Career Growth for Developers" },
                    { 3, "#", "Front-End", "info", 52, "E03", "Sarah Lee, UI Architect", "https://via.placeholder.com/400x400", false, new DateTime(2025, 4, 26, 17, 25, 14, 922, DateTimeKind.Local).AddTicks(6600), "modern-frontend-frameworks", "Comparing React, Angular, and Vue.js with insights from top front-end developers.", "Modern Front-End Frameworks" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Category", "IconClass", "Name", "Proficiency" },
                values: new object[,]
                {
                    { 1, "Programming Languages", "fab fa-microsoft", "C# / .NET", 95 },
                    { 2, "Programming Languages", "fab fa-js", "JavaScript / TypeScript", 90 },
                    { 3, "Programming Languages", "fas fa-database", "SQL", 85 },
                    { 4, "Programming Languages", "fab fa-python", "Python", 75 },
                    { 5, "Frameworks & Tools", "fab fa-microsoft", "ASP.NET Core", 90 },
                    { 6, "Frameworks & Tools", "fab fa-react", "React", 85 },
                    { 7, "Frameworks & Tools", "fab fa-angular", "Angular", 80 },
                    { 8, "Frameworks & Tools", "fas fa-database", "SQL Server", 85 },
                    { 9, "Frameworks & Tools", "fab fa-docker", "Docker", 70 },
                    { 10, "Frameworks & Tools", "fas fa-cloud", "Azure", 75 },
                    { 11, "Frameworks & Tools", "fab fa-aws", "AWS", 65 },
                    { 12, "Frameworks & Tools", "fab fa-git-alt", "Git", 90 },
                    { 13, "Programming Languages", "fas fa-robot", "Prompt Engineering", 92 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "PodcastEpisodes");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
