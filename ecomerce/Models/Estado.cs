using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Models
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(2, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 2)]
        [Display(Name = "Sigla da UF")]
        public string EstadoSigla { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Nome do Estado")]
        public string EstadoNome { get; set; }

        [StringLength(12, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Cód. IBGE do Estado")]
        public string? EstadoCodIbge { get; set; }

        [ForeignKey("Paises")]
        [Display(Name = "País em que o estado se encontra")]
        public int PaisId { get; set; }
        public Pais? Pais { get; set; }

        public List<Cidade>? Cidades { get; set; }

        [Display(Name = "Ativo/Inativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Abertura em")]
        public DateTime Created { get; set; }

        [Display(Name = "Atualizado em")]
        public DateTime Updated { get; set; }

        [Display(Name = "Usuário que criou")]
        public string? UserInserted { get; set; }

        [Display(Name = "Usuário que atualizou")]
        public string? UserUpdated { get; set; }

    }
}
