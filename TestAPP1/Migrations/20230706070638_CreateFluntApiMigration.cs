using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAPP1.Migrations
{
    /// <inheritdoc />
    public partial class CreateFluntApiMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Student_StudentId",
                table: "Account");

            migrationBuilder.UpdateData(
                schema: "st",
                table: "Student",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 6, 10, 6, 37, 942, DateTimeKind.Local).AddTicks(464), new DateTime(2023, 7, 6, 10, 6, 37, 942, DateTimeKind.Local).AddTicks(506) });

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Student_StudentId",
                table: "Account",
                column: "StudentId",
                principalSchema: "st",
                principalTable: "Student",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Student_StudentId",
                table: "Account");

            migrationBuilder.UpdateData(
                schema: "st",
                table: "Student",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 7, 6, 9, 43, 54, 477, DateTimeKind.Local).AddTicks(2409), new DateTime(2023, 7, 6, 9, 43, 54, 477, DateTimeKind.Local).AddTicks(2452) });

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Student_StudentId",
                table: "Account",
                column: "StudentId",
                principalSchema: "st",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
