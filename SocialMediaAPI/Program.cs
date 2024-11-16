using Serilog;
using SocialMediaAPI.Extensions;
using SocialMediaAPI.Middlewares;
using SocialMediaApplication.Extensions;
using SocialMediaDomain.Entities;
using SocialMediaInfrastructure.Extensions;
using SocialMediaInfrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/users")
    .WithTags("Users")
    .MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }