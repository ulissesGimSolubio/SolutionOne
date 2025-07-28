using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class enderecoclientes_v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_updated",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 25, DateTimeKind.Local).AddTicks(4640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 96, DateTimeKind.Local).AddTicks(8742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_created",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 25, DateTimeKind.Local).AddTicks(4080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 96, DateTimeKind.Local).AddTicks(8333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_updated",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 25, DateTimeKind.Local).AddTicks(7733),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(1196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_created",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 25, DateTimeKind.Local).AddTicks(7183),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_updated",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 28, DateTimeKind.Local).AddTicks(164),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 98, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_created",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 27, DateTimeKind.Local).AddTicks(9518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 98, DateTimeKind.Local).AddTicks(8356));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 26, DateTimeKind.Local).AddTicks(8713),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 26, DateTimeKind.Local).AddTicks(8005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_updated",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 26, DateTimeKind.Local).AddTicks(3026),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(5383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_created",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 26, DateTimeKind.Local).AddTicks(2423),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(4939));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_updated",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 96, DateTimeKind.Local).AddTicks(8742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 25, DateTimeKind.Local).AddTicks(4640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "pais_created",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 96, DateTimeKind.Local).AddTicks(8333),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 25, DateTimeKind.Local).AddTicks(4080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_updated",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(1196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 25, DateTimeKind.Local).AddTicks(7733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "estado_created",
                table: "estados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 25, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_updated",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 98, DateTimeKind.Local).AddTicks(8853),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 28, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "endereco_created",
                table: "enderecos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 98, DateTimeKind.Local).AddTicks(8356),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 27, DateTimeKind.Local).AddTicks(9518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(9879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 26, DateTimeKind.Local).AddTicks(8713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(9336),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 26, DateTimeKind.Local).AddTicks(8005));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_updated",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(5383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 26, DateTimeKind.Local).AddTicks(3026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cidade_created",
                table: "cidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 7, 53, 55, 97, DateTimeKind.Local).AddTicks(4939),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 15, 45, 24, 26, DateTimeKind.Local).AddTicks(2423));
        }
    }
}
