using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alikabook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deleteOrdersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BookInfos_BookId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ConfirmOrders_OrderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderHistory_OrderHistoryId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderDetails");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderHistoryId1",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderHistoryId1");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderHistoryId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BookId",
                table: "OrderDetails",
                newName: "IX_OrderDetails_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_AspNetUsers_UserId",
                table: "OrderDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_BookInfos_BookId",
                table: "OrderDetails",
                column: "BookId",
                principalTable: "BookInfos",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ConfirmOrders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "ConfirmOrders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderHistory_OrderHistoryId",
                table: "OrderDetails",
                column: "OrderHistoryId",
                principalTable: "OrderHistory",
                principalColumn: "OrderHistoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_OrderHistory_OrderHistoryId1",
                table: "OrderDetails",
                column: "OrderHistoryId1",
                principalTable: "OrderHistory",
                principalColumn: "OrderHistoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_AspNetUsers_UserId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_BookInfos_BookId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ConfirmOrders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderHistory_OrderHistoryId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_OrderHistory_OrderHistoryId1",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderId",
                table: "Orders",
                newName: "IX_Orders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderHistoryId1",
                table: "Orders",
                newName: "IX_Orders_OrderHistoryId1");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderHistoryId",
                table: "Orders",
                newName: "IX_Orders_OrderHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_BookId",
                table: "Orders",
                newName: "IX_Orders_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BookInfos_BookId",
                table: "Orders",
                column: "BookId",
                principalTable: "BookInfos",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ConfirmOrders_OrderId",
                table: "Orders",
                column: "OrderId",
                principalTable: "ConfirmOrders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderHistory_OrderHistoryId",
                table: "Orders",
                column: "OrderHistoryId",
                principalTable: "OrderHistory",
                principalColumn: "OrderHistoryId",
                onDelete: ReferentialAction.Restrict);

        }
    }
}
