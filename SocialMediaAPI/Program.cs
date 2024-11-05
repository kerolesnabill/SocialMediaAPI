using SocialMediaAPI.Extensions;
using SocialMediaApplication.Extensions;
using SocialMediaDomain.Entities;
using SocialMediaInfrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

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
