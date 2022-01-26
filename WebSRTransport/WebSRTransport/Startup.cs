using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebSRTransport.Hubs;

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
            services.AddControllersWithViews(mvcOtions =>
            {
                mvcOtions.EnableEndpointRouting = false;
            });
            services.AddSwaggerGen();
            services.AddSignalR();
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



            // подключаем CORS
            //app.UseCors(builder => builder.WithOrigins(
            //        "https://localhost:8080",
            //        "https://localhost:9999"
            //        ).AllowAnyOrigin()
            //         .AllowAnyHeader()
            //         .AllowAnyMethod()
            //         .AllowCredentials());
            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TransportSignalR");
            });


            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chat");
                routes.MapHub<FilmHub>("/film");
                routes.MapHub<CommonHub>("/common");
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
