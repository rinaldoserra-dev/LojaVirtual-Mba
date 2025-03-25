using LojaVirtual.Core.Business.Entities;

namespace LojaVirtual.Core.Business.Interfaces
{
    public interface IVendedorRepository
    {
        Task Insert(Vendedor request, CancellationToken cancellationToken);
    }
}
