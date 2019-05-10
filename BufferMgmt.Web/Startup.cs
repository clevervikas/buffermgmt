using AutoMapper;
using BufferMgmt.DAL.Entities;
using BufferMgmt.DAL.Repositories;
using BufferMgmt.Web.Extensions;
using BufferMgmt.Web.Helpers;
using BufferMgmt.Web.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BufferMgmt.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

            //step 1: Register your DatabaseContext file
            services.AddDbContext<BufferMgmtContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:BufferMgmtDB"]));
            //step 2: Add dependancies in IoC mapper
            services.AddScoped(typeof(IRepo<Branch>), typeof(Repo<Branch>));
            services.AddScoped(typeof(IRepo<Customer>), typeof(Repo<Customer>));
            services.AddScoped(typeof(IRepo<MaterialCode>), typeof(Repo<MaterialCode>));

            //step 3: Configure,Enable Cross Origin Resource Shareing 
            services.ConfigureCors();
            //step 4: IIS Configuration as Part of .NET Core Configuration
            services.ConfigureIISIntegration();

            //Mapping Entities with Model classes

            var Mapperconfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMappingProfile());
            });

            IMapper mapper = Mapperconfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors("Corspolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
            });
            app.UseStaticFiles();
            //app.UseAuthentication();

            //routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Branch}/{action=Get}/{id?}"
            //        );
            //}
            app.UseMvc();
        }
    }
}
