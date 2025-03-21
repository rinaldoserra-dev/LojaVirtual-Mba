using LojaVirtual.Business.Core;
using LojaVirtual.Business.Entities;

namespace LojaVirtual.Business.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        public Task<Categoria> GetWithProduto(Guid id, CancellationToken cancellationToken);
    }
}
