﻿using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebSRTransport.Hubs;
using WebSRTransport.Validators;

namespace WebSRTransport
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
            services.AddCors();
            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SendParamHubValidator>());
            services.AddSignalR();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();

            // подключаем CORS
            app.UseCors(builder => builder.WithOrigins(
                    "https://localhost:8080",
                    "http://localhost:8080",
                    "https://localhost:9999",
                    "http://localhost:9999",
                    "https://localhost:9000",
                    "http://localhost:9000"
                    ).AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowCredentials());

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TransportSignalR");
            });

            //app.Map("/", Swagger);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapHub<FilmHub>("/film");
                endpoints.MapHub<CommonHub>("/common");
                endpoints.MapDefaultControllerRoute();
            });

            //app.UseMvcWithDefaultRoute();
        }
    }
}
