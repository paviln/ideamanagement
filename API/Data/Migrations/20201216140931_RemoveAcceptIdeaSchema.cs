using Microsoft.EntityFrameworkCore.Migrations;

namespace EskobInnovation.IdeaManagement.API.Data.Migrations
{
    public partial class RemoveAcceptIdeaSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "Ideas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "Ideas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
