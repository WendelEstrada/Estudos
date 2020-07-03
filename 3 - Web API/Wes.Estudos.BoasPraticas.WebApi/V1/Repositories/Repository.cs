using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wes.Estudos.BoasPraticas.WebApi.Database.Contexts;
using Wes.Estudos.BoasPraticas.WebApi.V1.Repositories.Interfaces;

namespace Wes.Estudos.BoasPraticas.WebApi.V1.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected EscolaContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(EscolaContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Adicionar(TEntity entity)
        {
            var entry = Db.Entry(entity);
            if (entry.State == EntityState.Detached)
                DbSet.Attach(entity);

            entry.State = EntityState.Added;
            return entity;
        }

        public TEntity Atualizar(TEntity entity)
        {
            var entry = Db.Entry(entity);
            entry.State = EntityState.Modified;
            return entity;
        }

        public bool Deletar(TEntity entity)
        {
            if (entity != null)
            {
                var entry = Db.Entry(entity);
                if (entry.State == EntityState.Detached)
                    DbSet.Attach(entity);

                Db.Set<TEntity>().Remove(entity);
                return true;
            }

            return false;
        }

        public IQueryable<TEntity> ObterTodos()
        {
            return Db.Set<TEntity>().AsNoTracking();
        }

        public TEntity ObterPorID(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public TEntity Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Set<TEntity>().AsNoTracking().FirstOrDefault(predicate);
        }

        public void Salvar()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
