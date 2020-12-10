using Microsoft.EntityFrameworkCore.Migrations;

namespace EskobInnovation.IdeaManagement.API.Data.Migrations
{
    public partial class UpdateCustomerSiteSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Sites",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_CustomerId",
                table: "Sites",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_Customers_CustomerId",
                table: "Sites",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sites_Customers_CustomerId",
                table: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Sites_CustomerId",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");
        }
    }
}
