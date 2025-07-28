using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class EnderecoCliente_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_updated",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 813, DateTimeKind.Local).AddTicks(7301),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(3449));

            migrationBuilder.AlterColumn<string>(
                name: "pais_moeda",
                table: "paises",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "pais_iso_code",
                table: "paises",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_created",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 813, DateTimeKind.Local).AddTicks(6513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.AlterColumn<string>(
                name: "pais_code",
                table: "paises",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_updated",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(2026),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(6108));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_created",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(1165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(5633));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_updated",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 817, DateTimeKind.Local).AddTicks(8373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 494, DateTimeKind.Local).AddTicks(9046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_created",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 817, DateTimeKind.Local).AddTicks(7314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 494, DateTimeKind.Local).AddTicks(7607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(9703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(8737),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(6225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_updated",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(1687));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_created",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(9688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(1069));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_updated",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(3449),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 813, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.AlterColumn<string>(
                name: "pais_moeda",
                table: "paises",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "pais_iso_code",
                table: "paises",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_created",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(2921),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 813, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.AlterColumn<string>(
                name: "pais_code",
                table: "paises",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_updated",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(6108),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(2026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_created",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 492, DateTimeKind.Local).AddTicks(5633),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_updated",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 494, DateTimeKind.Local).AddTicks(9046),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 817, DateTimeKind.Local).AddTicks(8373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_created",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 494, DateTimeKind.Local).AddTicks(7607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 817, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(6847),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(9703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(6225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_updated",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(1687),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_created",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 14, 21, 49, 493, DateTimeKind.Local).AddTicks(1069),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(9688));
        }
    }
}
