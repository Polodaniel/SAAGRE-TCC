using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGRE.Data.Migrations
{
    public partial class Add_Colunas_Tempo_Local : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AnaliseNASATLXModel_ID",
                table: "AnaliseNASATLXModel");

            migrationBuilder.AddColumn<string>(
                name: "HoraInicio",
                table: "BoletimModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HoraTermino",
                table: "BoletimModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "BoletimModel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TempoDuracao",
                table: "BoletimModel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnaliseNASATLXModel_ID",
                table: "AnaliseNASATLXModel",
                column: "ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AnaliseNASATLXModel_ID",
                table: "AnaliseNASATLXModel");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "BoletimModel");

            migrationBuilder.DropColumn(
                name: "HoraTermino",
                table: "BoletimModel");

            migrationBuilder.DropColumn(
                name: "Local",
                table: "BoletimModel");

            migrationBuilder.DropColumn(
                name: "TempoDuracao",
                table: "BoletimModel");

            migrationBuilder.CreateIndex(
                name: "IX_AnaliseNASATLXModel_ID",
                table: "AnaliseNASATLXModel",
                column: "ID");
        }
    }
}
