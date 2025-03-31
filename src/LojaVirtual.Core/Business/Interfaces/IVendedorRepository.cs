using LojaVirtual.Core.Business.Entities;

namespace LojaVirtual.Core.Business.Interfaces
{
    public interface IVendedorRepository : IDisposable
    {
        Task Insert(Vendedor request, CancellationToken cancellationToken);
        public Task<int> SaveChanges(CancellationToken cancellationToken);
    }
}
