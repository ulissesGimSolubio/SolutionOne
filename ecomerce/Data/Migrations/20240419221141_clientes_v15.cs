using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecomerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class clientes_v15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "clientes",
                newName: "cliente_image");

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 19, 11, 40, 855, DateTimeKind.Local).AddTicks(8089),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 17, 26, 27, 7, DateTimeKind.Local).AddTicks(6508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 19, 11, 40, 855, DateTimeKind.Local).AddTicks(7672),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 17, 26, 27, 7, DateTimeKind.Local).AddTicks(6024));

            migrationBuilder.AlterColumn<string>(
                name: "cliente_image",
                table: "clientes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cliente_image",
                table: "clientes",
                newName: "Image");

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_updated",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 17, 26, 27, 7, DateTimeKind.Local).AddTicks(6508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 19, 11, 40, 855, DateTimeKind.Local).AddTicks(8089));

            migrationBuilder.AlterColumn<DateTime>(
                name: "cliente_created",
                table: "clientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 17, 26, 27, 7, DateTimeKind.Local).AddTicks(6024),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 19, 11, 40, 855, DateTimeKind.Local).AddTicks(7672));

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "clientes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
