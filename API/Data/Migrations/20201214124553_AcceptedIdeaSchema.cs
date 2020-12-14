using Microsoft.EntityFrameworkCore.Migrations;

namespace EskobInnovation.IdeaManagement.API.Data.Migrations
{
    public partial class AcceptedIdeaSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "Ideas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "Ideas");
        }
    }
}
