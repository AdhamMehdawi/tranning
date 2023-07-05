using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAPP1.Migrations
{
    /// <inheritdoc />
    public partial class CreateTestMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS  [dbo].[StudentAccount]
                                    GO
                                    CREATE VIEW [dbo].[StudentAccount]
                                    AS
                                    SELECT    dbo.Account.AccoutName, dbo.Account.AccountNumber, 
                                     st.Student.StudentName, st.Student.Email, st.Student.Age,
                                     dbo.Account.Id AS AccountId
                                    FROM         dbo.Account INNER JOIN
                                                          st.Student ON dbo.Account.StudentId = st.Student.Id
                                    GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW IF EXISTS  [dbo].[StudentAccount]");
        }
    }
}
