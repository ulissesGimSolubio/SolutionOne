using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }        

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(10, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres e no formato 99.999-999.")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }
       
        [Display(Name = "Número")]
        public int? Numero { get; set; }

        [StringLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Complemento de endereço e informações")]
        public string? Complemento { get; set; }


        [StringLength(250, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Informações de Entrega")]
        public string? InformacaoReferencia { get; set; }

        
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [Display(Name = "Bairro de localização")]
        public string Bairro { get; set; }

        [ForeignKey("Cidades")]
        [Display(Name = "Localizado na Cidade")]
        public int? CidadeId { get; set; }
        public Cidade? Cidade { get; set; }

        [Display(Name = "Endereço Principal?")]
        public bool EnderecoPrincipal { get; set; }        

        [ForeignKey("Clientes")]
        [Display(Name = "Pertence ao cliente")]
        public string? ClienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [Display(Name = "Ativo/Inativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Abertura em")]
        public DateTime? Created { get; set; }

        [Display(Name = "Atualizado em")]
        public DateTime? Updated { get; set; }

        [Display(Name = "Usuário que criou")]
        public string? UserInserted { get; set; }

        [Display(Name = "Usuário que atualizou")]
        public string? UserUpdated { get; set; }
    }
}
