using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Repositories.Services;
using Tunify_Platform.Repositories.interfaces;
using Microsoft.Extensions.Options;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TunifyDbContext>(option => option.UseSqlServer(ConnectionString));
            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<IPlaylist, PlaylistService>();
            builder.Services.AddScoped<ISong, SongService>();
            builder.Services.AddScoped<IArtist, ArtistService>();

            builder.Services.AddSwaggerGen
                (option =>
                    {
                        option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "Tunify API",
                            Version = "v1",
                            Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                        });
                    }
                );


            var app = builder.Build();

            app.UseSwagger(
                option =>
                {
                    option.RouteTemplate = "api/{documentName}/swagger.json";
                }
                );
            app.UseSwaggerUI(
            option =>
            {
                option.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                option.RoutePrefix = "";
            });

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
