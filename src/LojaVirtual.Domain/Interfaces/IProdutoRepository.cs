using LojaVirtual.Business.Core;
using LojaVirtual.Business.Entities;

namespace LojaVirtual.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetByCategoria(Guid categoriaId, CancellationToken cancellationToken);
        Task<IEnumerable<Produto>> GetAllWithCategoria(CancellationToken cancellationToken);
        Task<Produto> GetWithCategoriaById(Guid id, CancellationToken cancellationToken);
    }
}
