using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class enderecosClientes_v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_updated",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 710, DateTimeKind.Local).AddTicks(574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 631, DateTimeKind.Local).AddTicks(5788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_created",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 709, DateTimeKind.Local).AddTicks(9638),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 631, DateTimeKind.Local).AddTicks(4713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_updated",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 710, DateTimeKind.Local).AddTicks(5342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 632, DateTimeKind.Local).AddTicks(1613));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_created",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 710, DateTimeKind.Local).AddTicks(4406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 632, DateTimeKind.Local).AddTicks(472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_updated",
                table: "enderecos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 714, DateTimeKind.Local).AddTicks(1767),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 636, DateTimeKind.Local).AddTicks(5370));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_created",
                table: "enderecos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 714, DateTimeKind.Local).AddTicks(748),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 636, DateTimeKind.Local).AddTicks(4025));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 712, DateTimeKind.Local).AddTicks(2450),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 634, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 712, DateTimeKind.Local).AddTicks(1414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 634, DateTimeKind.Local).AddTicks(734));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_updated",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 711, DateTimeKind.Local).AddTicks(3690),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 633, DateTimeKind.Local).AddTicks(1520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_created",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 711, DateTimeKind.Local).AddTicks(2707),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 633, DateTimeKind.Local).AddTicks(370));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_updated",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 631, DateTimeKind.Local).AddTicks(5788),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 710, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_created",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 631, DateTimeKind.Local).AddTicks(4713),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 709, DateTimeKind.Local).AddTicks(9638));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_updated",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 632, DateTimeKind.Local).AddTicks(1613),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 710, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_created",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 632, DateTimeKind.Local).AddTicks(472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 710, DateTimeKind.Local).AddTicks(4406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_updated",
                table: "enderecos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 636, DateTimeKind.Local).AddTicks(5370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 714, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_created",
                table: "enderecos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 636, DateTimeKind.Local).AddTicks(4025),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 714, DateTimeKind.Local).AddTicks(748));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 634, DateTimeKind.Local).AddTicks(2021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 712, DateTimeKind.Local).AddTicks(2450));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 634, DateTimeKind.Local).AddTicks(734),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 712, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_updated",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 633, DateTimeKind.Local).AddTicks(1520),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 711, DateTimeKind.Local).AddTicks(3690));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_created",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 25, 7, 59, 36, 633, DateTimeKind.Local).AddTicks(370),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 25, 8, 0, 9, 711, DateTimeKind.Local).AddTicks(2707));
        }
    }
}
