using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGRE.Data.Migrations
{
    public partial class Cria_Coluna_Atividade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Atividade",
                table: "BoletimModel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "IP",
                table: "AnalisePosturaModel",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "IE",
                table: "AnalisePosturaModel",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "IC",
                table: "AnalisePosturaModel",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "IB",
                table: "AnalisePosturaModel",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atividade",
                table: "BoletimModel");

            migrationBuilder.AlterColumn<int>(
                name: "IP",
                table: "AnalisePosturaModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IE",
                table: "AnalisePosturaModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IC",
                table: "AnalisePosturaModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IB",
                table: "AnalisePosturaModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
