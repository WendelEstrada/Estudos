using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Wes.Estudos.BoasPraticas.WebApi.Configuration.SwaggerConfig
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Alunos",
                Version = description.ApiVersion.ToString(),
                Description = "Uma Web API em ASP.NET Core 3.1",
                Contact = new OpenApiContact { Name = "Wendel Estrada" },
                License = new OpenApiLicense
                {
                    Name = "MIT",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description += " Essa versão da API está descontinuada";
            }

            return info;
        }
    }
}
