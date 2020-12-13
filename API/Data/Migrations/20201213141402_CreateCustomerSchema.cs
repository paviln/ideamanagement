using Microsoft.EntityFrameworkCore.Migrations;

namespace EskobInnovation.IdeaManagement.API.Data.Migrations
{
    public partial class CreateCustomerSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fileDatas_Files_FileId",
                table: "fileDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fileDatas",
                table: "fileDatas");

            migrationBuilder.RenameTable(
                name: "fileDatas",
                newName: "FileDatas");

            migrationBuilder.RenameIndex(
                name: "IX_fileDatas_FileId",
                table: "FileDatas",
                newName: "IX_FileDatas_FileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileDatas",
                table: "FileDatas",
                column: "FileDataId");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeIdea",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false),
                    IdeasIdeaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeIdea", x => new { x.EmployeesEmployeeId, x.IdeasIdeaId });
                    table.ForeignKey(
                        name: "FK_EmployeeIdea_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeIdea_Ideas_IdeasIdeaId",
                        column: x => x.IdeasIdeaId,
                        principalTable: "Ideas",
                        principalColumn: "IdeaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIdea_IdeasIdeaId",
                table: "EmployeeIdea",
                column: "IdeasIdeaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileDatas_Files_FileId",
                table: "FileDatas",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileDatas_Files_FileId",
                table: "FileDatas");

            migrationBuilder.DropTable(
                name: "EmployeeIdea");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileDatas",
                table: "FileDatas");

            migrationBuilder.RenameTable(
                name: "FileDatas",
                newName: "fileDatas");

            migrationBuilder.RenameIndex(
                name: "IX_FileDatas_FileId",
                table: "fileDatas",
                newName: "IX_fileDatas_FileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fileDatas",
                table: "fileDatas",
                column: "FileDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_fileDatas_Files_FileId",
                table: "fileDatas",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
