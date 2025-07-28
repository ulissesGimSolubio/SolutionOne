using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class EnderecosClientes_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "pais_ativo",
                table: "paises",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "pais_created",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.AddColumn<DateTime>(
                name: "pais_updated",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(3449));

            migrationBuilder.AddColumn<string>(
                name: "pais_user_created",
                table: "paises",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pais_user_updated",
                table: "paises",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "estado_ativo",
                table: "estados",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "estado_created",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(5633));

            migrationBuilder.AddColumn<DateTime>(
                name: "estado_updated",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(6108));

            migrationBuilder.AddColumn<string>(
                name: "estado_user_created",
                table: "estados",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "estado_user_updated",
                table: "estados",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "endereco_created",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 494, DateTimeKind.Local).AddTicks(7607));

            migrationBuilder.AddColumn<DateTime>(
                name: "endereco_updated",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 494, DateTimeKind.Local).AddTicks(9046));

            migrationBuilder.AddColumn<string>(
                name: "endereco_user_created",
                table: "enderecos",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "endereco_user_updated",
                table: "enderecos",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(6847),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 8, 24, 22, 861, DateTimeKind.Local).AddTicks(7159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(6225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 8, 24, 22, 861, DateTimeKind.Local).AddTicks(6319));

            migrationBuilder.AddColumn<bool>(
                name: "cidade_ativo",
                table: "cidades",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "cidade_created",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(1069));

            migrationBuilder.AddColumn<DateTime>(
                name: "cidade_updated",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.AddColumn<string>(
                name: "cidade_user_created",
                table: "cidades",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cidade_user_updated",
                table: "cidades",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pais_ativo",
                table: "paises");

            migrationBuilder.DropColumn(
                name: "pais_created",
                table: "paises");

            migrationBuilder.DropColumn(
                name: "pais_updated",
                table: "paises");

            migrationBuilder.DropColumn(
                name: "pais_user_created",
                table: "paises");

            migrationBuilder.DropColumn(
                name: "pais_user_updated",
                table: "paises");

            migrationBuilder.DropColumn(
                name: "estado_ativo",
                table: "estados");

            migrationBuilder.DropColumn(
                name: "estado_created",
                table: "estados");

            migrationBuilder.DropColumn(
                name: "estado_updated",
                table: "estados");

            migrationBuilder.DropColumn(
                name: "estado_user_created",
                table: "estados");

            migrationBuilder.DropColumn(
                name: "estado_user_updated",
                table: "estados");

            migrationBuilder.DropColumn(
                name: "endereco_created",
                table: "enderecos");

            migrationBuilder.DropColumn(
                name: "endereco_updated",
                table: "enderecos");

            migrationBuilder.DropColumn(
                name: "endereco_user_created",
                table: "enderecos");

            migrationBuilder.DropColumn(
                name: "endereco_user_updated",
                table: "enderecos");

            migrationBuilder.DropColumn(
                name: "cidade_ativo",
                table: "cidades");

            migrationBuilder.DropColumn(
                name: "cidade_created",
                table: "cidades");

            migrationBuilder.DropColumn(
                name: "cidade_updated",
                table: "cidades");

            migrationBuilder.DropColumn(
                name: "cidade_user_created",
                table: "cidades");

            migrationBuilder.DropColumn(
                name: "cidade_user_updated",
                table: "cidades");

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 8, 24, 22, 861, DateTimeKind.Local).AddTicks(7159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 8, 24, 22, 861, DateTimeKind.Local).AddTicks(6319),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(6225));
        }
    }
}
