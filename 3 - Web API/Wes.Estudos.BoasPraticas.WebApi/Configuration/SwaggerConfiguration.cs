using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Wes.Estudos.BoasPraticas.WebApi.Configuration.SwaggerConfig;

namespace Wes.Estudos.BoasPraticas.WebApi.Configuration
{
    public static class SwaggerConfiguration
    {
        private static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
                return Path.Combine(basePath, fileName);
            }
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.IncludeXmlComments(XmlCommentsFilePath);
                
                swagger.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });

                swagger.OperationFilter<AuthOperationFilter>();

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }

        public static void AddSwaggerUI(this IApplicationBuilder application, IApiVersionDescriptionProvider provider)
        {
            application.UseSwagger();
            application.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });
        }
    }
}
