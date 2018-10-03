using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Altkom.Merrid.ProjectX.DbServices;
using Altkom.Merrid.ProjectX.FakeServices;
using Altkom.Merrid.ProjectX.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Altkom.Merrid.ProjectX.WebApiService
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
            services.AddSingleton<Generator, Generator>();
            services.AddScoped<IMetersService, DbMetersService>();
            services.AddScoped<IMeasuresService, DbMeasuresService>();

            // PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
            services.AddDbContext<ProjectXContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProjectXConnection")));

            // PM> Install-Package Microsoft.AspNetCore.Mvc.Formatters.Xml

            services
                .AddMvc(options => options.RespectBrowserAcceptHeader = true)
                .AddXmlSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("Home");

                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMvc();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "api/{controller}/{action=get}/{id?}"
            //            );

            //    routes.MapRoute(
            //        name: "v2",
            //        template: "api/v2/{controller}/{action=get}/{id?}"
            //            );
            //});
        }
    }
}
