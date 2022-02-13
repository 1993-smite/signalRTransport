using System;
using DBDapper;
using DBDapper.Models;
using DBDapper.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Models;
using WebAPI.Sevices;
using WebAPI.Sevices.Address;
using Microsoft.Extensions.Hosting;
using DB.Repositories.Address;
using DB.Repositories.Task;
using Microsoft.OpenApi.Models;
using RabbitCore.Core;
using RabbitCore.Core.Listeners;

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
            //services.AddHostedService<RabbitMqListenerService>();
            //services.AddMvc();
            ConfigureServicesDB(services);

            services.AddSingleton(Configuration);

            services.AddResponseCaching();

            services.AddMemoryCache();

            ConfigureServicesMap(services);

            services.AddScoped<IRabbitMqService, RabbitMqService>();

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

        #region db services
        /// <summary>
        /// configure db services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServicesDB(IServiceCollection services)
        {
            string connectionString = Configuration.GetValue<string>("SQL_SERVER.Test");

            services.AddTransient<IDapperRepository<Employee>, EmployeeRepository>(
                provider => new EmployeeRepository(connectionString));

            services.AddTransient<IMapper<Place, AddressFilter>, PlaceMapper>(
                provider => new PlaceMapper());
            services.AddTransient<IMapper<WebTask, TaskFilter>, WebTaskMapper>(
                provider => new WebTaskMapper());
        }
        #endregion

        #region route map service
        /// <summary>
        /// configure map service
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServicesMap(IServiceCollection services)
        {
            string routePath = Configuration.GetValue<string>("MapMoscowPath");

            
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
