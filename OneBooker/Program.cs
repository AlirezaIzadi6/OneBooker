using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OneBooker.Api.Configurations.Swagger;
using OneBooker.Api.Filters;
using OneBooker.Modules.Users;
using OneBooker.Modules.Users.Infrastructure.IdentityManagement;
using OneBooker.Modules.Users.Infrastructure.Persistance;
using OneBooker.Shared;
using OneBooker.Shared.ServiceRegistration;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options =>
    {
        options.Filters.Add<ResponseModifierFilterAttribute>();
    });
builder.Services.AddSwaggerServices();

JwtSettings authSettings = builder.Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
builder.Services.AddAuthentication(
        options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
    .AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.SecretKey)),
            };
        });

builder.Services
    .RegisterAppServices()
    .AddUsersModule(builder.Configuration)
    .AddSharedServices();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwaggerServices();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (IServiceScope scope = app.Services.CreateScope())
{
    UsersDbContext usersDb = scope.ServiceProvider.GetRequiredService<UsersDbContext>();
    usersDb.Database.Migrate();
}

app.Run();
