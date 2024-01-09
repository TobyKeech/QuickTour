using QuickTour.Configuration;
using QuickTour.Middleware;
using QuickTour.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IForumContext, MockForumContext>();
builder.Services.AddTransient<ITransient, TransientDependency>();
builder.Services.AddScoped<IScoped, ScopedDependency>();
builder.Services.AddSingleton<ISingleton, SingletonDependency>();
builder.Services.Configure<FeaturesConfiguration>(builder.Configuration.GetSection("Features"));
    
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

app.UseMiddleware<CustomMiddleware1>();

app.UseMiddleware<CustomMiddleware2>();

app.MapControllerRoute(
    name: "default",
    pattern: "{area:exists=Users}/{controller=Forum}/{action=Index}/{id?}");

app.Run();
