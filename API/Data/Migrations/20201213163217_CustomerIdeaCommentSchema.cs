using Microsoft.EntityFrameworkCore.Migrations;

namespace EskobInnovation.IdeaManagement.API.Data.Migrations
{
    public partial class CustomerIdeaCommentSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "IdeaComments");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "IdeaComments");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "IdeaComments",
                newName: "Content");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "IdeaComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdeaComments_EmployeeId",
                table: "IdeaComments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdeaComments_Employees_EmployeeId",
                table: "IdeaComments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdeaComments_Employees_EmployeeId",
                table: "IdeaComments");

            migrationBuilder.DropIndex(
                name: "IX_IdeaComments_EmployeeId",
                table: "IdeaComments");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "IdeaComments");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "IdeaComments",
                newName: "Text");

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
    }
}
