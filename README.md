# Personal Blog

A modern, responsive personal blog and portfolio website built with ASP.NET Core Razor Pages. This application allows you to showcase your skills, experience, education, blog posts, podcasts, and news articles.

## Features

- **Personal Profile**: Display your professional information, skills, experience, and education
- **Blog**: Share your thoughts and expertise through blog posts
- **Podcast**: Host and present your podcast episodes
- **News**: Share industry news and updates
- **Admin Panel**: Manage all content through a secure admin interface
- **Responsive Design**: Works on mobile, tablet, and desktop devices
- **Dark Mode**: Toggle between light and dark themes
- **Persistent Storage**: Data stored in SQLite database

## Technology Stack

- **ASP.NET Core 8.0**: Modern web framework
- **Entity Framework Core**: ORM for data access
- **SQLite**: Lightweight database
- **Razor Pages**: Server-side rendering
- **Bootstrap 5**: Responsive UI framework
- **Font Awesome**: Icon library
- **JavaScript/jQuery**: Client-side functionality

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or newer
- Visual Studio, VS Code, or any IDE with C# support

### Installation

1. Clone the repository
   ```
   git clone https://github.com/Emadram/PersonalBlog.git
   ```

2. Navigate to the project directory
   ```
   cd PersonalBlog
   ```

3. Restore NuGet packages
   ```
   dotnet restore
   ```

4. Run the application
   ```
   dotnet run
   ```

5. Access the website at `https://localhost:5219` or `http://localhost:5000`

### Database Setup

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

## Admin Access

Access the admin panel at `/Admin/Login` with the following credentials:
- Username: admin
- Password: Admin123!

## Project Structure

- **Models**: Data models representing entities like Person, BlogPost, etc.
- **Data**: Database context and data seeding
- **Services**: Business logic and data access
- **Pages**: Razor Pages for UI rendering
- **wwwroot**: Static files (CSS, JS, images)

## Customization

### Profile Information

Update your personal information through the Admin panel at `/Admin/Profile`.

### Content Management

Manage all content through the Admin panel:
- Blog posts: `/Admin/Blogs`
- Podcast episodes: `/Admin/Podcasts`
- News articles: `/Admin/News`
- Site settings: `/Admin/Settings`

## Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature/my-feature`
3. Commit your changes: `git commit -m 'Add my feature'`
4. Push to the branch: `git push origin feature/my-feature`
5. Open a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- ASP.NET Core Team
- Entity Framework Core Team
- Bootstrap Team
