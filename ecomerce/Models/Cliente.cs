using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Composition;
using Microsoft.AspNetCore.Http;

namespace Ecomerce.Models
{
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(18, MinimumLength = 14, ErrorMessage = "O Campo {0} deve ter entre {2} e {1} caracteres")]
        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Tipo Pessoa")]
        public TipoPessoa TPessoa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "O endereço de e-mail não é válido.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O Campo {0} deve ter entre {2} e {1} caracteres")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O Campo {0} deve ter entre {2} e {1} caracteres")]
        [Display(Name = "Nome | Fantasia")]
        public string Nome { get; set; }

        [MaxLength(100, ErrorMessage = "O campo {0} deve ter no máximo 100 caracteres.")]
        [Display(Name = "Razão social")]
        public string? NomeRazaoSoc { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo 50 caracteres.")]
        [Display(Name = "Como deseja ser chamado")]
        public string? Apelido { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Gênero")]
        public Genero Genero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [StringLength(16, MinimumLength = 16, ErrorMessage = "O Campo {0} deve ter entre {2} e {1} caracteres")]
        [Display(Name = "Telefone Celular")]
        public string? Celular { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "O Campo {0} deve ter entre {2} e {1} caracteres")]
        [Display(Name = "Telefone Fixo")]
        public string? TelefoneFixo { get; set; }

        [Display(Name = "Informações adicionais")]
        public string? Info { get; set; }

        [Display(Name = "Ativo/Inativo")]
        public bool Ativo { get; set; }

        [Display(Name = "Abertura em")]
        public DateTime Created { get; set; }

        [Display(Name = "Atualizado em")]
        public DateTime Updated { get; set; }

        [Display(Name = "Nome da imagem")]
        public string? Image { get; set; }

        [Display(Name = "Usuário que criou")]
        public string? UserInserted { get; set; }        

        [Display(Name = "Usuário que atualizou")]        
        public string? UserUpdated { get; set; }

        [NotMapped]
        [Display(Name = "Nome da imagem")]
        public IFormFile UpImage { get; set; }

        [ForeignKey("enderecos")]
        public int? EnderecoId { get; set; }
        public List<Endereco>? Enderecos { get; set; }
    }

    public enum Genero
    {
        FEMININO,
        MASCULINO,
        OUTRO
    }

    public enum TipoPessoa
    {
        FISICA,
        JURIDICA
    }
}
