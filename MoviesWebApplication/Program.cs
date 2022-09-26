using MoviesWebApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MoviesWebApplication.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieDBContext>(option =>option.UseSqlServer(
       builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddDbContext<IdentityContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("IdentityConnection")
    ));
builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddAuthentication()
        .AddGoogle(opts =>
        {
            opts.ClientId = "621412715966-mn4l7qa15b3irsl8cnm36oipkg25pq1v.apps.googleusercontent.com";
            opts.ClientSecret = "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";
            opts.SignInScheme = IdentityConstants.ExternalScheme;
        });



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await RoleInitializer.InitializeAsync(userManager, rolesManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database." + DateTime.Now.ToString());
    }
}



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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
