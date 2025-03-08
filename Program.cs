using Api.Persistence;
using Api.Shared;
using FastEndpoints;
using FastEndpoints.Swagger;
namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            // Add services to the container.
            services.ConfigureIoC(typeof(Program).Assembly);
            services.AddSqlite<StoreDbContext>("Data Source=mydb.db;");
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

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseFastEndpoints().UseSwaggerGen();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }


    }
}