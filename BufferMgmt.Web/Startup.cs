using BufferMgmt.Web.Extensions;
using BufferMgmt.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            //step 1: Register your DatabaseContext file
            services.AddDbContext<BufferMgmtContext>(opts=>opts.UseSqlServer(Configuration["ConnectionString:BufferMgmtDB"]));
            //step 2: Add dependancies in IoC mapper
            services.AddScoped(typeof(IRepo<Branch>), typeof(Repo<Branch>));
            services.AddScoped(typeof(IRepo<Customer>), typeof(Repo<Customer>));
            services.AddScoped(typeof(IRepo<MaterialCode>), typeof(Repo<MaterialCode>));

            //step 3: Configure,Enable Cross Origin Resource Shareing 
            services.ConfigureCors();
            //step 4: IIS Configuration as Part of .NET Core Configuration
            services.ConfigureIISIntegration();
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

            app.UseMvc();
        }
    }
}
