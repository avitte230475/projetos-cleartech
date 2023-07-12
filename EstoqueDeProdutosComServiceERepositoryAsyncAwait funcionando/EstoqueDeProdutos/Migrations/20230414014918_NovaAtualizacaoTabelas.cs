using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueDeProdutos.Migrations
{
    /// <inheritdoc />
    public partial class NovaAtualizacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalEstoque",
                table: "ControleEstoque");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "Produtos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "TotalEstoque",
                table: "ControleEstoque",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
