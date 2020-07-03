using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wes.Estudos.BoasPraticas.WebApi.Database.Contexts;
using Wes.Estudos.BoasPraticas.WebApi.V1.Models;

namespace Wes.Estudos.BoasPraticas.WebApi.Configuration
{
    public static class SqlConfiguration
    {
        public static void AddSql(this IServiceCollection services)
        {
            var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

            services.AddDbContext<EscolaContext>(options =>
            {
                options.UseInMemoryDatabase("InMemory");
                options.UseInternalServiceProvider(serviceProvider);
                options.EnableSensitiveDataLogging();
            });

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var appContext = scope.ServiceProvider.GetRequiredService<EscolaContext>();

                try
                {
                    appContext.Database.EnsureCreated();

                    appContext.Alunos.Add(new Aluno { Registro = 1, Nome = "José" });
                    appContext.Alunos.Add(new Aluno { Registro = 2, Nome = "Maria" });
                    appContext.Alunos.Add(new Aluno { Registro = 3, Nome = "João" });
                    appContext.Alunos.Add(new Aluno { Registro = 4, Nome = "Elizabeth" });
                    appContext.Alunos.Add(new Aluno { Registro = 5, Nome = "Lucas" });
                    appContext.Alunos.Add(new Aluno { Registro = 6, Nome = "Leonardo" });
                    appContext.Alunos.Add(new Aluno { Registro = 7, Nome = "Amanda" });
                    appContext.Alunos.Add(new Aluno { Registro = 8, Nome = "Vinicius" });
                    appContext.Alunos.Add(new Aluno { Registro = 9, Nome = "Gabriela" });
                    appContext.Alunos.Add(new Aluno { Registro = 10, Nome = "Enzo" });

                    appContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
