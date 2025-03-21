using LojaVirtual.Business.Entities;
using LojaVirtual.Business.Interfaces;
using LojaVirtual.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LojaVirtual.Infra.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly LojaVirtualContext _context;

        public CategoriaRepository(LojaVirtualContext context)
        {
            _context = context;
        }

        public async Task Insert(Categoria entity, CancellationToken cancellationToken)
        {
            await _context.CategoriaSet.AddAsync(entity, cancellationToken);
        }
        public Task Edit(Categoria entity, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.CategoriaSet.Update(entity));
        }

        public async Task<Categoria> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _context.CategoriaSet.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<Categoria> GetWithProduto(Guid id, CancellationToken cancellationToken)
        {
            return await _context.CategoriaSet
                            .Include(c => c.Produtos)
                            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<List<Categoria>> List(CancellationToken cancellationToken)
        {
            return await _context.CategoriaSet.ToListAsync(cancellationToken);
        }

        public async Task Remove(Categoria categoria, CancellationToken cancellationToken)
        {
            Task.FromResult(_context.CategoriaSet.Remove(categoria));
        }

        public async Task<IEnumerable<Categoria>> Search(Expression<Func<Categoria, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.CategoriaSet.AsNoTracking().Where(predicate).ToListAsync(cancellationToken);
        }
        public async Task<int> SaveChanges(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
