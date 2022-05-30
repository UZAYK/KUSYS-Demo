using FluentValidation.AspNetCore;
using KUSYSDemo.Business.AutoMapperProfile;
using KUSYSDemo.DataAccess.Concrete.EntityFrameworkCore.Context;
using KUSYSDemo.Web.CustomCollectionExtension;
using KUSYSDemo.Business.DiContainer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddFluentValidation();

// Services Container.
builder.Services.AddContainerWithDependencies();

// DB Context.
builder.Services.AddDbContext<KusysDemoContext>();

// AutoMapper.
builder.Services.AddAutoMapper(typeof(MapProfile));

// Fluent Validation - custom validators.
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
