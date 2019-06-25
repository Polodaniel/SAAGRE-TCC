using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGRE.Data.Migrations
{
    public partial class Cria_Banco_Dados_e_Tabelas_Iniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtividadesModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeAtividade = table.Column<string>(nullable: true),
                    DescricaoAtividade = table.Column<string>(nullable: true),
                    Inativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadesModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BoletimModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeFiscal = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Setor = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Flag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoletimModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClassificaoOWAS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumCosta = table.Column<int>(nullable: false),
                    NumBraco = table.Column<int>(nullable: false),
                    NumPernas = table.Column<int>(nullable: false),
                    NumForca = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificaoOWAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GruposRiscoModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Inativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposRiscoModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SetorModel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sigla = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Inativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetorModel", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadesModel");

            migrationBuilder.DropTable(
                name: "BoletimModel");

            migrationBuilder.DropTable(
                name: "ClassificaoOWAS");

            migrationBuilder.DropTable(
                name: "GruposRiscoModel");

            migrationBuilder.DropTable(
                name: "SetorModel");
        }
    }
}
