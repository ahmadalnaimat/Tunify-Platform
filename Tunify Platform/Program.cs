using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Repositories.Services;
using Tunify_Platform.Repositories.interfaces;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TunifyDbContext>(option => option.UseSqlServer(ConnectionString));
            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<IPlaylist, PlaylistService>();
            builder.Services.AddScoped<ISong, SongService>();
            builder.Services.AddScoped<IArtist, ArtistService>();


            var app = builder.Build();
            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
