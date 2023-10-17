using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicCatalog.Data;
using MusicCatalog.Models;
using MusicCatalog.Services.Communities;
using MusicCatalog.Services.Posts;
using MusicCatalog.Services.Reviews;
using MusicCatalog.Services.Spotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var serverVersion = new MySqlServerVersion(new Version(10, 6, 12));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommunityService, CommunityService>();
builder.Services.AddHttpClient<ISpotifyAccountService, SpotifyAccountService>(c =>
{
    c.BaseAddress = new Uri("https://accounts.spotify.com/api/");
});
builder.Services.AddHttpClient<ISpotifyService, SpotifyService>(c =>
{
    c.BaseAddress = new Uri("https://api.spotify.com/v1");
    c.DefaultRequestHeaders.Add("Accept", "application/.json");
});
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.HttpOnly = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
