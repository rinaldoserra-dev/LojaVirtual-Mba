using LojaVirtual.Business.Core;
using LojaVirtual.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LojaVirtual.Infra.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly LojaVirtualContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(LojaVirtualContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }
        
        public virtual async Task Edit(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return DbSet.FirstOrDefault(e => e.Id == id);
        }

        public virtual async Task<List<TEntity>> List()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }
        
        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
