using LojaVirtual.Core.Business.Entities;
using LojaVirtual.Core.Business.Interfaces;
using LojaVirtual.Core.Business.Notifications;

namespace LojaVirtual.Core.Business.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly INotifiable _notifiable;
        private readonly IAppIdentifyUser _appIdentifyUser;
        public ProdutoService(
            ICategoriaRepository categoriaRepository,
            IProdutoRepository produtoRepository,
            INotifiable notifiable,
            IAppIdentifyUser appIdentifyUser)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
            _notifiable = notifiable;
            _appIdentifyUser = appIdentifyUser;
        }
        public async Task Insert(Produto request, CancellationToken cancellationToken)
        {
            //verifica se a categoria existe
            if (await _categoriaRepository.GetById(request.CategoriaId, cancellationToken) is null)
            {
                _notifiable.AddNotification(new Notification("Categoria não existente."));
            }
            //verifica se o nome do produto já existe
            if (await _produtoRepository.Exists(request.Nome, cancellationToken))
            {
                _notifiable.AddNotification(new Notification("Nome do produto já existente."));                
            }
            await _produtoRepository.Insert(request, cancellationToken);
            await _produtoRepository.SaveChanges(cancellationToken);
        }
        public async Task Remove(Guid id, CancellationToken cancellationToken)
        {
            var produto = await GetSelfProdutoById(id, cancellationToken);
            if (produto is null)
            {
                _notifiable.AddNotification(new Notification("Produto não encontrado."));
                return;
            }

            await _produtoRepository.Remove(produto, cancellationToken);
            await _produtoRepository.SaveChanges(cancellationToken);
        }
        public async Task Edit(Produto request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetById(request.CategoriaId, cancellationToken);
            if (categoria is null)
            {
                _notifiable.AddNotification(new Notification("Categoria não encontrada."));
                return;
            }
            var produtoOrigem = await _produtoRepository.GetById(request.Id, cancellationToken);
            if (produtoOrigem.Nome != request.Nome &&
                await _produtoRepository.Exists(request.Nome, cancellationToken))
            {
                _notifiable.AddNotification(new Notification("Nome do produto já existente."));
                return;
            }

            produtoOrigem.Edit(request.Nome, request.Descricao, request.Imagem, request.Preco, request.Estoque, request.CategoriaId);

            await _produtoRepository.Edit(produtoOrigem, cancellationToken);
            await _produtoRepository.SaveChanges(cancellationToken);
        }

        public async Task<IEnumerable<Produto>> GetAllWithCategoria(CancellationToken cancellationToken)
        {
            return await _produtoRepository.GetAllWithCategoria(cancellationToken);
        }

        public async Task<IEnumerable<Produto>> GetByCategoria(Guid categoriaId, CancellationToken cancellationToken)
        {
            return await _produtoRepository.GetByCategoria(categoriaId, cancellationToken);
        }
        
        public Task<Produto> GetWithCategoriaById(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        
        public async Task<IEnumerable<Produto>> List(CancellationToken cancellationToken)
        {
            return await _produtoRepository.List(new Guid(_appIdentifyUser.GetUserId()), cancellationToken);
        }
        public async Task<Produto> GetSelfProdutoById(Guid id, CancellationToken cancellationToken)
        {
            return await _produtoRepository.GetSelfProdutoById(id, new Guid(_appIdentifyUser.GetUserId()), cancellationToken);
        }

        #region Vitrine
        public async Task<IEnumerable<Produto>> ListVitrine(CancellationToken cancellationToken)
        {
            return await _produtoRepository.List(cancellationToken);
        }
        public async Task<Produto> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _produtoRepository.GetById(id, cancellationToken);
        }
        #endregion
       
    }
}
