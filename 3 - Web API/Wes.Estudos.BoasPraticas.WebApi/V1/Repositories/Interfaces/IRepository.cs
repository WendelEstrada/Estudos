using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Wes.Estudos.BoasPraticas.WebApi.V1.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity entity);
        TEntity Atualizar(TEntity entity);
        bool Deletar(TEntity entity);
        IQueryable<TEntity> ObterTodos();
        TEntity ObterPorID(int id);
        TEntity Buscar(Expression<Func<TEntity, bool>> predicate);
        void Salvar();
    }
}
