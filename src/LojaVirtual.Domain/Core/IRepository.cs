using System.Linq.Expressions;

namespace LojaVirtual.Business.Core
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        public Task Insert(TEntity entity, CancellationToken cancellationToken);
        public Task<TEntity> GetById(Guid id, CancellationToken cancellationToken);
        public Task<List<TEntity>> List(CancellationToken cancellationToken);
        public Task Edit(TEntity entity, CancellationToken cancellationToken);
        public Task Remove(TEntity entity, CancellationToken cancellationToken);
        public Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        public Task<int> SaveChanges(CancellationToken cancellationToken);
    }
}
