using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAPP1.Migrations
{
    /// <inheritdoc />
    public partial class CreateAccountTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AccountType",
                columns: new[] { "Id", "AccountTypeName" },
                values: new object[] { 1, "Default Account" });

            migrationBuilder.UpdateData(
                schema: "st",
                table: "Student",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 6, 11, 57, 15, 358, DateTimeKind.Local).AddTicks(4280), new DateTime(2023, 7, 6, 11, 57, 15, 358, DateTimeKind.Local).AddTicks(4322) });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountTypeId",
                table: "Account",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AccountType_AccountTypeId",
                table: "Account",
                column: "AccountTypeId",
                principalTable: "AccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AccountType_AccountTypeId",
                table: "Account");

            migrationBuilder.DropTable(
                name: "AccountType");

            migrationBuilder.DropIndex(
                name: "IX_Account_AccountTypeId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "Account");

            migrationBuilder.UpdateData(
                schema: "st",
                table: "Student",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 6, 10, 6, 37, 942, DateTimeKind.Local).AddTicks(464), new DateTime(2023, 7, 6, 10, 6, 37, 942, DateTimeKind.Local).AddTicks(506) });
        }
    }
}
