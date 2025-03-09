global using FastEndpoints;
global using FluentValidation;
using Api.Hubs;
using Api.Models;
using Api.Persistence;
using Api.Shared;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
services
    .AddAuthentication(IdentityConstants.BearerScheme)
    .AddCookie(IdentityConstants.ApplicationScheme)
    .AddBearerToken(IdentityConstants.BearerScheme);

services.AddAuthorization();

services
    .AddIdentityCore<User>(x => x.User.RequireUniqueEmail = true)
    .AddEntityFrameworkStores<StoreDbContext>()
    .AddApiEndpoints();
// Add services to the container.
services.ConfigureIoC(typeof(Program).Assembly);
services.AddSqlite<StoreDbContext>("Data Source=mydb.db;");
services.AddSignalR();
services
   .AddFastEndpoints(o => o.IncludeAbstractValidators = true)
   .SwaggerDocument(o =>
   {
       o.DocumentSettings = s =>
       {
           s.Title = "Store";
           s.Version = "v1";
       };
   }); //define a swagger document

services.AddControllers();
var app = builder.Build();
app.MapIdentityApi<User>().WithTags(nameof(IdentityUser));
app.MapGet("me", async (ClaimsPrincipal claims, StoreDbContext context, CancellationToken c = default) =>
{
    string stringUserId = claims.FindFirstValue(ClaimTypes.NameIdentifier)!;
    return await context.Users.FindAsync([Guid.Parse(stringUserId)], c) as IdentityUser<Guid>;
})
.WithTags(nameof(IdentityUser))
.RequireAuthorization();

app.MapHub<DummyHub>("/DummyHub");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseFastEndpoints().UseSwaggerGen();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
