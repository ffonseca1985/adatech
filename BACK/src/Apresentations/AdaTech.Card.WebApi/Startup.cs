using AdaTech.Card.WebApi.Filters;
using AdaTech.Infra.Ioc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace AdaTech.Card.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<LoggingFilterAttribute>();
                options.Filters.Add(new AuthorizeFilter());
            });

            services.AddEndpointsApiExplorer();

            var corsBuilder = new CorsPolicyBuilder();

            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();

            services.AddCors(policyBuilder =>
                policyBuilder.AddDefaultPolicy(policy =>
                    policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader().AllowAnyMethod())
            );

            services.AddSwaggerGen();

            services.RegisterMediator();
            services.RegisterRepositories();
            services.RegisterSecurity();

            var secretKey = _configuration["Security:Key"];

            var key = Encoding.ASCII.GetBytes(secretKey!);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(options =>
            {
                options.DocInclusionPredicate((name, api) => true);
                options.CustomSchemaIds(type => type.ToString());

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. <br/> 
                      Enter 'Bearer' [space] and then your token in the text input below. <br/>
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                          new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            
        }
    }
}
