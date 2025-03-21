using LojaVirtual.Business.Entities;
using LojaVirtual.Business.Interfaces;
using LojaVirtual.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Infra.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(LojaVirtualContext context) : base(context) { }

        public async Task<Categoria> GetWithProduto(Guid id)
        {
            return await Db.CategoriaSet
                            .Include(c => c.Produtos)
                            .FirstOrDefaultAsync(c => c.Id == id);
                                 
        }
    }
}
