using LojaVirtual.Business.Core;

namespace LojaVirtual.Business.Entities
{
    public class Categoria: Entity
    {
        protected Categoria() { }
        public Categoria(string nome, string descricao)
        {
            Nome = nome.Trim();
            Descricao = descricao.Trim();
            _produtos = new List<Produto>();
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        private readonly List<Produto> _produtos;
        public IReadOnlyCollection<Produto> Produtos => _produtos;

        public void Edit(string nome, string descricao)
        {
            Nome = nome.Trim();
            Descricao = descricao.Trim();
        }
        public void AddProduto(Produto produto)
        {
            _produtos.Add(produto);
        }                
    }
}
