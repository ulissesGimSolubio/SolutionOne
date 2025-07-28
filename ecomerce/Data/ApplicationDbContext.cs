using Ecomerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração das entidades usando Fluent API

            modelBuilder.Entity<Pais>(entity =>
            {
                object value = entity.HasKey(p => p.PaisId);

                entity.Property(p => p.PaisId)
                    .IsRequired()
                    .HasColumnName("pais_id");
                entity.Property(p => p.PaisNome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("pais_nome");
                entity.Property(p => p.PaisNomeIngles)
                    .HasMaxLength(100)
                    .HasColumnName("pais_nome_en");
                entity.Property(p => p.PaisIsoCodigo)
                    .HasMaxLength(12)
                    .HasColumnName("pais_iso_code");
                entity.Property(p => p.PaisCodigo)
                    .HasMaxLength(12)
                    .HasColumnName("pais_code");
                entity.Property(p => p.PaisMoeda)
                    .HasMaxLength(20)
                    .HasColumnName("pais_moeda");
                entity.Property(p => p.PaisMoedaAbrev)
                    .HasMaxLength(6)
                    .HasColumnName("pais_moeda_abrev");
                entity.Property(p => p.Ativo)
                    .HasDefaultValue(true)
                    .HasColumnName("pais_ativo");
                entity.Property(p => p.Created)
                    .IsRequired()
                    .HasDefaultValue(DateTime.Now)
                    .HasColumnName("pais_created");                
                entity.Property(p => p.Updated)
                    .IsRequired()
                    .HasDefaultValue(DateTime.Now)
                    .HasColumnName("pais_updated");
                entity.Property(p => p.UserInserted)
                    .HasMaxLength(450)
                    .HasColumnName("pais_user_created");
                entity.Property(p => p.UserUpdated)
                    .HasMaxLength(450)
                    .HasColumnName("pais_user_updated");

                modelBuilder.Entity<Pais>().ToTable("paises");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                object value = entity.HasKey(e => e.EstadoId);

                entity.Property(e => e.EstadoId)
                    .IsRequired()
                    .HasColumnName("estado_id");
                entity.Property(e => e.EstadoSigla)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("estado_sigla");
                entity.Property(e => e.EstadoNome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("estado_nome");
                entity.Property(e => e.EstadoCodIbge)                    
                    .HasMaxLength(12)
                    .HasColumnName("estado_cod_ibge");
                entity.Property(e => e.PaisId)
                    .IsRequired()
                    .HasColumnName("estado_pais_id");
                entity.Property(e => e.Ativo)
                    .HasDefaultValue(true)
                    .HasColumnName("estado_ativo");
                entity.Property(e => e.Created)
                    .IsRequired()
                    .HasDefaultValue(DateTime.Now)
                    .HasColumnName("estado_created");
                entity.Property(e => e.Updated)
                    .IsRequired()
                    .HasDefaultValue(DateTime.Now)
                    .HasColumnName("estado_updated");
                entity.Property(e => e.UserInserted)
                    .HasMaxLength(450)
                    .HasColumnName("estado_user_created");
                entity.Property(e => e.UserUpdated)
                    .HasMaxLength(450)
                    .HasColumnName("estado_user_updated");

                modelBuilder.Entity<Estado>()
                    .HasOne(e => e.Pais)             // Define a relação com a entidade Pais
                    .WithMany(p => p.Estados)        // Indica que um país pode ter vários estados
                    .HasForeignKey(e => e.PaisId) // Define a chave estrangeira
                    .OnDelete(DeleteBehavior.Restrict) // Define o tipo de exclusão
                    .HasConstraintName("FK_Estado_Pais");

                modelBuilder.Entity<Estado>().ToTable("estados");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                object value = entity.HasKey(c => c.CidadeId);

                entity.Property(c => c.CidadeId)
                    .IsRequired()
                    .HasColumnName("cidade_id");
                entity.Property(c => c.CidadeNome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("cidade_nome");
                entity.Property(c => c.CidadeCodigoIbge)
                    .HasMaxLength(100)
                    .HasColumnName("cidade_codigo_ibge");
                entity.Property(c => c.EstadoId)
                    .IsRequired()
                    .HasColumnName("cidade_estado_id");
                entity.Property(c => c.Ativo)
                    .HasDefaultValue(true)
                    .HasColumnName("cidade_ativo");
                entity.Property(c => c.Created)
                    .IsRequired()
                    .HasDefaultValue(DateTime.Now)
                    .HasColumnName("cidade_created");
                entity.Property(c => c.Updated)
                    .IsRequired()
                    .HasDefaultValue(DateTime.Now)
                    .HasColumnName("cidade_updated");
                entity.Property(c => c.UserInserted)
                    .HasMaxLength(450)
                    .HasColumnName("cidade_user_created");
                entity.Property(c => c.UserUpdated)
                    .HasMaxLength(450)
                    .HasColumnName("cidade_user_updated");

                modelBuilder.Entity<Cidade>()
                     .HasOne(c => c.Estado) // Define a relação com a entidade Estado
                     .WithMany(e => e.Cidades) //Indica que um estado pode ter várias cidades
                     .HasForeignKey(c => c.EstadoId) // Define a chave estrangeira
                     .OnDelete(DeleteBehavior.Restrict) // Define a ação de exclusão
                     .HasConstraintName("FK_Cidade_Estado"); // Define o nome da chave estrangeira

                modelBuilder.Entity<Cidade>().ToTable("cidades");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                // Definição da chave primária            
                object value = entity.HasKey(c => c.CpfCnpj);

                // Configuração das propriedades

                entity.Property(c => c.CpfCnpj)
                        .HasMaxLength(18)
                        .IsRequired()
                        .HasColumnName("cliente_cpfcnpj_id");
                entity.Property(c => c.Email)
                        .HasMaxLength(50)
                        .IsRequired()
                        .HasColumnName("cliente_email");
                entity.Property(c => c.Nome)
                        .HasMaxLength(100)
                        .IsRequired()
                        .HasColumnName("cliente_nome");
                entity.Property(c => c.NomeRazaoSoc)
                        .HasMaxLength(100)
                        .HasColumnName("cliente_nome_raza_social");
                entity.Property(c => c.Apelido)
                        .HasMaxLength(50)
                        .HasColumnName("cliente_apelido");
                entity.Property(c => c.Genero)
                        .IsRequired()
                        .HasColumnName("cliente_genero");
                entity.Property(c => c.DataNascimento)
                        .IsRequired()
                        .HasColumnName("cliente_dt_nasc");
                entity.Property(c => c.Celular)
                        .HasMaxLength(16)
                        .HasColumnName("cliente_celular");
                entity.Property(c => c.TelefoneFixo)
                        .HasMaxLength(14)
                        .HasColumnName("cliente_telefone_fixo");
                entity.Property(c => c.Ativo)
                        .HasDefaultValue(true)
                        .HasColumnName("cliente_ativo");
                entity.Property(c => c.Created)
                        .IsRequired()
                        .HasDefaultValue(DateTime.Now)
                        .HasColumnName("cliente_created");
                entity.Property(c => c.UserInserted)
                        .HasMaxLength(450)
                        .HasColumnName("cliente_user_created");
                entity.Property(c => c.Updated)
                        .IsRequired()
                        .HasDefaultValue(DateTime.Now)
                        .HasColumnName("cliente_updated");
                entity.Property(c => c.UserUpdated)
                        .HasMaxLength(450)
                        .HasColumnName("cliente_user_updated");
                entity.Property(c => c.Image)
                        .HasMaxLength(100)
                        .HasColumnName("cliente_image");
                entity.Property(c => c.Info)
                        .HasMaxLength(500)
                        .HasColumnName("cliente_info");
                entity.Property(c => c.EnderecoId)
                        .HasColumnName("cliente_endereco_id");

                // Relacionamento com a entidade Cidade
                modelBuilder.Entity<Cliente>()
                    .HasMany(e => e.Enderecos)
                    .WithOne(c => c.Cliente)
                    .HasForeignKey(e => e.EnderecoId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Cliente_Endereco");

                modelBuilder.Entity<Cliente>().ToTable("clientes");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                object value = entity.HasKey(c => c.EnderecoId);

                entity.Property(e => e.EnderecoId)
                    .IsRequired()
                    .HasColumnName("endereco_id");
                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("endereco_cep");
                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("endereco_logadouro");
                entity.Property(e => e.Numero)
                    .HasColumnName("endereco_numero");
                entity.Property(e => e.Complemento)
                    .HasMaxLength(500)
                    .HasColumnName("endereco_complemento");
                entity.Property(e => e.InformacaoReferencia)
                    .HasMaxLength(250)
                    .HasColumnName("endereco_info_referencia");
                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("endereco_bairro");
                entity.Property(e => e.CidadeId)                    
                    .HasColumnName("endereco_cidade_id");
                entity.Property(e => e.EnderecoPrincipal)
                    .HasDefaultValue(false)
                    .HasColumnName("endereco_principal");                
                entity.Property(e => e.ClienteId)                    
                    .HasColumnName("endereco_cliente_id");
                entity.Property(e => e.Ativo)
                    .HasDefaultValue(true)
                    .HasColumnName("endereco_ativo");
                entity.Property(e => e.Created)                    
                    .HasDefaultValue(DateTime.Now)
                    .HasColumnName("endereco_created");
                entity.Property(e => e.Updated)                    
                    .HasDefaultValue(DateTime.Now)
                    .HasColumnName("endereco_updated");
                entity.Property(e => e.UserInserted)
                    .HasMaxLength(450)
                    .HasColumnName("endereco_user_created");
                entity.Property(e => e.UserUpdated)
                    .HasMaxLength(450)
                    .HasColumnName("endereco_user_updated");

                // Relacionamento com a entidade Cliente
                modelBuilder.Entity<Endereco>()
                    .HasOne(e => e.Cliente) // Um endereço pertence a um cliente
                    .WithMany(c => c.Enderecos) // Um cliente pode ter muitos endereços
                    .HasForeignKey(e => e.ClienteId) // Chave estrangeira na tabela de endereços para mapear o cliente
                    .HasConstraintName("FK_Endereco_Cliente") // Nome da restrição de chave estrangeira
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(); // O relacionamento é obrigatório

                // Relacionamento com a entidade Cidade
                modelBuilder.Entity<Endereco>()
                    .HasOne(e => e.Cidade) // Um endereço pertence a uma cidade
                    .WithMany() // Uma cidade pode ter vários endereços
                    .HasForeignKey(e => e.CidadeId) // Chave estrangeira na tabela de endereços para mapear a cidade
                    .HasConstraintName("FK_Endereco_Cidade") // Nome da restrição de chave estrangeira
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired(); // O relacionamento é obrigatório

                modelBuilder.Entity<Endereco>().ToTable("enderecos");
            });
        }
    }
}
