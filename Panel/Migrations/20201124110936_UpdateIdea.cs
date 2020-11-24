using Microsoft.EntityFrameworkCore.Migrations;

namespace Panel.Migrations
{
    public partial class UpdateIdea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ideas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Effort",
                table: "Ideas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Impact",
                table: "Ideas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "Effort",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "Impact",
                table: "Ideas");
        }
    }
}
