using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InheritanceInEFCoreTest.Data.Migrations
{
    public partial class addingAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "Transaction");

            migrationBuilder.AddColumn<Guid>(
                name: "FromAccountId",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ToAccountId",
                table: "Transaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_FromAccountId",
                table: "Transaction",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ToAccountId",
                table: "Transaction",
                column: "ToAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_FromAccountId",
                table: "Transaction",
                column: "FromAccountId",
                principalTable: "Account",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Account_ToAccountId",
                table: "Transaction",
                column: "ToAccountId",
                principalTable: "Account",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_FromAccountId",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Account_ToAccountId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_FromAccountId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_ToAccountId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "FromAccountId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "ToAccountId",
                table: "Transaction");

            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
