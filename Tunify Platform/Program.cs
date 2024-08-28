using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Repositories.Services;
using Tunify_Platform.Repositories.interfaces;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                 .AddEntityFrameworkStores<TunifyDbContext>();
            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<IPlaylist, PlaylistService>();
            builder.Services.AddScoped<ISong, SongService>();
            builder.Services.AddScoped<IArtist, ArtistService>();
            builder.Services.AddScoped<IAccount, IdentityAccountService>();
            builder.Services.AddScoped<JwtTokenService>();
            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            )
                .AddJwtBearer(
                    options =>
                    {
                        options.TokenValidationParameters = JwtTokenService.ValidateToken(builder.Configuration);
                    }
                );
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
            });
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
            app.UseAuthentication();
            app.UseAuthorization();
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
