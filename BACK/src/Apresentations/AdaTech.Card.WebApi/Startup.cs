using AdaTech.Card.WebApi.Filters;
using AdaTech.Infra.Ioc;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace AdaTech.Card.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<LoggingFilterAttribute>();
            });

            services.AddEndpointsApiExplorer();

            var corsBuilder = new CorsPolicyBuilder();

            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();

            services.AddCors(options => {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            services.AddSwaggerGen();

            services.RegisterMediator();
            services.RegisterRepositories();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("SiteCorsPolicy");
        }
    }
}
