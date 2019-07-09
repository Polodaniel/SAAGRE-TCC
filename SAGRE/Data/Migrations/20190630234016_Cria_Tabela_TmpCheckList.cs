using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGRE.Data.Migrations
{
    public partial class Cria_Tabela_TmpCheckList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TmpCheckList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoCheckList = table.Column<int>(nullable: false),
                    ID_Boletim = table.Column<int>(nullable: false),
                    Questao01 = table.Column<bool>(nullable: false),
                    Questao02 = table.Column<bool>(nullable: false),
                    Questao03 = table.Column<bool>(nullable: false),
                    Questao04 = table.Column<bool>(nullable: false),
                    Questao05 = table.Column<bool>(nullable: false),
                    Questao06 = table.Column<bool>(nullable: false),
                    Questao07 = table.Column<bool>(nullable: false),
                    Questao08 = table.Column<bool>(nullable: false),
                    Questao09 = table.Column<bool>(nullable: false),
                    Questao10 = table.Column<bool>(nullable: false),
                    Questao11 = table.Column<bool>(nullable: false),
                    Questao12 = table.Column<bool>(nullable: false),
                    Questao13 = table.Column<bool>(nullable: false),
                    Questao14 = table.Column<bool>(nullable: false),
                    Questao15 = table.Column<bool>(nullable: false),
                    Questao16 = table.Column<bool>(nullable: false),
                    Questao17 = table.Column<bool>(nullable: false),
                    Questao18 = table.Column<bool>(nullable: false),
                    Questao19 = table.Column<bool>(nullable: false),
                    Questao20 = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TmpCheckList", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TmpCheckList");
        }
    }
}
