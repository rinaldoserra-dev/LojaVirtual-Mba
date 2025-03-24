using LojaVirtual.Core.Business.Entities;
using LojaVirtual.Core.Business.Models.Categoria;

namespace LojaVirtual.Core.Business.Interfaces
{
    public interface ICategoriaService
    {
        Task Insert(CategoriaRequest request, CancellationToken cancellationToken);
        Task Edit(CategoriaRequest request, CancellationToken cancellationToken);
        Task Remove(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<CategoriaResponse>> List(CancellationToken cancellationToken);
        Task<CategoriaResponse> GetById(Guid id, CancellationToken cancellationToken);
    }
}
