using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LaEsperanza.WEB.Data.Migrations
{
    public partial class OrdenesCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductiD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 30, nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Retiro = table.Column<string>(maxLength: 200, nullable: true),
                    PriceP = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductiD);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierName = table.Column<string>(maxLength: 50, nullable: false),
                    Mail = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SupplierId = table.Column<int>(nullable: false),
                    OrderTime = table.Column<DateTime>(nullable: false),
                    comentario = table.Column<string>(nullable: true),
                    SubTotal = table.Column<decimal>(nullable: false),
                    Valueimp = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    DetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductiD = table.Column<int>(nullable: false),
                    Quantity = table.Column<float>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    TotalValue = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_OrderDetail_Products_ProductiD",
                        column: x => x.ProductiD,
                        principalTable: "Products",
                        principalColumn: "ProductiD");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_SupplierId",
                table: "Order",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductiD",
                table: "OrderDetail",
                column: "ProductiD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
