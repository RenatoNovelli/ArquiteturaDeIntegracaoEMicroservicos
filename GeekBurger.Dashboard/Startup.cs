using GeekBurger.Dashboard.Interfaces.Repository;
using GeekBurger.Dashboard.Interfaces.Service;
using GeekBurger.Dashboard.Repository;
using GeekBurger.Dashboard.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GeekBurger.Dashboard
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var mvcCoreBuilder = services.AddMvcCore();

            services.AddDbContext<SalesContext>(o => o.UseInMemoryDatabase("geekburger-dashboard"));
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddSingleton<ISalesService, SalesService>();

            mvcCoreBuilder
                .AddFormatterMappings()
                .AddJsonFormatters()
                .AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SalesContext salesContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //salesContext.Seed();

            //Swagger
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1",
            //        new Info
            //        {
            //            Title = "Dashboard data",
            //            Version = "v1",
            //            Description = "Pega os dados pra fazer as paradas",
            //            Contact = new Contact
            //            {
            //                Name = "Renatinho vrau vrau",
            //                Url = "https://github.com/RenatoNovelli"
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
