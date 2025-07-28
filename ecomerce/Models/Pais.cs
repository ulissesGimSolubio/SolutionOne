using System.ComponentModel.DataAnnotations;

namespace Ecomerce.Models
{
    public class Pais
    {
        [Key]
        public int PaisId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [Display(Name = "Nome Nacional")]
        public string PaisNome { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Nome Inglês")]
        public string? PaisNomeIngles { get; set; }

        [StringLength(12, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Cód. ISO")]
        public string? PaisIsoCodigo { get; set; }

        [StringLength(12, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Códi. Mundial.")]
        public string? PaisCodigo { get; set; }

        [StringLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Moeda do País")]
        public string? PaisMoeda { get; set; }

        [StringLength(6, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Abrev. Moeda")]
        public string? PaisMoedaAbrev { get; set; }

        public List<Estado>? Estados { get; set; }

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
