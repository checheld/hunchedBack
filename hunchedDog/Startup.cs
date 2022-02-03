/*using hunchedDogBackend.Models;   // пространство имен моделей
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore; // пространство имен EntityFramework
using Microsoft.IdentityModel.Tokens;

namespace hunchedDogBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   // укзывает, будет ли валидироваться издатель при валидации токена
                   ValidateIssuer = true,
                   // строка, представляющая издателя
                   ValidIssuer = AuthOptions.ISSUER,

                   // будет ли валидироваться потребитель токена
                   ValidateAudience = true,
                   // установка потребителя токена
                   ValidAudience = AuthOptions.AUDIENCE,
                   // будет ли валидироваться время существования
                   ValidateLifetime = true,

                   // установка ключа безопасности
                   IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                   // валидация ключа безопасности
                   ValidateIssuerSigningKey = true,
               };
           });
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<HunchedContext>(options => options.UseSqlServer(connection));
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
*/