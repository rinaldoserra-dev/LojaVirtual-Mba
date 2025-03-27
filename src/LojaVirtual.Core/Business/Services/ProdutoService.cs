using LojaVirtual.Core.Business.Entities;
using LojaVirtual.Core.Business.Interfaces;

namespace LojaVirtual.Core.Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly INotifiable _notifiable;
        public ProdutoService(
            ICategoriaRepository categoriaRepository,
            IProdutoRepository produtoRepository,
            INotifiable notifiable)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
            _notifiable = notifiable;
        }
        public Task Insert(Produto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task Remove(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task Edit(Produto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produto>> GetAllWithCategoria(CancellationToken cancellationToken)
        {
            return await _produtoRepository.GetAllWithCategoria(cancellationToken);
        }

        public Task<IEnumerable<Produto>> GetByCategoria(Guid categoriaId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetById(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetWithCategoriaById(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        
        public async Task<IEnumerable<Produto>> List(CancellationToken cancellationToken)
        {
            return await _produtoRepository.List(cancellationToken);
        }        
    }
}
