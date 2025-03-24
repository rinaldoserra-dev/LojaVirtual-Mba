using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Core.Business.Models.Categoria
{
    public class CategoriaRequest
    {
        public Guid Id { get; set; } = Guid.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa estar entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa estar entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Descricao { get; set; }
    }
}
