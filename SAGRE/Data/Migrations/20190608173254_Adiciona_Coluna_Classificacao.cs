using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGRE.Data.Migrations
{
    public partial class Adiciona_Coluna_Classificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumCategoria",
                table: "ClassificaoOWAS",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumCategoria",
                table: "ClassificaoOWAS");
        }
    }
}
