using LojaVirtual.Business.Core;

namespace LojaVirtual.Business.Entities
{
    public class Vendedor: Entity
    {
        public Vendedor() { }

        private readonly List<Produto> _produtos;
        public IReadOnlyCollection<Produto> Produtos => _produtos;
    }
}
