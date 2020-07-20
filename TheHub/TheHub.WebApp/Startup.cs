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





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
