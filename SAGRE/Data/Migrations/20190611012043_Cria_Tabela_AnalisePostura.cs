using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGRE.Data.Migrations
{
    public partial class Cria_Tabela_AnalisePostura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnalisePosturaModel",
                columns: table => new
                {
                    ID_Analise = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID = table.Column<int>(nullable: false),
                    IB = table.Column<int>(nullable: false),
                    IP = table.Column<int>(nullable: false),
                    IE = table.Column<int>(nullable: false),
                    IC = table.Column<int>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    IBDescricao = table.Column<string>(nullable: true),
                    IPDescricao = table.Column<string>(nullable: true),
                    IEDescricao = table.Column<string>(nullable: true),
                    ICDescricao = table.Column<string>(nullable: true),
                    AcaoDescricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisePosturaModel", x => x.ID_Analise);
                    table.ForeignKey(
                        name: "FK_AnalisePosturaModel_BoletimModel_ID",
                        column: x => x.ID,
                        principalTable: "BoletimModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalisePosturaModel_ID",
                table: "AnalisePosturaModel",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalisePosturaModel");
        }
    }
}
