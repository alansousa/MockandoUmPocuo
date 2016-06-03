using System;

namespace Mockei.Repository
{
    public interface IAddOnlyRepository<in TEntity> : IDisposable  where TEntity : class 
    {
        void Add(TEntity entity);
    }
}
