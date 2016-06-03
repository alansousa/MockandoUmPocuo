

using System;

namespace Mockei.Repository
{
    public interface IDeleteOnlyRepository<in TEntity> : IDisposable where TEntity : class
    {
        void Delete(TEntity id);
    }
}
