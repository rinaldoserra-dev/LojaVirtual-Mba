using LojaVirtual.Core.Business.Entities;

namespace LojaVirtual.Core.Business.Interfaces
{
    public interface IProdutoService
    {
        Task Insert(Produto request, CancellationToken cancellationToken);
        Task Edit(Produto request, CancellationToken cancellationToken);
        Task Remove(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Produto>> List(CancellationToken cancellationToken);
        Task<IEnumerable<Produto>> ListVitrine(CancellationToken cancellationToken);
        Task<Produto> GetById(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Produto>> GetByCategoria(Guid categoriaId, CancellationToken cancellationToken);
        Task<IEnumerable<Produto>> GetAllWithCategoria(CancellationToken cancellationToken);
        Task<Produto> GetWithCategoriaById(Guid id, CancellationToken cancellationToken);
        Task<Produto> GetSelfProdutoById(Guid id, CancellationToken cancellationToken);
    }
}
