using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alikabook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProofofPaymentiInOrderHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProofOfPayment",
                table: "OrderHistory",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProofOfPayment",
                table: "OrderHistory");
        }
    }
}
