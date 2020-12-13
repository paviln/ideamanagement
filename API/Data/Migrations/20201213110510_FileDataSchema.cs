using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EskobInnovation.IdeaManagement.API.Data.Migrations
{
    public partial class FileDataSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Files");

            migrationBuilder.CreateTable(
                name: "fileDatas",
                columns: table => new
                {
                    FileDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fileDatas", x => x.FileDataId);
                    table.ForeignKey(
                        name: "FK_fileDatas_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fileDatas_FileId",
                table: "fileDatas",
                column: "FileId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fileDatas");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Files",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
