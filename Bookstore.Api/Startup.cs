using Bookstore.AppConfigs;
using Bookstore.GraphqlBookstore.Schemas;
using GraphiQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bookstore
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1.0.0-beta",
                new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Books Store",
                    Description = "Store for Books",
                    Version = "1.0-beta"
                });
            });

            // DI
            DependencyContainer.InitializeConfig(services, this._configuration);
            DependencyContainer.InitializeGraphQlServices(services, this._configuration);
            DependencyContainer.InitializeServices(services, this._configuration);
            DependencyContainer.InitializeRepositories(services, this._configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints((routes) =>
            //{
            //    routes.MapControllerRoute(
            //        name: "Default",
            //        pattern: "api/{controller}/{action}/{id?}",
            //        defaults: new { controller = "Books", action = "GetBooks" });
            //});

            app.UseEndpoints((routes) =>
            {
                routes.MapControllers();
            });

            app.UseGraphiQl("/graphql");

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1.0.0-beta/swagger.json", "v1.0.0-beta");
                options.RoutePrefix = string.Empty;
            });
        }
    }
}
