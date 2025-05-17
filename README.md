# Personal Blog

<div align="center">
  <img src="https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core" />
  <img src="https://img.shields.io/badge/Entity%20Framework-7.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="Entity Framework" />
  <img src="https://img.shields.io/badge/SQLite-3.39-003B57?style=for-the-badge&logo=sqlite&logoColor=white" alt="SQLite" />
  <img src="https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white" alt="Bootstrap" />
  <img src="https://img.shields.io/badge/License-MIT-success?style=for-the-badge" alt="License" />
  <br/><br/>
  <p>A modern, responsive personal blog and portfolio website built with ASP.NET Core Razor Pages.</p>
</div>

## <img src="https://api.iconify.design/ph:rocket-light.svg" width="20" height="20"/> Features

- <img src="https://api.iconify.design/ph:user-light.svg" width="16" height="16"/> **Personal Profile**: Display your professional information, skills, experience, and education
- <img src="https://api.iconify.design/ph:note-pencil-light.svg" width="16" height="16"/> **Blog**: Share your thoughts and expertise through blog posts
- <img src="https://api.iconify.design/ph:microphone-stage-light.svg" width="16" height="16"/> **Podcast**: Host and present your podcast episodes
- <img src="https://api.iconify.design/ph:newspaper-light.svg" width="16" height="16"/> **News**: Share industry news and updates
- <img src="https://api.iconify.design/ph:shield-check-light.svg" width="16" height="16"/> **Admin Panel**: Manage all content through a secure admin interface
- <img src="https://api.iconify.design/ph:device-mobile-light.svg" width="16" height="16"/> **Responsive Design**: Works on mobile, tablet, and desktop devices
- <img src="https://api.iconify.design/ph:moon-light.svg" width="16" height="16"/> **Dark Mode**: Toggle between light and dark themes
- <img src="https://api.iconify.design/ph:database-light.svg" width="16" height="16"/> **Persistent Storage**: Data stored in SQLite database

## <img src="https://api.iconify.design/ph:stack-light.svg" width="20" height="20"/> Technology Stack

- <img src="https://api.iconify.design/ph:code-light.svg" width="16" height="16"/> **ASP.NET Core 8.0**: Modern web framework
- <img src="https://api.iconify.design/ph:database-light.svg" width="16" height="16"/> **Entity Framework Core**: ORM for data access
- <img src="https://api.iconify.design/ph:file-sql-light.svg" width="16" height="16"/> **SQLite**: Lightweight database
- <img src="https://api.iconify.design/ph:file-html-light.svg" width="16" height="16"/> **Razor Pages**: Server-side rendering
- <img src="https://api.iconify.design/ph:layout-light.svg" width="16" height="16"/> **Bootstrap 5**: Responsive UI framework
- <img src="https://api.iconify.design/ph:star-light.svg" width="16" height="16"/> **Font Awesome**: Icon library
- <img src="https://api.iconify.design/ph:code-light.svg" width="16" height="16"/> **JavaScript/jQuery**: Client-side functionality

## <img src="https://api.iconify.design/ph:play-light.svg" width="20" height="20"/> Getting Started

### <img src="https://api.iconify.design/ph:clipboard-text-light.svg" width="16" height="16"/> Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or newer
- Visual Studio, VS Code, or any IDE with C# support

### <img src="https://api.iconify.design/ph:download-light.svg" width="16" height="16"/> Installation

1. Clone the repository
   ```bash
   git clone https://github.com/Emadram/PersonalBlog.git
   ```

2. Navigate to the project directory
   ```bash
   cd PersonalBlog
   ```

3. Restore NuGet packages
   ```bash
   dotnet restore
   ```

4. Run the application
   ```bash
   dotnet run
   ```

5. Access the website at `https://localhost:5219` or `http://localhost:5000`

### <img src="https://api.iconify.design/ph:database-light.svg" width="16" height="16"/> Database Setup

The application uses Entity Framework Core with SQLite. The database will be automatically created and seeded when you first run the application.

If you need to recreate the database or after making model changes:

```bash
# Install the EF Core tools if not already installed
dotnet tool install --global dotnet-ef

# Add migration
dotnet ef migrations add [MigrationName]

# Apply migration
dotnet ef database update
```

## <img src="https://api.iconify.design/ph:lock-key-light.svg" width="20" height="20"/> Admin Access

Access the admin panel at `/Admin/Login` with the following credentials:
- <img src="https://api.iconify.design/ph:user-light.svg" width="16" height="16"/> Username: admin
- <img src="https://api.iconify.design/ph:key-light.svg" width="16" height="16"/> Password: Admin123!

## <img src="https://api.iconify.design/ph:folder-light.svg" width="20" height="20"/> Project Structure

- <img src="https://api.iconify.design/ph:cube-light.svg" width="16" height="16"/> **Models**: Data models representing entities like Person, BlogPost, etc.
- <img src="https://api.iconify.design/ph:database-light.svg" width="16" height="16"/> **Data**: Database context and data seeding
- <img src="https://api.iconify.design/ph:gear-light.svg" width="16" height="16"/> **Services**: Business logic and data access
- <img src="https://api.iconify.design/ph:file-light.svg" width="16" height="16"/> **Pages**: Razor Pages for UI rendering
- <img src="https://api.iconify.design/ph:globe-light.svg" width="16" height="16"/> **wwwroot**: Static files (CSS, JS, images)

## <img src="https://api.iconify.design/ph:sliders-light.svg" width="20" height="20"/> Customization

### <img src="https://api.iconify.design/ph:user-gear-light.svg" width="16" height="16"/> Profile Information

Update your personal information through the Admin panel at `/Admin/Profile`.

### <img src="https://api.iconify.design/ph:pencil-line-light.svg" width="16" height="16"/> Content Management

Manage all content through the Admin panel:
- <img src="https://api.iconify.design/ph:book-open-light.svg" width="16" height="16"/> Blog posts: `/Admin/Blogs`
- <img src="https://api.iconify.design/ph:microphone-stage-light.svg" width="16" height="16"/> Podcast episodes: `/Admin/Podcasts`
- <img src="https://api.iconify.design/ph:newspaper-light.svg" width="16" height="16"/> News articles: `/Admin/News`
- <img src="https://api.iconify.design/ph:gear-six-light.svg" width="16" height="16"/> Site settings: `/Admin/Settings`

## <img src="https://api.iconify.design/ph:git-branch-light.svg" width="20" height="20"/> Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/my-feature`
3. Commit your changes: `git commit -m 'Add my feature'`
4. Push to the branch: `git push origin feature/my-feature`
5. Open a pull request

## <img src="https://api.iconify.design/ph:scales-light.svg" width="20" height="20"/> License

This project is licensed under the MIT License - see the LICENSE file for details.

## <img src="https://api.iconify.design/ph:star-light.svg" width="20" height="20"/> Acknowledgments

- ASP.NET Core Team
- Entity Framework Core Team
- Bootstrap Team
