using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Models
{
    public class Cidade
    {
        [Key]
        public int CidadeId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Nome da Cidade")]
        public string CidadeNome { get; set; }       
        
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Codigo Cidade IBGE")]
        public string? CidadeCodigoIbge { get; set; }

        [ForeignKey("Estados")]
        public int EstadoId { get; set; }
        public Estado? Estado { get; set; }

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
