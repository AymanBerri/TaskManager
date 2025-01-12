using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddControllersWithViews();  // For controllers and views (MVC)
builder.Services.AddRazorPages();  // For Razor Pages


// Register the DbContext with the SQLite provider
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskContext")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

// app.MapStaticAssets();
app.UseStaticFiles();  // Serve static files (e.g., CSS, JS, images)


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // MVC route
//     .WithStaticAssets();

app.MapRazorPages();  // Add this to enable Razor Pages routes


// app.MapControllers();  // Add this to ensure your API routes are mapped

app.Run();
