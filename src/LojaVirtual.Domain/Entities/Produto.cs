using LojaVirtual.Business.Core;

namespace LojaVirtual.Business.Entities
{
    public class Produto: Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }
    }
}
