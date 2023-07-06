using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAPP1.Migrations
{
    /// <inheritdoc />
    public partial class CreateSeedDataForStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "st",
                table: "Student",
                columns: new[] { "Id", "Age", "CreatedDate", "Email", "IsActive", "IsDeleted", "ModifiedDate", "StudentName" },
                values: new object[] { 5, 10, new DateTime(2023, 7, 6, 9, 43, 54, 477, DateTimeKind.Local).AddTicks(2409), "test@test3.com", false, true, new DateTime(2023, 7, 6, 9, 43, 54, 477, DateTimeKind.Local).AddTicks(2452), "Raj" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "st",
                table: "Student",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
