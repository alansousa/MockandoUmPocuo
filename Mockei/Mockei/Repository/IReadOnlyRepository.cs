using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mockei.Repository
{
    public interface IReadOnlyRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Find(int id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression);
        List<TEntity> GetAll();
        List<TEntity> GetMany(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> QueryCondition(Expression<Func<TEntity, bool>> condition);
        IQueryable<TEntity> QueryAll();
    }
}
