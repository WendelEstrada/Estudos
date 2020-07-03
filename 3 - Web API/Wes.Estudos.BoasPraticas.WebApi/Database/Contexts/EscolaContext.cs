using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wes.Estudos.BoasPraticas.WebApi.Database.Mappings;
using Wes.Estudos.BoasPraticas.WebApi.V1.Models;

namespace Wes.Estudos.BoasPraticas.WebApi.Database.Contexts
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public virtual DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AlunoMapping.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
