using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;
using PersonalBlog.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        // Configure Razor Pages options if needed
    });

// Add MVC services to support ViewComponents
builder.Services.AddControllersWithViews();

// Add database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=personalblog.db"));

// Register services
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IPodcastService, PodcastService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<ISettingsService, SettingsService>();

// Add HttpClient and Memory Cache for Weather API
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IWeatherService, WeatherService>();

// Add authentication 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin/Login";
        options.LogoutPath = "/Admin/Logout";
        options.AccessDeniedPath = "/AccessDenied";
    });

// Add authorization policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Admin");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers(); // Map API controller endpoints

// Seed the database when the application starts
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
    
    // Seed settings
    await DataSeeder.SeedSettingsAsync(context);
    
    // Seed categories and post relationships
    await DataSeeder.SeedCategoriesAndPostRelationsAsync(context);
}

// Run on a specific port to avoid conflicts
app.Run("http://localhost:8000");
