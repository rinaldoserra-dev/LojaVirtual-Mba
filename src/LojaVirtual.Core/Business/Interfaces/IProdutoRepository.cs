using LojaVirtual.Core.Business.Entities;

namespace LojaVirtual.Core.Business.Interfaces
{
    public interface IProdutoRepository : IDisposable
    {
        public Task Insert(Produto produto, CancellationToken cancellationToken);
        public Task<Produto> GetById(Guid id, CancellationToken cancellationToken);
        Task<Produto> GetSelfProdutoById(Guid id, Guid vendedorId, CancellationToken cancellationToken);
        public Task<List<Produto>> List(CancellationToken cancellationToken);
        public Task<List<Produto>> List(Guid vendedorId, CancellationToken cancellationToken);
        public Task Edit(Produto produto, CancellationToken cancellationToken);
        public Task Remove(Produto produto, CancellationToken cancellationToken);
        public Task<bool> Exists(string nome, CancellationToken cancellationToken);
        Task<IEnumerable<Produto>> GetByCategoria(Guid categoriaId, CancellationToken cancellationToken);
        Task<IEnumerable<Produto>> GetAllWithCategoria(CancellationToken cancellationToken);
        Task<IEnumerable<Produto>> GetAllSelfProdutoWithCategoria(Guid vendedorid, CancellationToken cancellationToken);
        Task<Produto> GetWithCategoriaById(Guid id, CancellationToken cancellationToken);
        public Task<int> SaveChanges(CancellationToken cancellationToken);
    }
}
