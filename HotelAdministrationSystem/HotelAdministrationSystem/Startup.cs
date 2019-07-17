using HotelAdministrationSystem.Domain.DataBase;
using HotelAdministrationSystem.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using Swashbuckle.AspNetCore.Swagger;

namespace HotelAdministrationSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(x => x.SerializerSettings.Converters.Add(new StringEnumConverter()));
            services.AddDbContext<HotelSystemDBContext>(options =>
            {
                options.UseNpgsql(Configuration["DbConnectionString"],
                    c => c.MigrationsAssembly("HotelAdministrationSystem"));
            });
            services.AddDomainServices();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("hotelapi", new Info { Title = "HotelSystemApi", Version = "hotelapi" });
                opt.DescribeAllEnumsAsStrings();
                opt.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Please enter into field the word 'Bearer' following by space and JWT",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseSwagger(c =>
                {
                    c.RouteTemplate = ("api/{documentName}/swagger/swagger.json");
                }
            );
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/hotelapi/swagger/swagger.json", "HotelSystemApi");
                options.RoutePrefix = "api/help";
            });
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
