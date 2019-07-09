using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGRE.Data.Migrations
{
    public partial class Add_Tabelas_CheckListAnalise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckListAnaliseCondBio",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoCheckList = table.Column<int>(nullable: false),
                    ID_Boletim = table.Column<int>(nullable: false),
                    Questao01 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao02 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao03 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao04 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao05 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao06 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao07 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao08 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao09 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao10 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao11 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao12 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao13 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao14 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao15 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao16 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao17 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao18 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao19 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao20 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao21 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao22 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao23 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao24 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao25 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao26 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao27 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao28 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao29 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao30 = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListAnaliseCondBio", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CheckListAnaliseCondErg",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoCheckList = table.Column<int>(nullable: false),
                    ID_Boletim = table.Column<int>(nullable: false),
                    Questao01 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao02 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao03 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao04 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao05 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao06 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao07 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao08 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao09 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao10 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao11 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao12 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao13 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao14 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao15 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao16 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao17 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao18 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao19 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao20 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao21 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao22 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao23 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao24 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao25 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao26 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao27 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao28 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao29 = table.Column<string>(maxLength: 3, nullable: true),
                    Questao30 = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListAnaliseCondErg", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListAnaliseCondBio");

            migrationBuilder.DropTable(
                name: "CheckListAnaliseCondErg");
        }
    }
}
