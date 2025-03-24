namespace LojaVirtual.Core.Business.Entities
{
    public class Vendedor: Entity
    {
        public Vendedor(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public string Nome { get; private set; }
    }
}
