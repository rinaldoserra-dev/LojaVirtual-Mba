using LojaVirtual.Core.Business.Entities;
using LojaVirtual.Core.Business.Interfaces;
using LojaVirtual.Core.Infra.Context;

namespace LojaVirtual.Core.Infra.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly LojaVirtualContext _context;

        public VendedorRepository(LojaVirtualContext context)
        {
            _context = context;
        }
        public async Task Insert(Vendedor request, CancellationToken cancellationToken)
        {
            await _context.VendedorSet.AddAsync(request, cancellationToken);
        }       
    }
}
