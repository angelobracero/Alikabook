using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alikabook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deleteOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    // Add other columns here
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderDetailId);
                });
        }

    }
}
