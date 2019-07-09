using Microsoft.EntityFrameworkCore.Migrations;

namespace SAGRE.Data.Migrations
{
    public partial class Add_NovasPerguntas_Tmp_Muda_Tamanho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Questao20",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao19",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao18",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao17",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao16",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao15",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao14",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao13",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao12",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao11",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao10",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao09",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao08",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao07",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao06",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao05",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao04",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao03",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao02",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao01",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questao21",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questao22",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questao23",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questao24",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questao25",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questao26",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questao27",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questao28",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questao29",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Questao30",
                table: "TmpCheckList",
                maxLength: 3,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Questao21",
                table: "TmpCheckList");

            migrationBuilder.DropColumn(
                name: "Questao22",
                table: "TmpCheckList");

            migrationBuilder.DropColumn(
                name: "Questao23",
                table: "TmpCheckList");

            migrationBuilder.DropColumn(
                name: "Questao24",
                table: "TmpCheckList");

            migrationBuilder.DropColumn(
                name: "Questao25",
                table: "TmpCheckList");

            migrationBuilder.DropColumn(
                name: "Questao26",
                table: "TmpCheckList");

            migrationBuilder.DropColumn(
                name: "Questao27",
                table: "TmpCheckList");

            migrationBuilder.DropColumn(
                name: "Questao28",
                table: "TmpCheckList");

            migrationBuilder.DropColumn(
                name: "Questao29",
                table: "TmpCheckList");

            migrationBuilder.DropColumn(
                name: "Questao30",
                table: "TmpCheckList");

            migrationBuilder.AlterColumn<string>(
                name: "Questao20",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao19",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao18",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao17",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao16",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao15",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao14",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao13",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao12",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao11",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao10",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao09",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao08",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao07",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao06",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao05",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao04",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao03",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao02",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Questao01",
                table: "TmpCheckList",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);
        }
    }
}
