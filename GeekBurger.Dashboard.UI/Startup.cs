using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace GeekBurger.Dashboard.UI
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
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            //Swagger
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1",
            //        new Info
            //        {
            //            Title = "Dashboard Charts",
            //            Version = "v1",
            //            Description = "Mostra os gráficos muito loucos",
            //            Contact = new Contact
            //            {
            //                Name = "Joãozinho ui ui",
            //                Url = "https://github.com/Thuragon"
            //            }
            //        });

            //    string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
            //    string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
            //    string caminhoXmlDoc = Path.Combine(caminhoAplicacao, "API.xml");

            //    c.IncludeXmlComments(caminhoXmlDoc);
            //});
        }
    }
}
