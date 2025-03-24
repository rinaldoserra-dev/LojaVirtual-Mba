using LojaVirtual.Core.Business.Entities;
using LojaVirtual.Core.Business.Interfaces;
using LojaVirtual.Core.Business.Models.Categoria;

namespace LojaVirtual.Core.Business.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly INotifiable _notifiable;
        public CategoriaService(
            ICategoriaRepository categoriaRepository, 
            INotifiable notifiable)
        {
            _categoriaRepository = categoriaRepository;
            _notifiable = notifiable;
        }

        public async Task Insert(CategoriaRequest request, CancellationToken cancellationToken)
        {
            var categoria = new Categoria(request.Nome, request.Descricao);
            //verifica se o nome da categoria já existe
            if (await _categoriaRepository.Exists(categoria.Nome, cancellationToken))
            {
                _notifiable.AddNotification(new Notifications.Notification("Nome da categoria já existente"));
                return;
            }
            await _categoriaRepository.Insert(categoria, cancellationToken);
            await _categoriaRepository.SaveChanges(cancellationToken);
        }

        public async Task Edit(CategoriaRequest request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetById(request.Id, cancellationToken);
            if(categoria is null)
            {
                _notifiable.AddNotification(new Notifications.Notification("Categoria não encontrada."));
                return;
            }
            if (categoria.Nome != request.Nome &&
                await _categoriaRepository.Exists(request.Nome, cancellationToken))
            {
                _notifiable.AddNotification(new Notifications.Notification("Nome da categoria já existente."));
                return;
            }

            categoria.Edit(request.Nome, request.Descricao);

            await _categoriaRepository.Edit(categoria, cancellationToken);
            await _categoriaRepository.SaveChanges(cancellationToken);
        }

        public async Task Remove(Guid id, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetWithProduto(id, cancellationToken);
            if (categoria is null)
            {
                _notifiable.AddNotification(new Notifications.Notification("Categoria não encontrada."));
                return;
            }
            if (categoria.Produtos.Any())
            {
                _notifiable.AddNotification(new Notifications.Notification("Categoria possui produtos associados."));
                return;
            }

            await _categoriaRepository.Remove(categoria, cancellationToken);
            await _categoriaRepository.SaveChanges(cancellationToken);
        }

        public async Task<IEnumerable<CategoriaResponse>> List(CancellationToken cancellationToken)
        {
            var categorias = await _categoriaRepository.List(cancellationToken);
            return categorias.Select(CategoriaResponse.FromCategoria);
        }

        public async Task<CategoriaResponse> GetById(Guid id, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetById(id, cancellationToken);
            if (categoria is null)
            {
                _notifiable.AddNotification(new Notifications.Notification("Categoria não encontrada."));
            }
            return CategoriaResponse.FromCategoria(categoria!);
        }
    }
}
