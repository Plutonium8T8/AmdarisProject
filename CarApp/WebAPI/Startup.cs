using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Entity;
using Microsoft.AspNetCore.Identity;
using Entity.Models;
using WebAPI.Model.AuthOptions;
using WebAPI.Services;
using WebAPI.Services.Interfaces;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Middleware;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using KeyVR;
using Stripe;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace WebAPI
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddDbContext<Entity.AppContext>(options =>
                options.UseSqlServer(GetSecrets.ConnectionString), ServiceLifetime.Transient);

            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToAccessDenied = options.Events.OnRedirectToLogin = context =>
                {
                    if (context.Request.Method != "GET")
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.FromResult<object>(null);
                    }
                    context.Response.Redirect(context.RedirectUri);
                    return Task.FromResult<object>(null);
                };
            });

            var authOptionsConfiguration = Configuration.GetSection("Auth");
            services.Configure<AuthOptions>(authOptionsConfiguration);
            var authOptions = Configuration.GetSection("Auth").Get<AuthOptions>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authOptions.Audience,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = authOptions.GetSymmetricSecurityKey()
                };
            });

            services.AddAuthentication();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            StripeConfiguration.ApiKey = GetSecrets.StripeSecretKey;

            System.Console.WriteLine(StripeConfiguration.ApiKey);

            loggerFactory.AddFile("Logs/App-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseMiddleware<HandleExceptionMiddleware>();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
