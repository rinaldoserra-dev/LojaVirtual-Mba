namespace LojaVirtual.Core.Business.Entities
{
    public class Vendedor: Entity
    {
        public Vendedor(Guid id, string email)
        {
            Id = id;
            Email = email;
        }
        public string Email { get; private set; }
    }
}
