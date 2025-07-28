using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class EnderecoCliente_v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_updated",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(1310),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 813, DateTimeKind.Local).AddTicks(7301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_created",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(844),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 813, DateTimeKind.Local).AddTicks(6513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_updated",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(3806),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(2026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_created",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(3337),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(1165));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_updated",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 679, DateTimeKind.Local).AddTicks(2500),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 817, DateTimeKind.Local).AddTicks(8373));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_created",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 679, DateTimeKind.Local).AddTicks(2030),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 817, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 678, DateTimeKind.Local).AddTicks(2645),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(9703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 678, DateTimeKind.Local).AddTicks(2116),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_updated",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(7810),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_created",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(7381),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(9688));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_updated",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 813, DateTimeKind.Local).AddTicks(7301),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(1310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_created",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 813, DateTimeKind.Local).AddTicks(6513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_updated",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(2026),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_created",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(1165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(3337));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_updated",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 817, DateTimeKind.Local).AddTicks(8373),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 679, DateTimeKind.Local).AddTicks(2500));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_created",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 817, DateTimeKind.Local).AddTicks(7314),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 679, DateTimeKind.Local).AddTicks(2030));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(9703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 678, DateTimeKind.Local).AddTicks(2645));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(8737),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 678, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_updated",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 815, DateTimeKind.Local).AddTicks(712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(7810));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_created",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 23, 21, 45, 37, 814, DateTimeKind.Local).AddTicks(9688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 0, 22, 32, 677, DateTimeKind.Local).AddTicks(7381));
        }
    }
}
