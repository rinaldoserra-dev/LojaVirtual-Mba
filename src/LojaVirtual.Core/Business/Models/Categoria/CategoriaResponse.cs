using System.ComponentModel.DataAnnotations;
using DomainEntity = LojaVirtual.Core.Business.Entities;

namespace LojaVirtual.Core.Business.Models.Categoria
{
    public class CategoriaResponse
    {
        public CategoriaResponse(Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid Id { get; set; } = Guid.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa estar entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa estar entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Descricao { get; set; }

        public static CategoriaResponse FromCategoria(DomainEntity.Categoria categoria)
        =>
            new(
                categoria.Id,
                categoria.Nome,
                categoria.Descricao
            );
    }
}
