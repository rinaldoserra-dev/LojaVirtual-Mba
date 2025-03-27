using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Api.Models
{
    public class ProdutoModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        public string ImagemUpload { get; set; }

        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Estoque { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CategoriaId { get; set; }
        
        [ScaffoldColumn(false)]
        public string NomeCategoria { get; set; }
    }
}
