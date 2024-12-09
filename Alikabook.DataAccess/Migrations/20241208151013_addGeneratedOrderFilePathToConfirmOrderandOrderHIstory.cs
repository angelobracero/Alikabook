using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alikabook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addGeneratedOrderFilePathToConfirmOrderandOrderHIstory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeneratedOrderFilePath",
                table: "OrderHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneratedOrderFilePath",
                table: "ConfirmOrders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneratedOrderFilePath",
                table: "OrderHistory");

            migrationBuilder.DropColumn(
                name: "GeneratedOrderFilePath",
                table: "ConfirmOrders");
        }
    }
}
