using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVC_Project.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MVC_ProjectContext>(options =>
    options.UseSqlServer("Data Source=DESKTOP-P76THAM\\SQLEXPRESS;Initial Catalog=DB_Project_MVC;Integrated Security=True;Encrypt=False"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
