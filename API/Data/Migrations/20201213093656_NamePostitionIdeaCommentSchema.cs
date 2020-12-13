using Microsoft.EntityFrameworkCore.Migrations;

namespace EskobInnovation.IdeaManagement.API.Data.Migrations
{
    public partial class NamePostitionIdeaCommentSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "IdeaComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "IdeaComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "IdeaComments");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "IdeaComments");
        }
    }
}
