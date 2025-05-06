using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UerName",
                table: "Users",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "UerName");
        }
    }
}
