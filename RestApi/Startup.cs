using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using VideoMenu.Infrastructure.Data;
using VideoMenu.Infrastructure.Data.Repositories;
using VideoMenuConsoleApp.Core.ApplicationService;
using VideoMenuConsoleApp.Core.ApplicationService.Services;
using VideoMenuConsoleApp.Core.DomainService;

namespace RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<VideoMenuAppContext>(
            //     opt => opt.UseInMemoryDatabase("DB"));
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            services.AddDbContext<VideoMenuAppContext>(builder => builder.UseLoggerFactory(loggerFactory).UseSqlite("Data Source=DatabaseApp.db"));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "RestApi", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, VideoMenuAppContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    scope.ServiceProvider.GetService<VideoMenuAppContext>();
                    DbInitializer.SeedDb(ctx);
                }

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestApi v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}