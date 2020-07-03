using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wes.Estudos.BoasPraticas.WebApi.V1.Models;

namespace Wes.Estudos.BoasPraticas.WebApi.Database.Mappings
{
    public static class AlunoMapping
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.Registro);
                entity.Property(e => e.Nome).IsRequired();
            });
        }
    }
}
