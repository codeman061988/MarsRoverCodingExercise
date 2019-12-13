using System;
using System.IO;
using FluentValidation.AspNetCore;
using Flurl.Http.Configuration;
using MarsRoverCodingExercise.Core.Interfaces;
using MarsRoverCodingExercise.Infrastructure.Clients;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MarsRoverCodingExercise.Web
{
    /// <summary>
    /// Provides dependency injection for the components used by the Web project
    /// </summary>
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class
        /// </summary>
        /// <param name="env"></param>
        /// <param name="config"></param>
        public Startup(IWebHostEnvironment env, IConfiguration config)
        {
            _env = env;
            _config = config;
        }

        /// <summary>
        /// Adds / configures services using dependency injection
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                var configuredCorsOrigins = _config.GetSection("CorsOrigins").Get<string[]>();

                options.AddPolicy("CorsPolicy",
                builder =>
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins(configuredCorsOrigins)
                .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mars Rover Coding Exercise APIs",
                    Description = "Provides headless services for the excercise"
                });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme (Token only). Example: \"Authorization: {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                c.AddSecurityRequirement(securityRequirement);

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "MarsRoverCodingExercise.Web.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.AddMvcCore(options => options.EnableEndpointRouting = false)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddApiExplorer();

            services.AddApiVersioning(options =>
            {
                options.ApiVersionReader = new HeaderApiVersionReader("api-version");
                options.ReportApiVersions = true;
            });

            // API DI Mapping

            // Core DI Mapping


            // Infrastructure DI Mapping
            services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            services.AddScoped<INasaClient, NasaClient>();

        }

        /// <summary>
        /// Configures services
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mars Rover Coding Exercise API Documentation");
                c.DocExpansion(DocExpansion.None);
            });
            app.UseCors("CorsPolicy");
            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
        }
    }
}
