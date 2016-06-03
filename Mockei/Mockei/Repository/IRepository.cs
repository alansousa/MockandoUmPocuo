namespace Mockei.Repository
{
    public interface IRepository<TEntity> : IAddOnlyRepository<TEntity>,
        IUpdateOnlyRepository<TEntity>, IDeleteOnlyRepository<TEntity>,
        IReadOnlyRepository<TEntity>
        where TEntity : class 
    {
    }
}
