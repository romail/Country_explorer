using Country_explorer_API.Interfaces;
using Country_explorer_API.Services;
using Country_explorer_API.Middleware;

namespace Country_explorer_API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpClient();
            services.AddTransient<ICountryService, CountryService>();

            services.AddCors(options =>
            {
                options.AddPolicy("FrontendApp",
                 builder => builder.WithOrigins("https://localhost:4200")
                                     .AllowAnyHeader()
                                     .AllowAnyMethod()
                                     .AllowCredentials());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<ExceptionHandlingMiddleware> logger)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMiddleware<ExceptionHandlingMiddleware>(logger);

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Country explorer API V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseCors("FrontendApp");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("/index.html");
            });
        }
    }
}
