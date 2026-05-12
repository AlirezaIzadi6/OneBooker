using Microsoft.EntityFrameworkCore;
using OneBooker.Api;
using OneBooker.Api.Configurations.Swagger;
using OneBooker.Api.Filters;
using OneBooker.Api.Middlewares;
using OneBooker.Modules.Users;
using OneBooker.Modules.Users.Infrastructure.Persistance;
using OneBooker.Shared;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options =>
    {
        options.Filters.Add<ResponseModifierFilterAttribute>();
    });
builder.Services.AddSwaggerServices();
builder.Services.AddApiServices();

builder.Services.AddUsersModule(builder.Configuration).AddSharedServices();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwaggerServices();
app.UseHttpsRedirection();

app.UseMiddleware<AuthMiddleware>();

app.MapControllers();

using (IServiceScope scope = app.Services.CreateScope())
{
    UsersDbContext usersDb = scope.ServiceProvider.GetRequiredService<UsersDbContext>();
    usersDb.Database.Migrate();
}

app.Run();
