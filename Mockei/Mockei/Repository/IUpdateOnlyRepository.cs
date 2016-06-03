using System;

namespace Mockei.Repository
{
    public interface IUpdateOnlyRepository<in TEntity> : IDisposable where TEntity : class
    {
        void Update(TEntity entity);

    }
}
