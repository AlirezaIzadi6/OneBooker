using Microsoft.EntityFrameworkCore;
using OneBooker.Api.Filters;
using OneBooker.Modules.Users;
using OneBooker.Modules.Users.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options =>
    {
        options.Filters.Add<ResponseModifierFilterAttribute>();
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

builder.Services.AddUsersModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var usersDb = scope.ServiceProvider.GetRequiredService<UsersDbContext>();
    usersDb.Database.Migrate();
}

app.Run();
