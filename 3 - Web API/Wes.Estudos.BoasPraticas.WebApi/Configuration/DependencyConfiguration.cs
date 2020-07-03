using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wes.Estudos.BoasPraticas.WebApi.Configuration.SwaggerConfig;
using Wes.Estudos.BoasPraticas.WebApi.V1.Models;
using Wes.Estudos.BoasPraticas.WebApi.V1.Repositories;
using Wes.Estudos.BoasPraticas.WebApi.V1.Repositories.Interfaces;
using Wes.Estudos.BoasPraticas.WebApi.V1.Services;
using Wes.Estudos.BoasPraticas.WebApi.V1.Services.Interfaces;
using Wes.Estudos.BoasPraticas.WebApi.V1.Validations;

namespace Wes.Estudos.BoasPraticas.WebApi.Configuration
{
    public static class DependencyConfiguration
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            // Configurations
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // Services
            services.AddTransient<IAlunoService, AlunoService>();

            // Repositories
            services.AddTransient<IRepository<Aluno>, Repository<Aluno>>();
        }
    }
}
