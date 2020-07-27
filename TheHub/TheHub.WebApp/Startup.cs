using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TheHub.Library.Interfaces;
using TheHub.DataAccess.Repository;
using TheHub.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace TheHub.WebApp
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
            services.AddCors(options =>
            {
                // defining the policy
                options.AddPolicy(name: "AllowTheHub-site",
                                  builder =>
                                  {
                                      builder.WithOrigins("http://thehub-site.azurewebsites.net", 
                                                          "https://thehub-site.azurewebsites.net",
                                                          "http://localhost:4200")
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowCredentials();
                                  });
            });
            services.AddDbContext<Project2Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            services.AddControllers();
            services.AddScoped<IUserRepo, UserRepository>();
            services.AddScoped<IReviewRepo, ReviewRepository>();
            services.AddScoped<INotificationRepo, NotificationRepository>();
            services.AddScoped<IMediaTypeRepo, MediaTypeRepository>();
            services.AddScoped<IMediaRepo, MediaRepository>();
            services.AddScoped<IGenreRepo, GenreRepository>();
            services.AddScoped<ICommentRepo, CommentRepository>();


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "The Hub API V1");
            });

            app.UseRouting();

            app.UseCors("AllowTheHub-site");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
