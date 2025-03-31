using LojaVirtual.Core.Business.Entities;

namespace LojaVirtual.Mvc.Models
{
    public class ProdutoVitrineViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
        public Guid? CategoriaId { get; set; }
    }
}
