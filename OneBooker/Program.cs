using Microsoft.EntityFrameworkCore;
using OneBooker.Api.Configurations.Auth;
using OneBooker.Api.Configurations.Swagger;
using OneBooker.Api.Filters;
using OneBooker.Modules.Users;
using OneBooker.Modules.Users.Infrastructure.Persistance;
using OneBooker.SharedKernel;
using OneBooker.SharedKernel.ServiceRegistration;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options =>
    {
        options.Filters.Add<ResponseModifierFilterAttribute>();
    });

builder.Services
    .AddSwaggerServices()
    .AddAuthServices(builder.Configuration);

builder.Services
    .RegisterMarkedServices()
    .AddUsersModule(builder.Configuration)
    .AddSharedServices(builder.Configuration);

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