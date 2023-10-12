using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bdowebapi.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFullNameFromCustomerClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Customers",
                type: "TEXT",
                nullable: true);
        }
    }
}
