using Marks.Application.Interfaces;
using Marks.Application.Mappings;
using Marks.Application.Services;
using Marks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<MarksDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalConnection"))
);

builder.Services.AddAutoMapper(typeof(FolderProfile).Assembly);
builder.Services.AddScoped<IBookmarkService, BookmarkService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFolderService, FolderService>();
builder.Services.AddSingleton<ITokenService, JwtService>();

builder
    .Services.AddAuthentication("Bearer")
    .AddJwtBearer(
        "Bearer",
        options =>
        {
            options.TokenValidationParameters =
                new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]
                                ?? throw new InvalidOperationException("Jwt Key is not configured")
                        )
                    ),
                };
        }
    );
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "Marks.Api",
            Version = "v1",
            Description = "Gerenciador centralizado de marcações e favoritos",
            Contact = new OpenApiContact { Name = "Caio Matheus", Email = "caiomathol@gmail.com" },
        }
    );
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
