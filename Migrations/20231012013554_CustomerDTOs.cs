using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bdowebapi.Migrations
{
    /// <inheritdoc />
    public partial class CustomerDTOs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AccountNumber",
                table: "Accounts",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldMaxLength: 12);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountNumber",
                table: "Accounts",
                type: "INTEGER",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
