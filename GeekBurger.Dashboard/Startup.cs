﻿using GeekBurger.Dashboard.Extensions;
using GeekBurger.Dashboard.Interfaces.Repository;
using GeekBurger.Dashboard.Interfaces.Service;
using GeekBurger.Dashboard.Repository;
using GeekBurger.Dashboard.Service;
using GeekBurger.Dashboard.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

using Microsoft.Extensions.Configuration;

namespace GeekBurger.Dashboard
{
    public class Startup
    {

        public static string ConnectionString { get; private set; }

        public IConfiguration Configuration { get; }
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("appSettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var mvcCoreBuilder = services.AddMvcCore();

            services.AddDbContext<DashboardContext>(o => o.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IReceiveMessagesFactory, ReceiveMessagesFactory>();

            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<IUserRestrictionsRepository, UserRestrictionsRepository>();

            services.AddScoped<ISalesService, SalesService>();
            services.AddScoped<IUserRestrictionsService, UserRestrictionsService>();
            
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new Info
                {
                    Title = "Geek Burger Dashboard",
                    Version = "v1",
                    Description = "API que retorna métricas de vendas e usuários com restrição",
                    Contact = new Contact
                    {
                        Name = "Renato - 13NET",
                        Url = "https://github.com/RenatoNovelli"
                    }
                });
                c.DescribeAllEnumsAsStrings();
            });

            services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins("http://geekburguerdashboardui.azurewebsites.net")
                        .AllowAnyHeader()
                        );
                });

            mvcCoreBuilder
                .AddFormatterMappings()
                .AddJsonFormatters()
                .AddCors(options =>
                 options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    })
                )
                .AddJsonFormatters(); 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DashboardContext dashboardContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();

            //dashboardContext.Seed();

            app.UseCors("AllowAll");

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Geek Burguer Dashboard");
            });

            //app.ApplicationServices.GetService<IReceiveMessagesFactory>();           
        }
    }
}
