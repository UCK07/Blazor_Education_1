using Blazor_Education.Areas.Identity;
using Blazor_Education.Data;
using Blazor_Education.Services.Concreates;
using Blazor_Education.Services.Interfaces;
using Blazored.Toast;
using DataAccess.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlazorCourseContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationDbContext"));   //Database
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());   // Mapper
builder.Services.AddScoped<ICourseBlazor, CourseBlazor>();



builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<BlazorEducationContext>();
builder.Services.AddRazorPages();   
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddBlazoredToast();
builder.Services.AddScoped<IImageUploadService, CloudinaryImageUploadService>();
builder.Services.AddRadzenComponents();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
