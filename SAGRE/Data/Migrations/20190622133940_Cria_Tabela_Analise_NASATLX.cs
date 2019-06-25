using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGRE.Data.Migrations
{
    public partial class Cria_Tabela_Analise_NASATLX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnaliseNASATLXModel",
                columns: table => new
                {
                    ID_Analise = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID = table.Column<int>(nullable: false),
                    rangeDM = table.Column<string>(nullable: true),
                    rangeDF = table.Column<string>(nullable: true),
                    rangeDT = table.Column<string>(nullable: true),
                    rangeDE = table.Column<string>(nullable: true),
                    rangePE = table.Column<string>(nullable: true),
                    rangeFR = table.Column<string>(nullable: true),
                    escalaFisica = table.Column<string>(nullable: true),
                    escalaTemporal = table.Column<string>(nullable: true),
                    escalaMental = table.Column<string>(nullable: true),
                    escalaPerformace = table.Column<string>(nullable: true),
                    escalaEsforco = table.Column<string>(nullable: true),
                    escalaFrustacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaliseNASATLXModel", x => x.ID_Analise);
                    table.ForeignKey(
                        name: "FK_AnaliseNASATLXModel_BoletimModel_ID",
                        column: x => x.ID,
                        principalTable: "BoletimModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnaliseNASATLXModel_ID",
                table: "AnaliseNASATLXModel",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnaliseNASATLXModel");
        }
    }
}
