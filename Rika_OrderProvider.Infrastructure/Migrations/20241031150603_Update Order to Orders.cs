using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rika_OrderProvider.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrdertoOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderAddresses_OrderAddressId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderCustomers_OrderCustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Order_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrderCustomerId",
                table: "Orders",
                newName: "IX_Orders_OrderCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrderAddressId",
                table: "Orders",
                newName: "IX_Orders_OrderAddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderAddresses_OrderAddressId",
                table: "Orders",
                column: "OrderAddressId",
                principalTable: "OrderAddresses",
                principalColumn: "OrderAddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderCustomers_OrderCustomerId",
                table: "Orders",
                column: "OrderCustomerId",
                principalTable: "OrderCustomers",
                principalColumn: "OrderCustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderAddresses_OrderAddressId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderCustomers_OrderCustomerId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderCustomerId",
                table: "Order",
                newName: "IX_Order_OrderCustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderAddressId",
                table: "Order",
                newName: "IX_Order_OrderAddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderAddresses_OrderAddressId",
                table: "Order",
                column: "OrderAddressId",
                principalTable: "OrderAddresses",
                principalColumn: "OrderAddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderCustomers_OrderCustomerId",
                table: "Order",
                column: "OrderCustomerId",
                principalTable: "OrderCustomers",
                principalColumn: "OrderCustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Order_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
