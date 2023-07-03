using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAPP1.Migrations
{
    /// <inheritdoc />
    public partial class CreateStudentTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "st",
                table: "StudentDto");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                schema: "st",
                table: "StudentDto",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentName",
                schema: "st",
                table: "StudentDto");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "st",
                table: "StudentDto",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);
        }
    }
}
