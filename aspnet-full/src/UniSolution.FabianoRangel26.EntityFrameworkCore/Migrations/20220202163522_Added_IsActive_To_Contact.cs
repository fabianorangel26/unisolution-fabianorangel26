using Microsoft.EntityFrameworkCore.Migrations;

namespace UniSolution.FabianoRangel26.Migrations
{
    public partial class Added_IsActive_To_Contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ListaContatos",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ListaContatos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ListaContatos");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ListaContatos",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 512);
        }
    }
}
