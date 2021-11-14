using System;
using DBDapper;
using DBDapper.Models;
using DBDapper.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebAPI
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
            //services.AddMvc();
            ConfigureServicesDB(services);

            services.AddResponseCaching();

            services.AddMemoryCache();

            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "ASP.NET Core Web API"
                });
                c.IncludeXmlComments(GetXmlCommentsPath());

            });
        }

        private static string GetXmlCommentsPath()
        {
            return String.Format(@"{0}\WebAPI.XML", AppDomain.CurrentDomain.BaseDirectory);
        }

        public void ConfigureServicesDB(IServiceCollection services)
        {
            string connectionString = Configuration.GetValue<string>("SQL_SERVER.Test");

            services.AddTransient<IDapperRepository<Employee>, EmployeeRepository>(provider => new EmployeeRepository(connectionString));
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

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CommonApi");
            });

            app.UseResponseCaching();

            // подключаем CORS
            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());

            app.UseMvcWithDefaultRoute();
        }
    }
}
