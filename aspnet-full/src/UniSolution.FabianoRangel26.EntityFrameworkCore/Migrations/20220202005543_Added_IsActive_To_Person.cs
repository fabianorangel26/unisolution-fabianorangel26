using Microsoft.EntityFrameworkCore.Migrations;

namespace UniSolution.FabianoRangel26.Migrations
{
    public partial class Added_IsActive_To_Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Pessoa",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Pessoa");
        }
    }
}
