using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bdowebapi.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccountsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountNumber = table.Column<int>(type: "INTEGER", maxLength: 12, nullable: false),
                    AccountType = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchAddress = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    InitialDeposit = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
