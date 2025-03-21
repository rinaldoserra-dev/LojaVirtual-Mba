using LojaVirtual.Business.Core;
using LojaVirtual.Business.Entities;

namespace LojaVirtual.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetByFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> GetAllWithFornecedor();
        Task<Produto> GetWithFornecedorById(Guid id);
    }
}
