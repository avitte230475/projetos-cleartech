using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueDeProdutos.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTotalEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalEstoque",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalEstoque",
                table: "Produtos");
        }
    }
}
