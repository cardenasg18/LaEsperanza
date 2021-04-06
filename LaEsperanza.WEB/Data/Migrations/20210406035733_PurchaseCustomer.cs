using Microsoft.EntityFrameworkCore.Migrations;

namespace LaEsperanza.WEB.Data.Migrations
{
    public partial class PurchaseCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Customers_CustomerId",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "PurchaseDetail");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "PurchaseOrder",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrder_CustomerId",
                table: "PurchaseOrder",
                newName: "IX_PurchaseOrder_CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Customers_CustomerID",
                table: "PurchaseOrder",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Customers_CustomerID",
                table: "PurchaseOrder");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "PurchaseOrder",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrder_CustomerID",
                table: "PurchaseOrder",
                newName: "IX_PurchaseOrder_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "PurchaseDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Customers_CustomerId",
                table: "PurchaseOrder",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerID");
        }
    }
}
