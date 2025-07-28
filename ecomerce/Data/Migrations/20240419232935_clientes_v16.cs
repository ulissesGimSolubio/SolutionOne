using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class clientes_v16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 20, 29, 34, 186, DateTimeKind.Local).AddTicks(6556),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 19, 11, 40, 855, DateTimeKind.Local).AddTicks(8089));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 20, 29, 34, 186, DateTimeKind.Local).AddTicks(6047),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 19, 11, 40, 855, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.AlterColumn<bool>(
                name: "cliente_ativo",
                table: "clientes",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 19, 11, 40, 855, DateTimeKind.Local).AddTicks(8089),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 20, 29, 34, 186, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 19, 11, 40, 855, DateTimeKind.Local).AddTicks(7672),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 20, 29, 34, 186, DateTimeKind.Local).AddTicks(6047));

            migrationBuilder.AlterColumn<bool>(
                name: "cliente_ativo",
                table: "clientes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
