using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class EnderecosClientes_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 8, 24, 22, 861, DateTimeKind.Local).AddTicks(7159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 22, 16, 40, 43, 717, DateTimeKind.Local).AddTicks(9694));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 8, 24, 22, 861, DateTimeKind.Local).AddTicks(6319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 22, 16, 40, 43, 717, DateTimeKind.Local).AddTicks(8537));

            migrationBuilder.AddColumn<int>(
                name: "cliente_endereco_id",
                table: "clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "paises",
                columns: table => new
                {
                    pais_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pais_nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    pais_nome_en = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    pais_iso_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pais_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    pais_moeda = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    pais_moeda_abrev = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paises", x => x.pais_id);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    estado_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estado_sigla = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    estado_nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    estado_pais_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.estado_id);
                    table.ForeignKey(
                        name: "FK_Estado_Pais",
                        column: x => x.estado_pais_id,
                        principalTable: "paises",
                        principalColumn: "pais_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cidades",
                columns: table => new
                {
                    cidade_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cidade_nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cidade_codigo_ibge = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    cidade_estado_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidades", x => x.cidade_id);
                    table.ForeignKey(
                        name: "FK_Cidade_Estado",
                        column: x => x.cidade_estado_id,
                        principalTable: "estados",
                        principalColumn: "estado_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enderecos",
                columns: table => new
                {
                    endereco_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    endereco_cep = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    endereco_logadouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    endereco_numero = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    endereco_complemento = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    endereco_info_referencia = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    endereco_bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    endereco_cidade_id = table.Column<int>(type: "int", nullable: false),
                    endereco_principal = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    endereco_ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    endereco_cliente_id = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enderecos", x => x.endereco_id);
                    table.ForeignKey(
                        name: "FK_Endereco_Cidade",
                        column: x => x.endereco_cidade_id,
                        principalTable: "cidades",
                        principalColumn: "cidade_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Endereco_Cliente",
                        column: x => x.endereco_cliente_id,
                        principalTable: "clientes",
                        principalColumn: "cliente_cpfcnpj_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cidades_cidade_estado_id",
                table: "cidades",
                column: "cidade_estado_id");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_endereco_cidade_id",
                table: "enderecos",
                column: "endereco_cidade_id");

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_endereco_cliente_id",
                table: "enderecos",
                column: "endereco_cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_estados_estado_pais_id",
                table: "estados",
                column: "estado_pais_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enderecos");

            migrationBuilder.DropTable(
                name: "cidades");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "paises");

            migrationBuilder.DropColumn(
                name: "cliente_endereco_id",
                table: "clientes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 22, 16, 40, 43, 717, DateTimeKind.Local).AddTicks(9694),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 8, 24, 22, 861, DateTimeKind.Local).AddTicks(7159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 22, 16, 40, 43, 717, DateTimeKind.Local).AddTicks(8537),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 8, 24, 22, 861, DateTimeKind.Local).AddTicks(6319));
        }
    }
}
