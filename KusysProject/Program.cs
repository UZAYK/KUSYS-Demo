using FluentValidation.AspNetCore;
using KUSYSDemo.Business.AutoMapperProfile;
using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;
using KUSYSDemo.Web.CustomCollectionExtension;
using KUSYSDemo.Business.DiContainer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddContainerWithDependencies();

builder.Services.AddDbContext<KusysDemoContext>();
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddValidator();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
