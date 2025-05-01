using Marks.Application.Interfaces;
using Marks.Application.Mappings;
using Marks.Application.Services;
using Marks.Core.Entities;
using Marks.Infrastructure.Data;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<MarksDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalConnection"))
);
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});
builder.Services.AddAutoMapper(typeof(FolderProfile).Assembly);
builder.Services.AddScoped<IBookmarkService, BookmarkService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFolderService, FolderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
